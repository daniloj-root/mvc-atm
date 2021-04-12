using caixa_eletronico.Domain.DTO.WadOfBills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caixa_eletronico.Domain.ViewModels
{
    public class WithdrawViewModel
    {
        public bool RequestDone;
        public string ResultMessage;
        public decimal? NextPossibleValue;
        public IEnumerable<WadOfBillsDTO> WithdrewWads;
        public bool Success;

        public WithdrawViewModel(OutboundWithdrawResultDTO withdrawResultDTO)
        {
            RequestDone = true;
            ResultMessage = withdrawResultDTO.ResultMessage;
            NextPossibleValue = withdrawResultDTO.NextPossibleValue;
            WithdrewWads = withdrawResultDTO.WithdrewWads;
            Success = withdrawResultDTO.Success;
        }

        public WithdrawViewModel()
        {

        }
    }
}
