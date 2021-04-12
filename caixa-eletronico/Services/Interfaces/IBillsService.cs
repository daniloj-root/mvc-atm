using caixa_eletronico.Infrastructure.Database;
using caixa_eletronico.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caixa_eletronico.Services.Interfaces
{
    public interface IBillsService
    {
        public IEnumerable<Bill> Get();
        public void Add(int newValue);
        public Bill GetByValue(int value);
        public void Remove(int value);
    }
}
