using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caixa_eletronico.Domain.DTO.WadOfBills
{
    public class WadOfBillsDTO
    {
        public int BillValue { get; set; }
        public int Quantity { get; set; }
        public int TotalValue => BillValue * Quantity;
    }
}
