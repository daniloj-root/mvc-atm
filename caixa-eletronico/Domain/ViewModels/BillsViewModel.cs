using caixa_eletronico.Domain.DTO.WadOfBills;
using System.Collections.Generic;

namespace caixa_eletronico.Domain.ViewModels
{
    public class BillsViewModel
    {
        public IEnumerable<OutboundBillDTO> Bills;

        public BillsViewModel(IEnumerable<OutboundBillDTO> bills)
        {
            Bills = bills;
        }
    }
}
