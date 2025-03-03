using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Interfaces
{
    public interface IServiceProvisorio <TEntity,TEntityId, TId> where TEntity : class
    {
        List<TEntityId> GetAll();

        TEntityId GetById(TId id);

        TEntity Add(TEntity obj);

        TEntityId Update(TEntityId obj);

        TEntityId Delete(TEntityId obj);

        TEntityId Delete(TId id);
    }
}
