using Assembly.Projecto.Final.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Models
{
    public class Favorite : AuditableEntity<int>
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ListingId { get; set; }
        public Listing Listing { get; set; }
        private Favorite()
        {

        }

        private Favorite(int id) 
        { 
        }

        public static Favorite Create() 
        { 
            return new Favorite();
        }

        public static Favorite Create(int id)
        {
            return new Favorite(id);
        }
    }
}
