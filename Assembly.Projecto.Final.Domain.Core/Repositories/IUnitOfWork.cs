using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Core.Repositories
{
    public interface IUnitOfWork:IDisposable
    {
        public IUserRepository UserRepository { get; }

        void BeginTransaction();

        public bool Commit();
    }
}
