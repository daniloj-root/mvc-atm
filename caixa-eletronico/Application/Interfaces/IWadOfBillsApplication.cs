using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using caixa_eletronico.Domain.DTO.WadOfBills;
using caixa_eletronico.Domain.Models;

namespace caixa_eletronico.Application.Interfaces
{
    public interface IWadOfBillsApplication
    {
        IEnumerable<WadOfBillsDTO> Get();
        void AddToCurrentWads(IFormCollection form);
        WadOfBillsDTO GetByBillValue(uint billValue);
        OutboundWithdrawResultDTO Withdraw(IFormCollection form);
    }
}
