using System;
using System.Collections.Generic;
using System.Text;
using Employee.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Employee.DataContext.Repositories
{
    public interface ISkillRepository : IRepository<Skill>
    {
        Task<IEnumerable<Skill>> GetSkillsByEmployeeId(Guid employeeId);
    }
    public class SkillRepository : BaseRepository<Skill>, ISkillRepository
    {
        public SkillRepository(EmployeeDataContext employeeDataContext) : base(employeeDataContext)
        {
        }

        public async Task<IEnumerable<Skill>> GetSkillsByEmployeeId(Guid employeeId)
        {
            var skills = await DbSet
                .Where(s => s.Employee.Id == employeeId)
                .ToListAsync();

            return skills;
        }
    }
}
