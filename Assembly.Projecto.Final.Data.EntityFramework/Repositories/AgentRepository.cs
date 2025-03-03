using Assembly.Projecto.Final.Data.EntityFramework.Context;
using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Data.EntityFramework.Repositories
{
    public class AgentRepository : Repository<Agent, int>, IAgentRepository
    {
        private readonly ApplicationDbContext _context;
        public AgentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Agent> GetAllInclude()
        {
            return _context.Employees.OfType<Agent>().Include(e => e.EntityLink).ThenInclude(c => c.Contacts)
                .Include(e => e.EntityLink).ThenInclude(a => a.Addresses).Include(e => e.EntityLink)
                .ThenInclude(a => a.Account).ToList();
        }

        public Agent? GetByIdInclude(int id) 
        {
            return _context.Employees.OfType<Agent>().Include(e => e.EntityLink).ThenInclude(c => c.Contacts)
                .Include(e => e.EntityLink).ThenInclude(a => a.Addresses).Include(e => e.EntityLink)
                .ThenInclude(a => a.Account).Where(a => a.Id == id).FirstOrDefault();
        }
    }
}
