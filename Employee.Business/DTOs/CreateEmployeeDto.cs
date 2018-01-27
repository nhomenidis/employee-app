using System;
using System.ComponentModel.DataAnnotations;
using Employee.Business.Validators;

namespace Employee.Business.DTOs
{
    public class CreateEmployeeDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        [Age(18)]
        public DateTime BirthDate { get; set; }

        public string Address { get; set; }
    }
}
