using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Data.InMemory.Repositories
{
    public class Repository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : IEntity<TId>
    {
        public TEntity Add(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public TEntity Delete(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public TEntity Delete(TId id)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(TId id)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
