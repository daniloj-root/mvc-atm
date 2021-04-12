using caixa_eletronico.Domain.ValueObjects;
using caixa_eletronico.Domain.Models;
using caixa_eletronico.Infrastructure.Repositories.Interfaces;
using caixa_eletronico.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace caixa_eletronico.Services
{
    public class WadOfBillsService : IWadOfBillsService
    {
        readonly IWadOfBillsRepository _wadOfBillsRepository;

        public WadOfBillsService(IWadOfBillsRepository wadOfBillsRepository)
        {
            _wadOfBillsRepository = wadOfBillsRepository;
        }

        public IEnumerable<WadOfBills> Get()
        {
            return _wadOfBillsRepository.Get();
        }

        public IEnumerable<WadOfBills> GetNotEmpty()
        {
            return _wadOfBillsRepository.GetNotEmpty();
        }

        public WadOfBills GetByBillValue(uint billValue)
        {
            return _wadOfBillsRepository.GetByBillValue(billValue);
        }

        public void AddToCurrentWads(
            IEnumerable<WadOfBills> pendingWads,
            IEnumerable<WadOfBills> currentWads)
        {
            // Groups by bill valuea and then sum bill quantities per group
            var updatedWads = from cw in currentWads.Concat(pendingWads)
                              group cw by cw.BillValue into g
                              select new WadOfBills(billValue: g.Key, quantity: g.Sum(x => x.Quantity));

            _wadOfBillsRepository.BatchUpdate(updatedWads);
        }

        public WithdrawResult Withdraw(
            IEnumerable<WadOfBills> notEmptyCurrentWads,
            decimal withdrawValue)
        {
            var avaliableValue = notEmptyCurrentWads.Sum(x => x.BillValue * x.Quantity);
            withdrawValue = Math.Floor(withdrawValue);

            if (withdrawValue == 0)
            {
                return new WithdrawResult
                    (
                        resultMessage: "Você não pode sacar nada.",
                        nextPossibleValue: 0
                    );
            }
            else if (avaliableValue < withdrawValue)
            {
                return new WithdrawResult
                    (
                        resultMessage: "Valor total no caixa insuficiente.",
                        nextPossibleValue: avaliableValue
                    );
            }
            else if (avaliableValue == withdrawValue)
            {
                _wadOfBillsRepository.BatchSubtractBills(notEmptyCurrentWads);

                return new WithdrawResult
                    (
                        resultMessage: "Saque feito com sucesso!",
                        nextPossibleValue: avaliableValue,
                        withdrewWads: notEmptyCurrentWads
                            .OrderByDescending(x => x.BillValue)
                    );

            }
            else
            {
                notEmptyCurrentWads = notEmptyCurrentWads
                    .OrderByDescending(x => x.BillValue);

                var withdrewWads = new List<WadOfBills>();
                foreach (var wad in notEmptyCurrentWads)
                {
                    if (withdrawValue == 0)
                        break;

                    var maxBillQty = (int)Math.Floor(withdrawValue / wad.BillValue);

                    if (maxBillQty == 0)
                    {
                        continue;
                    }
                    else if (maxBillQty > wad.Quantity)
                    {
                        withdrewWads.Add(new WadOfBills(wad.BillValue, wad.Quantity));
                        withdrawValue -= wad.BillValue * wad.Quantity;
                    }
                    else
                    {
                        withdrewWads.Add(new WadOfBills(wad.BillValue, maxBillQty));
                        withdrawValue -= wad.BillValue * maxBillQty;
                    }
                }

                if (withdrewWads.Count > 0)
                {
                    _wadOfBillsRepository.BatchSubtractBills(withdrewWads);

                    return new WithdrawResult
                        (
                            resultMessage: "Saque feito com sucesso!",
                            withdrewWads: withdrewWads
                        );
                }
                else
                {
                    return new WithdrawResult
                       (
                           resultMessage: "Não temos notas para atender ao saque.",
                           withdrewWads: withdrewWads
                       );
                }
            }
        }
    }
}
