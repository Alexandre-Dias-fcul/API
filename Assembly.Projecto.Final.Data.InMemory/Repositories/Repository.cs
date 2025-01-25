using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Interfaces;
using Assembly.Projecto.Final.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Data.InMemory.Repositories
{
    public class Repository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : IEntity<TId>
    {

        private readonly List<TEntity> _db;

        private int _currentIntId = 1;

        public Repository(List <TEntity> db)
        {
            _db = db;
        }

        public TEntity Add(TEntity obj)
        {
            obj.Id = GenerateId();

            _db.Add(obj);

            return obj;
        }

        public TEntity Delete(TEntity obj)
        {
            Delete(obj.Id);

            return obj;
        }

        public TEntity Delete(TId id)
        {
            var entity = GetById(id);

            if (entity != null)
            {
                _db.Remove(entity);
            }

            return entity;
        }

        public List<TEntity> GetAll()
        {
            return _db;
        }

        public TEntity GetById(TId id)
        {
            return _db.Find(item => item.Id.Equals(id));
        }

        public TEntity Update(TEntity obj)
        {
            var exists = GetById(obj.Id);

            if (exists != null)
            {
                var index = _db.IndexOf(exists);

                _db[index] = obj;
            }

            return obj;
        }

        private TId GenerateId() 
        {
            if (typeof(TId) == typeof(int)) 
            {
                return (TId)(object)_currentIntId++;
            }
             else if(typeof(TId) ==typeof(Guid))
            {
                return (TId)(object) Guid.NewGuid();
            }

            throw new NotSupportedException("O tipo de ID não é suportado para geração automática.");
        }
    }
}
