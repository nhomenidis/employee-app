using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.DataContext.Repositories
{
    public interface IEmployeeRepository : IRepository<Models.Employee>
    {
        
    }
    public class EmployeeRepository : BaseRepository<Models.Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeDataContext employeeDataContext) : base(employeeDataContext)
        {
        }
    }
}
