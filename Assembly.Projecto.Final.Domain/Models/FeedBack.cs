using Assembly.Projecto.Final.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Models
{
    public class FeedBack:AuditableEntity<int>
    {
        public int? Rate {  get; private set; }

        public string Comment { get; private set; }

        public DateTime? CommentDate { get; private set; }
        public int UserId { get; private set; }
        public User User { get; private set; }
        public int ListingId { get; private set; }
        public Listing Listing { get; private set; }

        private FeedBack() 
        {
            Rate = 0;
            Comment = string.Empty;
            CommentDate = DateTime.MinValue;
            ListingId = 0;
            UserId = 0;
            Created = DateTime.Now;
        }

        private FeedBack(int rate,string comment,DateTime commentDate,User user,int userId,Listing listing,int listingId)
            :this()
        {
            Rate = rate;
            Comment = comment;
            CommentDate = commentDate;
            User = user;
            UserId=userId;
            Listing = listing;
            ListingId = listingId;
        }

        private FeedBack(int id, int rate, string comment, DateTime commentDate, User user, int userId, Listing listing,
            int listingId):this(rate, comment,commentDate,user,userId,listing,listingId)
        { 
            Id = id;    
        }

        public static FeedBack Create(int rate, string comment, DateTime commentDate,User user, int userId, 
            Listing listing, int listingId)
        {
            var feedback = new FeedBack(rate, comment, commentDate,user, userId, listing, listingId);

            return feedback;
        }
        public static FeedBack Create(int id,int rate, string comment, DateTime commentDate, User user, int userId,
            Listing listing, int listingId) 
        {
            var feedback = new FeedBack(id,rate,comment,commentDate, user, userId, listing, listingId);

            return feedback;
        }

        public void Update(int rate, string comment, DateTime commentDate, User user, int userId, Listing listing, 
            int listingId) 
        {
            Rate = rate;
            Comment = comment;
            CommentDate = commentDate;
            User = user;
            UserId = userId;
            Listing = listing;
            ListingId = listingId;
            Updated = DateTime.Now;
        }
    }
}
