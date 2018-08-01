using Cedro.Domain.Interfaces.Domain.Services;
using Cedro.Domain.Interfaces.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedro.Domain.Services
{
    public class CedroService<TEntity, TRepository, TKeyType> : IService<TEntity, TKeyType>
        where TEntity : class
        where TRepository : IRepository<TEntity,TKeyType>
    {
        TRepository repository;
        public CedroService(TRepository _repository)
        {
            repository = _repository;
        }
        public void Add(TEntity entity)
        {
            repository.Add(entity);
        }

        public void Delete(TKeyType id)
        {
            repository.Delete(id);
        }

        public IEnumerable<TEntity> SelectAll()
        {
            return repository.SelectAll();
        }

        public TEntity SelectById(TKeyType id)
        {
            return repository.SelectById(id);
        }

        public void Update(TEntity entity)
        {
            repository.Update(entity);
        }
    }
}
