using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.Business.DTOs;
using Employee.Business.Mappers;
using Employee.DataContext.Repositories;
using Employee.Models;

namespace Employee.Business.Services
{
    public interface ISkillService : IService<Skill, SkillDto>
    {
        Task<SkillDto> CreateNewSkill(CreateSkillDto createSkillDto);
        Task<bool> CreateManyNewSkills(IEnumerable<CreateSkillDto> createSkillDtos);
        Task<IEnumerable<SkillDto>> GetSkillsByEmployeeId(Guid emplloyeeId);
        Task<SkillDto> UpdateSkill(Guid id, SkillDto skillDto);
    }

    public class SkillService : BaseService<Skill,SkillDto>, ISkillService
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper<Skill, SkillDto> _skillMapper;
        private readonly IMapper<CreateSkillDto, Skill> _createSkillMapper;
        private readonly IMapper<SkillDto, Skill> _skillDtoMapper;

        public SkillService(
                            ISkillRepository skillRepository,
                            IEmployeeRepository employeeRepository,
                            IMapper<Skill, SkillDto> skillMapper,
                            IMapper<SkillDto, Skill> skillDtoMapper,
                            IMapper<CreateSkillDto, Skill> createSkillMapper) : base(skillRepository, skillMapper)
        {
            _skillRepository = skillRepository;
            _employeeRepository = employeeRepository;
            _skillMapper = skillMapper;
            _createSkillMapper = createSkillMapper;
            _skillDtoMapper = skillDtoMapper;
        }

        public async Task<SkillDto> CreateNewSkill(CreateSkillDto createSkillDto)
        {
            var employee = await _employeeRepository.GetById(createSkillDto.EmployeeId);
            if (employee == null)
            {
                return null;
            }
            var newSkill = _createSkillMapper.Map(createSkillDto);
            newSkill.Employee = employee;
            newSkill = await _skillRepository.Insert(newSkill);

            return _skillMapper.Map(newSkill);
        }

        public async Task<bool> CreateManyNewSkills(IEnumerable<CreateSkillDto> createSkillDtos)
        {
            var skill = _createSkillMapper.Map(createSkillDtos.First()); // find the first skill of the sequence in order to grab the EmployeeId

            var employee = await _employeeRepository.GetById(skill.EmployeeId);
            if (employee == null)
            {
                return false;
            }

            var newSkills = _createSkillMapper.Map(createSkillDtos);

            foreach (var newSkill in newSkills) // pass all the skills to a single Employee
            {
                newSkill.Employee = employee;
            }

            var result = await _skillRepository.InsertMany(newSkills);
            return result;
        }

        public async Task<IEnumerable<SkillDto>> GetSkillsByEmployeeId(Guid emplloyeeId)
        {
            var skills = await  _skillRepository.GetSkillsByEmployeeId(emplloyeeId);
            return _skillMapper.Map(skills);
        }

        public async Task<SkillDto> UpdateSkill(Guid id, SkillDto skillDto)
        {
            skillDto.SkillId = id;
            var mapped = _skillDtoMapper.Map(skillDto);
            var updatedSkill = await _skillRepository.Update(id, mapped);
            return _skillMapper.Map(updatedSkill);
        }
    }
}
