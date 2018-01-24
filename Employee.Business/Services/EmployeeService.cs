using System;
using System.Threading.Tasks;
using Employee.Business.DTOs;
using Employee.Business.Mappers;
using Employee.DataContext.Repositories;

namespace Employee.Business.Services
{
    public interface IEmployeeService : IService<Models.Employee,EmployeeDto>
    {
        Task<EmployeeDto> CreateNewEmployee(CreateEmployeeDto createEmployeeDto);
        Task<EmployeeDto> UpdateEmployee(Guid id, EmployeeDto employeeDto);
    }

    public class EmployeeService : BaseService<Models.Employee,EmployeeDto>, IEmployeeService
    {
        private readonly IMapper<Models.Employee, EmployeeDto> _employeeMapper;
        private readonly IMapper<CreateEmployeeDto, Models.Employee> _createEmployeeMapper;
        private readonly IMapper<EmployeeDto, Models.Employee> _employeeDtoMapper;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(
                                IEmployeeRepository employeeRepository, 
                                IMapper<Models.Employee, EmployeeDto> employeeDtoMapper,
                                IMapper<CreateEmployeeDto,Models.Employee> createEmployeeMapper,
                                IMapper<EmployeeDto, Models.Employee> employeeMapper) : base(employeeRepository, employeeDtoMapper)
        {
            _employeeRepository = employeeRepository;
            _employeeMapper = employeeDtoMapper;
            _createEmployeeMapper = createEmployeeMapper;
            _employeeDtoMapper = employeeMapper;
        }

        public async Task<EmployeeDto> CreateNewEmployee(CreateEmployeeDto createEmployeeDto)
        {
            var newEmployee = _createEmployeeMapper.Map(createEmployeeDto);
            newEmployee = await _employeeRepository.Insert(newEmployee);
            return _employeeMapper.Map(newEmployee);
        }

        public async Task<EmployeeDto> UpdateEmployee(Guid id, EmployeeDto employeeDto)
        {
            employeeDto.EmployeeId = id;
            var mapped = _employeeDtoMapper.Map(employeeDto);
            var updatedEmployee = await _employeeRepository.Update(id, mapped);
            return _employeeMapper.Map(updatedEmployee);
        }
    }
}
