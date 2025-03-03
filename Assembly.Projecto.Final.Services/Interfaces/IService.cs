using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Interfaces
{
    public interface IService<TEntity,TId> where TEntity: class 
    {
        List<TEntity> GetAll();

        TEntity GetById(TId id);

        TEntity Add(TEntity obj);

        TEntity Update(TEntity obj);

        TEntity Delete(TEntity obj);

        TEntity Delete(TId id);
    }
}
