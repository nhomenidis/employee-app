using System;
using System.Collections.Generic;
using System.Text;
using Employee.Business.DTOs;
using Employee.Models;

namespace Employee.Business.Mappers
{
    public class SkillMapper : IMapper<SkillDto, Skill>
    {
        public Skill Map(SkillDto skillDto)
        {
            return  new Skill()
            {
                Name = skillDto.Name,
                Category = skillDto.Category,
                Id = skillDto.SkillId,
                EmployeeId = skillDto.EmployeeId
            };
        }

        public IEnumerable<Skill> Map(IEnumerable<SkillDto> inputs)
        {
            throw new NotImplementedException();
        }
    }
}
