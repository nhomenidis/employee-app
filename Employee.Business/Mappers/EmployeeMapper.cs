using System.Collections.Generic;
using System.Linq;
using Employee.Business.DTOs;

namespace Employee.Business.Mappers
{
    public class EmployeeMapper : IMapper<EmployeeDto, Models.Employee>
    {
        public Models.Employee Map(EmployeeDto employeeDto)
        {
            return new Models.Employee()
            {
                Id = employeeDto.EmployeeId,
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Email = employeeDto.Email,
                Address = employeeDto.Address,
                DateOfBirth = employeeDto.DateOfBirth
            };
        }

        public IEnumerable<Models.Employee> Map(IEnumerable<EmployeeDto> employeeDtos)
        {
            return employeeDtos.Select(Map);
        }
    }
}
