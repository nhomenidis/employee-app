using System.Collections.Generic;
using System.Linq;
using Employee.Business.DTOs;

namespace Employee.Business.Mappers
{
    public class EmployeeDtoMapper : IMapper<Models.Employee,EmployeeDto>
    {
        public EmployeeDto Map(Models.Employee employee)
        {
            return new EmployeeDto()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Address = employee.Address,
                DateOfBirth = employee.DateOfBirth
            };
        }

        public IEnumerable<EmployeeDto> Map(IEnumerable<Models.Employee> employees)
        {
            return employees.Select(Map);
        }
    }
}
