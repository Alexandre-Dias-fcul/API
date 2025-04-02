using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Domain.Validations;
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
        }

        private FeedBack(int? rate,string comment,DateTime? commentDate)
            :this()
        {
            DomainValidation(rate, comment, commentDate);
        }

        private FeedBack(int id, int? rate, string comment, DateTime? commentDate):this(rate, comment,commentDate)
        { 
            Id = id;    
        }

        public static FeedBack Create(int? rate, string comment, DateTime? commentDate)
        {
            var feedback = new FeedBack(rate, comment, commentDate);

            return feedback;
        }
        public static FeedBack Create(int id,int? rate, string comment, DateTime? commentDate) 
        {
            var feedback = new FeedBack(id,rate,comment,commentDate);

            return feedback;
        }

        public void Update(int? rate, string comment, DateTime? commentDate) 
        {
            DomainValidation(rate,comment,commentDate);
        }

        public void DomainValidation(int? rate, string comment, DateTime? commentDate) 
        {
            DomainExceptionValidation.When(comment != null && comment.Length>2000," Erro: o commntário não pode ter " +
                "mais de 2000 caracteres.");
            DomainExceptionValidation.When(commentDate>DateTime.Now," Erro: a data não pode ser maior que a actual.");

            Rate = rate;
            Comment = comment;
            CommentDate = commentDate;
        }
        public void SetUser(User user) 
        {
            DomainExceptionValidation.When(user == null, $"Erro: Não foi encontrada a entidade {nameof(user)}.");

            User = user;
            UserId = User.Id;
        }

        public void SetListing(Listing listing)
        {
            DomainExceptionValidation.When(listing == null, $"Erro: Não foi encontrada a entidade {nameof(listing)}.");

            Listing = listing;
            ListingId = listing.Id;
        }
    }
}
