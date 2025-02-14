using Assembly.Projecto.Final.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Models
{
    public class Reassign : AuditableEntity<int>
    {
        public int OlderEmployeeId { get; private set; }
        public int NewEmployeeId { get; private set; }
        public int ReassignBy { get; private set; }
        public DateTime ReassignmentDate { get; private set; }
        public int ListingId { get; private set; }
        public Listing Listing { get; private set; }

        private Reassign() 
        {
            OlderEmployeeId = 0;
            NewEmployeeId = 0;
            ReassignBy = 0;
            ReassignmentDate = DateTime.MinValue;
            Created = DateTime.MinValue;
            ListingId = 0;
        }

        private Reassign(int olderEmplyeeId,int newEmployeeId,int reassignBy,DateTime reassigmentDate,
            Listing listing,int listingId):this() 
        {
            OlderEmployeeId = olderEmplyeeId;
            NewEmployeeId = newEmployeeId;
            ReassignBy = reassignBy;
            ReassignmentDate = reassigmentDate;
            Listing = listing;
            ListingId = listingId;
        }

        private Reassign(int id,int olderEmplyeeId, int newEmployeeId, int reassignBy, DateTime reassigmentDate,
            Listing listing, int listingId) : this()
        {
            Id = id;
            Listing = listing;
            ListingId = listingId;
        }

        public static Reassign Create(int olderEmplyeeId, int newEmployeeId, int reassignBy, DateTime reassigmentDate,
             Listing listing, int listingId)
        {
            var reassign = new Reassign(olderEmplyeeId, newEmployeeId, reassignBy, reassigmentDate,listing,listingId);

            return reassign;
        }
        public static Reassign Create(int id,int olderEmplyeeId, int newEmployeeId, int reassignBy, 
            DateTime reassigmentDate, Listing listing, int listingId) 
        { 
            var reassign = new Reassign(id,olderEmplyeeId,newEmployeeId,reassignBy,reassigmentDate,listing, listingId);

            return reassign;
        }

        public void Update(int olderEmplyeeId, int newEmployeeId, int reassignBy, DateTime reassigmentDate,
            Listing listing, int listingId)
        {
            OlderEmployeeId = olderEmplyeeId;
            NewEmployeeId = newEmployeeId;
            ReassignBy = reassignBy;
            ReassignmentDate = reassigmentDate;
            Updated = DateTime.Now;
            Listing = listing;
            ListingId = listingId;
        }
    }
}
