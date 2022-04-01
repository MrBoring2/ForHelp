using System;
using System.Collections.Generic;

namespace WebApplication10
{
    public partial class Record
    {
        public int RecordId { get; set; }
        public int ClientId { get; set; }
        public DateTime RecordDate { get; set; }
        public int DoctorId { get; set; }

        public virtual Client Client { get; set; } = null!;
        public virtual Doctor Doctor { get; set; } = null!;
    }
}
