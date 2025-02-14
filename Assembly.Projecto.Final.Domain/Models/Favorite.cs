using Assembly.Projecto.Final.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Models
{
    public class Favorite : AuditableEntity<int>
    {
        public int UserId { get; private set; }
        public User User { get; private set; }
        public int ListingId { get; private set; }
        public Listing Listing { get; private set; }

        public Favorite() 
        {
            UserId = 0;
            ListingId = 0;
        }   
        private Favorite(User user, int userId, Listing listing, int listingId):this()
        {
            UserId = userId;
            User = user;
            Listing = listing;
            ListingId = listingId;
        }

        private Favorite(int id,User user,int userId,Listing listing,int listingId) :
            this(user,userId,listing,listingId)
        { 
            Id = id;   
        }

        public static Favorite Create(User user, int userId, Listing listing, int listingId) 
        { 
            return new Favorite(user, userId, listing, listingId);
        }

        public static Favorite Create(int id, User user, int userId, Listing listing, int listingId)
        {
            return new Favorite(id, user, userId, listing, listingId);
        }

        public void Update(User user, int userId, Listing listing, int listingId) 
        {
            UserId = userId;
            User = user;
            Listing = listing;
            ListingId = listingId;
        }
    }
}
