using caixa_eletronico.Domain.DTO.WadOfBills;
using System.Collections.Generic;

namespace caixa_eletronico.Domain.ViewModels
{
    public class WadOfBillsViewModel
    {
        public IEnumerable<WadOfBillsDTO> WadsOfBills;

        public WadOfBillsViewModel(IEnumerable<WadOfBillsDTO> wadsOfBills)
        {
            WadsOfBills = wadsOfBills;
        }
    }
}
