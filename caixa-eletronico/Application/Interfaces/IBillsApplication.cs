using System.Collections.Generic;
using caixa_eletronico.Domain.DTO.WadOfBills;
using caixa_eletronico.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace caixa_eletronico.Application
{
    public interface IBillsApplication
    {
        IEnumerable<OutboundBillDTO> Get();
        OutboundBillDTO GetByValue(int value);
        void Add(IFormCollection form);
        void Remove(int value);
    }
}
