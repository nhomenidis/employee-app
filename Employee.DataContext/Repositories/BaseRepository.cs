using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Employee.DataContext.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class 
    {
        protected DbSet<T> DbSet { get; private set; }
        protected EmployeeDataContext EmployeeDataContext { get; private set; }

        protected BaseRepository(EmployeeDataContext employeeDataContext)
        {
            EmployeeDataContext = employeeDataContext;
            DbSet = employeeDataContext.Set<T>();
        }

        public virtual Task<T> GetById(Guid id)
        {
            return DbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<T> Insert(T entity)
        {
            var result = DbSet.Add(entity);
            await EmployeeDataContext.SaveChangesAsync();
            return result.Entity;
        }

        public virtual async Task<T> Update(Guid id, T entity)
        {
            var result = await EmployeeDataContext.FindAsync<T>(id);
            EmployeeDataContext.Entry(result).CurrentValues.SetValues(entity);
            await EmployeeDataContext.SaveChangesAsync();
            return result;
        }

        public virtual async Task<bool> Delete(Guid id)
        {
            var entity = await DbSet.FindAsync(id);
            DbSet.Remove(entity);
            await EmployeeDataContext.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> DeleteAll()
        {
           EmployeeDataContext.RemoveRange(DbSet);
           await EmployeeDataContext.SaveChangesAsync();
           return true;
        }

        public virtual async Task<bool> InsertMany(IEnumerable<T> entities)
        {
            DbSet.AddRange(entities);
            await EmployeeDataContext.SaveChangesAsync();
            return true;
        }
    }
}
