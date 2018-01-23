using System;
using System.Threading.Tasks;
using Employee.Business.DTOs;
using Microsoft.AspNetCore.Mvc;
using Employee.Business.Services;

namespace Employee.Api.Controllers
{
    [Route("/employee")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ISkillService _skillService;

        public EmployeeController(IEmployeeService employeeService, ISkillService skillService)
        {
            _employeeService = employeeService;
            _skillService = skillService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewEmployee([FromBody]CreateEmployeeDto createEmployeeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var newEmployeeDto = await _employeeService.CreateNewEmployee(createEmployeeDto);
            return Ok(newEmployeeDto);
        }

        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> DeleteEmployee(Guid employeeId)
        {
            var result = await _employeeService.DeleteEntity(employeeId);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(Guid id)
        {
            var result = await _employeeService.GetEntity(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _employeeService.GetAllEntities();
            return Ok(result);
        }

        [HttpGet("{employeeId}/skills")]
        public async Task<IActionResult> GetSkillsByEmployeeId(Guid employeeId)
        {
            var skills = await _skillService.GetSkillsByEmployeeId(employeeId);
            return Ok(skills);
        }
    }
}
