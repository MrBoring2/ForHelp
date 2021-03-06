using System;
using System.Collections.Generic;

namespace WebApplication10
{
    public partial class ClientsVisit
    {
        public ClientsVisit()
        {
            SpentConsumablesForVisits = new HashSet<SpentConsumablesForVisit>();
        }

        public int ClientVisitId { get; set; }
        public DateTime VisitDate { get; set; }
        public int? ClientId { get; set; }
        public int VisitTypeId { get; set; }
        public int? DoctorId { get; set; }

        public virtual Client? Client { get; set; }
        public virtual Doctor? Doctor { get; set; }
        public virtual VisitType VisitType { get; set; } = null!;
        public virtual ICollection<SpentConsumablesForVisit> SpentConsumablesForVisits { get; set; }
    }
}
