using caixa_eletronico.Domain.ValueObjects;
using caixa_eletronico.Domain.Models;
using System.Collections.Generic;

namespace caixa_eletronico.Services.Interfaces
{
    public interface IWadOfBillsService
    {
        IEnumerable<WadOfBills> Get();
        IEnumerable<WadOfBills> GetNotEmpty();
        WadOfBills GetByBillValue(uint billValue);
        WithdrawResult Withdraw(
            IEnumerable<WadOfBills> notEmptyCurrentWads,
            decimal withdrawValue);

        void AddToCurrentWads(
            IEnumerable<WadOfBills> pendingWads,
            IEnumerable<WadOfBills> currentWads
            );
    }
}

