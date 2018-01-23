using System.Collections.Generic;
using System.Linq;
using Employee.Business.DTOs;
using Employee.Models;

namespace Employee.Business.Mappers
{
    public class SkillDtoMapper : IMapper<Skill, SkillDto>
    {
        public SkillDto Map(Skill skill)
        {
            return new SkillDto()
            {
                SkillId = skill.Id,
                EmployeeId = skill.EmployeeId,
                Name = skill.Name,
                Category = skill.Category,
            };
        }

        public IEnumerable<SkillDto> Map(IEnumerable<Skill> skills)
        {
           return skills.Select(Map);
        }
    }
}