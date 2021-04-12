using System.Collections.Generic;

namespace caixa_eletronico.Domain.ValueObjects
{
    public class WithdrawResult
    {
        public string ResultMessage { get; }
        public decimal? NextPossibleValue { get; }
        public IEnumerable<Models.WadOfBills> WithdrewWads { get; }

        public WithdrawResult(
            string resultMessage,
            IEnumerable<Models.WadOfBills> withdrewWads = null,
            decimal? nextPossibleValue = null)
        {
            ResultMessage = resultMessage;
            WithdrewWads = withdrewWads;
            NextPossibleValue = nextPossibleValue;
        }
    }
}
