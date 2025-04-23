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
    public class ListingRepository : Repository<Listing, int>, IListingRepository
    {
        public ListingRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Listing? GetByIdWithAll(int id)
        {
            return DbSet
                .Include(x => x.Favorites)
                .Include(x => x.FeedBacks)
                .Include(x => x.Reassigns)
                .FirstOrDefault(x => x.Id == id);
        }

    }
}
