using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        //navigation property
        public virtual ICollection<Skill> Skills { get; set; }
    }
}
