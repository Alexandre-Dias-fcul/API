using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Data.InMemory.Repositories
{
    public class AgentRepository:Repository<Agent,int>,IAgentRepository
    {
        private readonly Database _db;
        public AgentRepository(Database db):base(db.Agents)
        {
            _db = db;
        }

        public List<Agent> GetAllInclude()
        {
            throw new NotImplementedException();
        }

        public List<Agent> GetAllListingByEmployeeId(int idEmployee)
        {
            throw new NotImplementedException();
        }

        public List<Agent> GetAllManagerAgents(int idManager)
        {
            throw new NotImplementedException();
        }

        public Agent? GetByIdInclude(int id)
        {
            throw new NotImplementedException();
        }
    }
}
