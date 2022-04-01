using System;
using System.Collections.Generic;

namespace WebApplication10
{
    public partial class Administrator
    {
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
    }
}
