using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Business.DTOs
{
    public class SkillDto
    {
        public Guid SkillId { get; set; }
        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
    }
}
