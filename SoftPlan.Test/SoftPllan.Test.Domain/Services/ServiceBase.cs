using SoftPllan.Test.Domain.Interfaces.Repositories;
using SoftPllan.Test.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoftPllan.Test.Domain.Services
{
        public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
        {
            private readonly IRepositoryBase<TEntity> _repository;

            public ServiceBase(IRepositoryBase<TEntity> repository)
            {
                _repository = repository;
            }

            public void Add(TEntity obj)
            {
                _repository.Add(obj);
            }

            public void Dispose()
            {
                _repository.Dispose();
            }

            public IEnumerable<TEntity> GetAll()
            {
                return _repository.GetAll();
            }

            public TEntity GetById(int id)
            {
                return _repository.GetById(id);
            }

            public void Remove(TEntity obj)
            {
                _repository.Remove(obj);
            }

            public void Update(TEntity obj)
            {
                _repository.Update(obj);
            }
        }
    }
