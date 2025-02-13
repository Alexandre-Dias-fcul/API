using Assembly.Projecto.Final.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Models
{
    public class FeedBack:AuditableEntity<int>
    {
        public int? Rate {  get; private set; }

        public string Comment { get; private set; }

        public DateTime? CommentDate { get; private set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ListingId { get; set; }
        public Listing Listing { get; set; }

        private FeedBack() 
        {
            Rate = 0;
            Comment = string.Empty;
            CommentDate = DateTime.MinValue;
            Created = DateTime.Now;
        }

        private FeedBack(int rate,string comment,DateTime commentDate):this()
        {
            Rate = rate;
            Comment = comment;
            CommentDate = commentDate;
        }

        private FeedBack(int id, int rate, string comment, DateTime commentDate)
        { 
            Id = id;    
        }

        public static FeedBack Create(int rate, string comment, DateTime commentDate)
        {
            var feedback = new FeedBack(rate, comment, commentDate);

            return feedback;
        }
        public static FeedBack Create(int id,int rate, string comment, DateTime commentDate) 
        {
            var feedback = new FeedBack(id,rate,comment,commentDate);

            return feedback;
        }

        public void Update(int rate, string comment, DateTime commentDate) 
        {
            Rate = rate;
            Comment = comment;
            CommentDate = commentDate;
            Updated = DateTime.Now;
        }
    }
}
