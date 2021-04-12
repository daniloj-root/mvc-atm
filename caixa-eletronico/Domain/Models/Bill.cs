using System;
using System.Collections.Generic;

namespace caixa_eletronico.Domain.Models
{
    public class Bill
    {
        public int MonetaryValue { get; set; }

        public virtual WadOfBills WadOfBills { get; set; }
    }
}
