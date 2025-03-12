using Assembly.Projecto.Final.Domain.Core.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assembly.Projecto.Final.Data.EntityFramework.Context;

namespace Assembly.Projecto.Final.Data.EntityFramework.UOW
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IDbContextTransaction _dbContextTransaction;
        public IUserRepository UserRepository { get; set; }
        
        public UnitOfWork(ApplicationDbContext context,IUserRepository userRepository) 
        {
            _context = context;
            UserRepository = userRepository;
        }
        public void BeginTransaction()
        {
            _dbContextTransaction = _context.Database.BeginTransaction();
        }

        public bool Commit()
        {
            bool commited = false;
            try
            {
                var affectedRows = _context.SaveChanges();
                _dbContextTransaction.Commit();
                return affectedRows != 0;
            }
            catch
            {
                _dbContextTransaction.Rollback();
            }
            finally
            {
                Dispose();
            }

            return commited;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
