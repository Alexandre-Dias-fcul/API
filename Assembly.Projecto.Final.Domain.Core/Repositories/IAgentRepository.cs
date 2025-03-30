
using Assembly.Projecto.Final.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Core.Repositories
{
    public interface IAgentRepository:IRepository<Agent,int>
    {
        public Agent? GetByIdWithAddresses(int id);

        public Agent? GetByIdWithAccount(int id);

        public Agent? GetByIdWithContacts(int id);

        public Agent? GetByIdWithAll(int id);
    }
}
