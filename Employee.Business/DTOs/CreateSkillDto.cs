using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;


namespace Employee.Business.DTOs
{
    public class CreateSkillDto
    {
        [Required]
        public Guid EmployeeId { get; set; }

        [Required]
        public string Name { get; set; }
        
        public string Category { get; set; }
    }
}
