using caixa_eletronico.Domain.DTO;
using caixa_eletronico.Infrastructure.Database;
using caixa_eletronico.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caixa_eletronico.Infrastructure.Repositories.Interfaces
{
    public interface IBillsRepository
    {
        IEnumerable<Bill> Get();
        Bill GetByValue(int value);
        void Add(Bill newBill);
        void Remove(int value);
    }
}
