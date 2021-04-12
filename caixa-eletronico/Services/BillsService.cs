using caixa_eletronico.Infrastructure.Repositories.Interfaces;
using caixa_eletronico.Domain.Models;
using caixa_eletronico.Services.Interfaces;
using System.Collections.Generic;

namespace caixa_eletronico.Services
{
    public class BillsService : IBillsService
    {
        readonly IBillsRepository _billsRepository;

        public BillsService(IBillsRepository billsRepository)
        {
            _billsRepository = billsRepository;
        }

        public IEnumerable<Bill> Get()
        {
            return _billsRepository.Get();
        }

        public Bill GetByValue(int value)
        {
            return _billsRepository.GetByValue(value);
        }

        public void Add(int newBillValue)
        {
            _billsRepository.Add(new Bill() { MonetaryValue = newBillValue });
        }

        public void Remove(int value)
        {
            _billsRepository.Remove(value);
        }
    }
}
