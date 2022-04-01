using System;
using System.Collections.Generic;

namespace WebApplication10
{
    public partial class ConsumableType
    {
        public ConsumableType()
        {
            Consumables = new HashSet<Consumable>();
        }

        public int ConsumableTypeId { get; set; }
        public string ConsumableTypeName { get; set; } = null!;

        public virtual ICollection<Consumable> Consumables { get; set; }
    }
}
