using AutoMapper;
using caixa_eletronico.Application.Interfaces;
using caixa_eletronico.Domain.DTO.WadOfBills;
using caixa_eletronico.Domain.Models;
using caixa_eletronico.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace caixa_eletronico.Application
{
    public class WadOfBillsApplication : IWadOfBillsApplication
    {
        readonly IMapper _mapper;
        readonly IWadOfBillsService _wadOfBillsService;

        public WadOfBillsApplication(
            IMapper mapper,
            IWadOfBillsService wadOfBillsService)
        {
            _mapper = mapper;
            _wadOfBillsService = wadOfBillsService;
        }

        public IEnumerable<WadOfBillsDTO> Get()
        {
            var wadsOfBills = _wadOfBillsService.Get();
            return _mapper.Map<IEnumerable<WadOfBillsDTO>>(wadsOfBills);
        }

        public WadOfBillsDTO GetByBillValue(uint billValue)
        {
            var wadOfBills = _wadOfBillsService.GetByBillValue(billValue);
            return _mapper.Map<WadOfBillsDTO>(wadOfBills);
        }

        public void AddToCurrentWads(IFormCollection form)
        {
            var avaliableWads = _wadOfBillsService.Get();

            var pendingWads = avaliableWads.Select(wad =>
            {
                var validInput = int.TryParse(form[$"qtd-notas-{wad.BillValue}"], out int quantity);

                if (!validInput)
                    quantity = 0;

                return new WadOfBills
                    (
                        billValue: wad.BillValue,
                        quantity: quantity
                    );
            });

            _wadOfBillsService.AddToCurrentWads(pendingWads, avaliableWads);
        }

        public OutboundWithdrawResultDTO Withdraw(IFormCollection form)
        {
            var validInput = decimal.TryParse(form["valor-saque"], out decimal withdrawValue);

            if (!validInput)
            {
                return new OutboundWithdrawResultDTO
                {
                    ResultMessage = "Input inválido!",
                };
            }

            var notEmptyWads = new List<WadOfBills>();

            _wadOfBillsService
                .GetNotEmpty()
                .ToList()
                .ForEach(x => notEmptyWads.Add(new WadOfBills(x.BillValue, x.Quantity)));

            var withdrawResult = _wadOfBillsService
                .Withdraw(notEmptyWads, withdrawValue);

            return _mapper.Map<OutboundWithdrawResultDTO>(withdrawResult);
        }
    }
}
