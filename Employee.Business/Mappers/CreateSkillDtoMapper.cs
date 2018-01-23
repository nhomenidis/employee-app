using System.Collections.Generic;
using System.Linq;
using Employee.Business.DTOs;
using Employee.Models;

namespace Employee.Business.Mappers
{
    public class CreateSkillDtoMapper : IMapper<CreateSkillDto, Skill>
    {
        public Skill Map(CreateSkillDto createSkillDto)
        {
            return new Skill()
            {
                EmployeeId = createSkillDto.EmployeeId,
                Name = createSkillDto.Name,
                Category = createSkillDto.Category,
            };
        }

        public IEnumerable<Skill> Map(IEnumerable<CreateSkillDto> createSkillDtos)
        {
            return createSkillDtos.Select(Map);
        }
    }
}