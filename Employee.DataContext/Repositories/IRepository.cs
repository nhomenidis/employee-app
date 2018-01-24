using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Employee.DataContext.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Insert(T entity);
        Task<bool> InsertMany(IEnumerable<T> entities);
        Task<T> Update(Guid id, T entity);
        Task<bool> Delete(Guid id);
        Task<bool> DeleteAll();
    }
}
