using System;
using System.Collections.Generic;

namespace WebApplication10
{
    public partial class Client
    {
        public Client()
        {
            ClientsVisits = new HashSet<ClientsVisit>();
            Records = new HashSet<Record>();
        }

        public int ClientId { get; set; }
        public string ClientFullName { get; set; } = null!;
        public string ClientGender { get; set; } = null!;
        public string PassportNumber { get; set; } = null!;
        public string PassportSeries { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public DateTime ClientDateOfBirth { get; set; }

        public virtual ICollection<ClientsVisit> ClientsVisits { get; set; }
        public virtual ICollection<Record> Records { get; set; }
    }
}
