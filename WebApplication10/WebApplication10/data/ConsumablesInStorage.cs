using System;
using System.Collections.Generic;

namespace WebApplication10
{
    public partial class ConsumablesInStorage
    {
        public int StorageId { get; set; }
        public int ConsumableId { get; set; }
        public int Amount { get; set; }

        public virtual Consumable Consumable { get; set; } = null!;
        public virtual Storage Storage { get; set; } = null!;
    }
}
