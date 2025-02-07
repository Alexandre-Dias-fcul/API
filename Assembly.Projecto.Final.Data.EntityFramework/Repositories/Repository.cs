using Assembly.Projecto.Final.Data.EntityFramework.Context;
using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Interfaces;
using Assembly.Projecto.Final.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Data.EntityFramework.Repositories
{
    public class Repository<TEntity,TId>: IRepository<TEntity,TId> where TEntity : class ,IEntity<TId>
    {
        private readonly ApplicationDbContext _dbContext;

        protected readonly DbSet<TEntity> DbSet;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = _dbContext.Set<TEntity>();
        }
        public List<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public TEntity? GetById(TId id)
        {
            return DbSet.Find(id);
        }

        public TEntity Add(TEntity obj)
        {
            var entity = DbSet.Add(obj).Entity;
            _dbContext.SaveChanges();
            return entity;
        }

        public TEntity Update(TEntity obj)
        {
            DbSet.Update(obj);
            _dbContext.SaveChanges();
            return obj;
        }

        public TEntity Delete(TEntity obj)
        {
            DbSet.Remove(obj);
            _dbContext.SaveChanges();
            return obj;
        }

        public TEntity? Delete(TId id)
        {
            var obj = GetById(id);

            if (obj != null)
            {
                Delete(obj);

                return obj;
            }

            return null;
        }
    }
}
