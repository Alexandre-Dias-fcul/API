using Assembly.Projecto.Final.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Core.Repositories
{
    public interface IRepository<TEntity, TId> where TEntity : IEntity<TId>
    {
        List<TEntity> GetAll();

        TEntity GetById(TId id);

        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);

        TEntity Delete(TEntity entity);

        TEntity Delete(TId id);
    }
}
