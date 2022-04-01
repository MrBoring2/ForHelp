using System;
using System.Collections.Generic;

namespace WebApplication10
{
    public partial class Storage
    {
        public Storage()
        {
            ConsumablesInStorages = new HashSet<ConsumablesInStorage>();
            Deliveries = new HashSet<Delivery>();
        }

        public int StorageId { get; set; }
        public string? StorageName { get; set; }

        public virtual ICollection<ConsumablesInStorage> ConsumablesInStorages { get; set; }
        public virtual ICollection<Delivery> Deliveries { get; set; }
    }
}
