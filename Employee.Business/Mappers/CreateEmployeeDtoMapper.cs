using System.Collections.Generic;
using Employee.Business.DTOs;

namespace Employee.Business.Mappers
{
    public class CreateEmployeeDtoMapper : IMapper<CreateEmployeeDto, Models.Employee>
    {
        public Models.Employee Map(CreateEmployeeDto employeeDto)
        {
            return new Models.Employee()
            {
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Email = employeeDto.Email,
                Address = employeeDto.Address,
                DateOfBirth = employeeDto.DateOfBirth,
            };
        }

        public IEnumerable<Models.Employee> Map(IEnumerable<CreateEmployeeDto> inputs)
        {
            throw new System.NotImplementedException();
        }
    }
}