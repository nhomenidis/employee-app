using System;
using System.ComponentModel.DataAnnotations;
using Employee.Business.Validators;

namespace Employee.Business.DTOs
{
    public class EmployeeDto
    {
        public Guid EmployeeId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [Age(18)]
        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}
