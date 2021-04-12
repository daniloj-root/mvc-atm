using caixa_eletronico.Domain.Models;
using System.Collections.Generic;

namespace caixa_eletronico.Infrastructure.Repositories.Interfaces
{
    public interface IWadOfBillsRepository
    {
        IEnumerable<WadOfBills> Get();
        IEnumerable<WadOfBills> GetNotEmpty();
        WadOfBills GetByBillValue(uint billValue);
        void BatchUpdate(IEnumerable<WadOfBills> updatedWadsOfBills);
        void BatchSubtractBills(IEnumerable<WadOfBills> withdrewWads);
    }
}
