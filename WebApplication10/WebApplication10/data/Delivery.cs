using System;
using System.Collections.Generic;

namespace WebApplication10
{
    public partial class Delivery
    {
        public Delivery()
        {
            ConsumablesInDeliveries = new HashSet<ConsumablesInDelivery>();
        }

        public int DeliveryId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int SupplierId { get; set; }
        public int StorageId { get; set; }

        public virtual Storage Storage { get; set; } = null!;
        public virtual Supplier Supplier { get; set; } = null!;
        public virtual ICollection<ConsumablesInDelivery> ConsumablesInDeliveries { get; set; }
    }
}
