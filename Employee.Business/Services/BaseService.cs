using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Employee.Business.Mappers;
using Employee.DataContext.Repositories;

namespace Employee.Business.Services
{
    public abstract class BaseService<T, TOutput> : IService<T, TOutput> where T : class
    {
        private readonly IRepository<T> _repository;
        private readonly IMapper<T, TOutput> _mapper;

        protected BaseService(IRepository<T> repository, IMapper<T, TOutput> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TOutput> GetEntity(Guid id)
        {
            var entity = await _repository.GetById(id);
            var entityDto = _mapper.Map(entity);
            return entityDto;
        }

        public async Task<IEnumerable<TOutput>> GetAllEntities()
        {
            var entities = await _repository.GetAll();
            var entitiesDto = _mapper.Map(entities);
            return entitiesDto;
        }

        public async Task<TOutput> CreateEntity(T entity)
        {
            var createEntity = await _repository.Insert(entity);
            var createEntityDto = _mapper.Map(createEntity);
            return createEntityDto;
        }

        public async Task<bool> DeleteEntity(Guid id)
        {
            var deleteEntity = await _repository.Delete(id);
            return deleteEntity;
        }

        public async Task<bool> DeleteAllEntities()
        {
            var result = await _repository.DeleteAll();
            return result;
        }

        public async Task<bool> InsertMany(IEnumerable<T> entities)
        {
            var result = await _repository.InsertMany(entities);
            return result;
        }
    }
}
