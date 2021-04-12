using caixa_eletronico.Domain.DTO;
using caixa_eletronico.Infrastructure.Database;
using caixa_eletronico.Domain.Models;
using caixa_eletronico.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caixa_eletronico.Infrastructure.Repositories
{
    public class BillsRepository : IBillsRepository
    {
        readonly ATMDbContext _dbContext;

        public BillsRepository()
        {
            _dbContext = new ATMDbContext();
        }

        public IEnumerable<Bill> Get()
        {
            return _dbContext.Bill;
        }

        public Bill GetByValue(int value)
        {
            return _dbContext.Bill
                .FirstOrDefault(x => x.MonetaryValue == value);
        }

        public void Add(Bill newBill)
        {
            _dbContext.Add(newBill);
            _dbContext.SaveChanges();
        }

        public void Remove(int value)
        {
            var bill = _dbContext.Bill
                .FirstOrDefault(x => x.MonetaryValue == value);

            var wadOfBills = _dbContext.WadOfBills
                .FirstOrDefault(x => x.BillValue == value);

            _dbContext.Remove(wadOfBills);
            _dbContext.Remove(bill);
            _dbContext.SaveChanges();
        }
    }
}
