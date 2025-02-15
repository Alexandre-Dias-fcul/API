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

        private readonly List<TEntity> _dbSet;

        private int _currentIntId = 1;

        public Repository(List <TEntity> dbSet)
        {
            _dbSet = dbSet;
        }

        public TEntity Add(TEntity obj)
        {
            /*obj.Id = GenerateId();*/

            _dbSet.Add(obj);

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
                _dbSet.Remove(entity);
            }

            return entity;
        }

        public List<TEntity> GetAll()
        {
            return _dbSet;
        }

        public TEntity GetById(TId id)
        {
            return _dbSet.Find(item => item.Id.Equals(id));
        }

        public TEntity Update(TEntity obj)
        {
            var exists = GetById(obj.Id);

            if (exists != null)
            {
                var index = _dbSet.IndexOf(exists);

                _dbSet[index] = obj;
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

            throw new NotSupportedException("O tipo de Id não é suportado.");
        }
    }
}
