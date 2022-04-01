using System;
using System.Collections.Generic;

namespace WebApplication10
{
    public partial class Cabinet
    {
        public Cabinet()
        {
            Doctors = new HashSet<Doctor>();
        }

        public int CabinetId { get; set; }
        public int CabinetNumber { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
