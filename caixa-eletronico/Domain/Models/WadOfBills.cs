using System;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace caixa_eletronico.Domain.Models
{
    public class WadOfBills : ICloneable
    {
        public WadOfBills(
            int billValue,
            int quantity)
        {
            BillValue = billValue;
            Quantity = quantity;
        }

        public int BillValue { get; set; }
        public int Quantity { get; set; }

        public virtual Bill BillValueNavigation { get; set; }

        public WadOfBills() { }

        public WadOfBills(WadOfBills wadOfBills)
        {
            BillValue = wadOfBills.BillValue;
            Quantity = wadOfBills.Quantity;
        }

        public object Clone()
        {
            return new WadOfBills(this);
        }
    }
}
