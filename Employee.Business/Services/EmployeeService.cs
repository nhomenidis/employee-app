using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Employee.Business.DTOs;
using Employee.Business.Mappers;
using Employee.DataContext.Repositories;

namespace Employee.Business.Services
{
    public interface IEmployeeService : IService<Models.Employee,EmployeeDto>
    {
        Task<EmployeeDto> CreateNewEmployee(CreateEmployeeDto createEmployeeDto);
    }

    public class EmployeeService : BaseService<Models.Employee,EmployeeDto>, IEmployeeService
    {
        private readonly IMapper<Models.Employee, EmployeeDto> _employeeMapper;
        private readonly IMapper<CreateEmployeeDto, Models.Employee> _createEmployeeMapper;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(
                                IEmployeeRepository employeeRepository, 
                                IMapper<Models.Employee, EmployeeDto> employeeMapper,
                                IMapper<CreateEmployeeDto,Models.Employee> createEmployeeMapper) : base(employeeRepository, employeeMapper)
        {
            _employeeRepository = employeeRepository;
            _employeeMapper = employeeMapper;
            _createEmployeeMapper = createEmployeeMapper;
        }

        public async Task<EmployeeDto> CreateNewEmployee(CreateEmployeeDto createEmployeeDto)
        {
            var newEmployee = _createEmployeeMapper.Map(createEmployeeDto);
            newEmployee = await _employeeRepository.Insert(newEmployee);
            return _employeeMapper.Map(newEmployee);
        }
    }
}
