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

        private Favorite() 
        {
            UserId = 0;
            ListingId = 0;
        }   
        private Favorite(User user, Listing listing):this()
        { 
            if(user == null || listing == null) 
            {
                throw new ArgumentNullException();
            }

            User = user;
            UserId = user.Id;
            Listing = listing;
            ListingId = listing.Id;
        }

        private Favorite(int id,User user,Listing listing) :
            this(user,listing)
        { 
            Id = id;   
        }

        public static Favorite Create(User user, Listing listing) 
        { 
            return new Favorite(user, listing);
        }

        public static Favorite Create(int id, User user, Listing listing)
        {
            return new Favorite(id, user, listing);
        }

        public void Update(User user, Listing listing) 
        {
            User = user;
            UserId = user.Id;
            Listing = listing;
            ListingId = listing.Id;
        }
    }
}
