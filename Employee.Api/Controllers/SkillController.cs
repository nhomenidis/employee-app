using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Employee.Business.DTOs;
using Employee.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Api.Controllers
{
    [Route("/skill")]
    public class SkillController : Controller
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateNewSkill([FromBody]CreateSkillDto createSkillDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newSkillDto = await _skillService.CreateNewSkill(createSkillDto);
            if (newSkillDto == null)
            {
                return NotFound();
            }
            return Ok(newSkillDto);
        }

        [HttpPost("createMany")]
        public async Task<IActionResult> CreateManyNewSkills([FromBody]IEnumerable<CreateSkillDto> createSkillDtos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _skillService.CreateManyNewSkills(createSkillDtos);

            if (result == false)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{SkillId}")]
        public async Task<IActionResult> DeleteSkill(Guid skillId)
        {
            var result = await _skillService.DeleteEntity(skillId);
            return Ok(result);
        }

        [HttpPut("{skillId}")]
        public async Task<IActionResult> Update(Guid skillId, [FromBody]SkillDto skillDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _skillService.UpdateSkill(skillId, skillDto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(Guid id)
        {
            var result = await _skillService.GetEntity(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _skillService.GetAllEntities();
            return Ok(result);
        }
    }
}
