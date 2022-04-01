using System;
using System.Collections.Generic;

namespace WebApplication10
{
    public partial class ConsumablesInDelivery
    {
        public int DeliveryId { get; set; }
        public int ConsumableId { get; set; }
        public int Amount { get; set; }

        public virtual Consumable Consumable { get; set; } = null!;
        public virtual Delivery Delivery { get; set; } = null!;
    }
}
