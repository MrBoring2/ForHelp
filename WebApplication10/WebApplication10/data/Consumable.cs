using System;
using System.Collections.Generic;

namespace WebApplication10
{
    public partial class Consumable
    {
        public Consumable()
        {
            ConsumablesInDeliveries = new HashSet<ConsumablesInDelivery>();
            ConsumablesInStorages = new HashSet<ConsumablesInStorage>();
            SpentConsumablesForVisits = new HashSet<SpentConsumablesForVisit>();
        }

        public int ConsumableId { get; set; }
        public string ConsumableName { get; set; } = null!;
        public int ConsumableTypeId { get; set; }
        public double Price { get; set; }

        public virtual ConsumableType ConsumableType { get; set; } = null!;
        public virtual ICollection<ConsumablesInDelivery> ConsumablesInDeliveries { get; set; }
        public virtual ICollection<ConsumablesInStorage> ConsumablesInStorages { get; set; }
        public virtual ICollection<SpentConsumablesForVisit> SpentConsumablesForVisits { get; set; }
    }
}
