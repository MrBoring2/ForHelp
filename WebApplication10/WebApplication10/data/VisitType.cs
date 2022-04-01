using System;
using System.Collections.Generic;

namespace WebApplication10
{
    public partial class VisitType
    {
        public VisitType()
        {
            ClientsVisits = new HashSet<ClientsVisit>();
        }

        public int VisitTypeId { get; set; }
        public string VisitTypeName { get; set; } = null!;

        public virtual ICollection<ClientsVisit> ClientsVisits { get; set; }
    }
}
