using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee.Business.Services
{
    public interface IService<T, TOutput> where T : class
    {
        Task<TOutput> GetEntity(Guid id);
        Task<IEnumerable<TOutput>> GetAllEntities();
        Task<TOutput> CreateEntity(T entity);
        Task<bool> DeleteEntity(Guid id);
        Task<bool> DeleteAllEntities();
        Task<bool> InsertMany(IEnumerable<T> entities);
    }
}
