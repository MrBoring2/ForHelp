using System;
using System.Collections.Generic;

namespace WebApplication10
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RoleId { get; set; }
        public string PassportNumber { get; set; } = null!;
        public string PassportSeries { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual Administrator Administrator { get; set; } = null!;
        public virtual Doctor Doctor { get; set; } = null!;
    }
}
