using Assembly.Projecto.Final.Data.EntityFramework.Context;
using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Data.EntityFramework.Repositories
{
    public class ReassignRepository : Repository<Reassign, int>, IReassignRepository
    {
        public ReassignRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
