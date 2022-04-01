using System;
using System.Collections.Generic;

namespace WebApplication10
{
    public partial class Supplier
    {
        public Supplier()
        {
            Deliveries = new HashSet<Delivery>();
        }

        public int SupplierId { get; set; }
        public string SupplierName { get; set; } = null!;
        public string SupplierAddress { get; set; } = null!;

        public virtual ICollection<Delivery> Deliveries { get; set; }
    }
}
