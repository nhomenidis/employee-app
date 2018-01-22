using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Models
{
    public class Skill
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; } // for example scientific, social, financial skill.

        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
