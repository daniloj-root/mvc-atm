using caixa_eletronico.Infrastructure.Database;
using caixa_eletronico.Domain.Models;
using caixa_eletronico.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caixa_eletronico.Infrastructure.Repositories
{
    public class WadOfBillsRepository : IWadOfBillsRepository
    {
        readonly ATMDbContext _dbContext;

        public WadOfBillsRepository(ATMDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<WadOfBills> Get()
        {
            return _dbContext.WadOfBills.ToList();
        }

        public IEnumerable<WadOfBills> GetNotEmpty()
        {
            return _dbContext.WadOfBills.Where(x => x.Quantity > 0).ToList();
        }

        public WadOfBills GetByBillValue(uint billValue)
        {
            return _dbContext.WadOfBills
                .FirstOrDefault(x => x.BillValue == billValue);
        }

        public void BatchUpdate(IEnumerable<WadOfBills> updatedWads)
        {
            foreach (var updatedWad in updatedWads)
            {
                var databaseWad = _dbContext.WadOfBills
                    .FirstOrDefault(x => x.BillValue == updatedWad.BillValue);

                databaseWad.Quantity = updatedWad.Quantity;
            }

            _dbContext.SaveChanges();
        }

        public void BatchSubtractBills(IEnumerable<WadOfBills> withdrewWads)
        {
            foreach (var withdrewWad in withdrewWads)
            {
                var databaseWad = _dbContext.WadOfBills
                    .FirstOrDefault(x => x.BillValue == withdrewWad.BillValue);

                databaseWad.Quantity -= withdrewWad.Quantity;

                _dbContext.SaveChanges();
            }
        }
    }
}
