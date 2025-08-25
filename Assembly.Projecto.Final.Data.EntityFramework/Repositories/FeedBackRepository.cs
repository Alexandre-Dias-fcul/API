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
    public class FeedBackRepository : Repository<FeedBack, int>, IFeedBackRepository
    {
        public FeedBackRepository(ApplicationDbContext context) : base(context)
        {
        }

        public FeedBack? Existe(User user, Listing listing)
        {
            return DbSet.Where(f => f.UserId == user.Id && f.ListingId == listing.Id).FirstOrDefault();
        }

        public List<FeedBack> GetByListingId(int idListing)
        {
            return DbSet.Where(f => f.ListingId == idListing).ToList();
        }
    }
}
