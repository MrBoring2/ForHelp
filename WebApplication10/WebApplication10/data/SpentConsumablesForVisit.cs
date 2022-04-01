using System;
using System.Collections.Generic;

namespace WebApplication10
{
    public partial class SpentConsumablesForVisit
    {
        public int СonsumableId { get; set; }
        public int VisitId { get; set; }
        public int Amount { get; set; }

        public virtual ClientsVisit Visit { get; set; } = null!;
        public virtual Consumable Сonsumable { get; set; } = null!;
    }
}
