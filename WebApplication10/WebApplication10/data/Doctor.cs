using System;
using System.Collections.Generic;

namespace WebApplication10
{
    public partial class Doctor
    {
        public Doctor()
        {
            ClientsVisits = new HashSet<ClientsVisit>();
            Records = new HashSet<Record>();
        }

        public int EmployeeId { get; set; }
        public int CabinetId { get; set; }

        public virtual Cabinet Cabinet { get; set; } = null!;
        public virtual Employee Employee { get; set; } = null!;
        public virtual ICollection<ClientsVisit> ClientsVisits { get; set; }
        public virtual ICollection<Record> Records { get; set; }
    }
}
