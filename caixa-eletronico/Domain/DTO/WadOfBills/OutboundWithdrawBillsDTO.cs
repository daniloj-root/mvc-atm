using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caixa_eletronico.Domain.DTO.WadOfBills
{
    public class OutboundWithdrawResultDTO
    {
        public string ResultMessage { get; set; }
        public decimal? NextPossibleValue { get; set; }
        public IEnumerable<WadOfBillsDTO> WithdrewWads { get; set; }
        public bool Success => WithdrewWads.Count() > 0;
    }
}
