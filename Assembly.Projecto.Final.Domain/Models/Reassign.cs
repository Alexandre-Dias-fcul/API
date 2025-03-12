using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Domain.Validations;
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
        }

        private Reassign(int olderEmplyeeId,int newEmployeeId,int reassignBy,DateTime reassigmentDate):this() 
        {
            DomainValidation(olderEmplyeeId, newEmployeeId, reassignBy, reassigmentDate);
        }

        private Reassign(int id,int olderEmplyeeId, int newEmployeeId, int reassignBy, DateTime reassigmentDate) 
            : this()
        {
            Id = id;
        }

        public static Reassign Create(int olderEmplyeeId, int newEmployeeId, int reassignBy, DateTime reassigmentDate)
        {
            var reassign = new Reassign(olderEmplyeeId, newEmployeeId, reassignBy, reassigmentDate);

            return reassign;
        }
        public static Reassign Create(int id,int olderEmplyeeId, int newEmployeeId, int reassignBy, 
            DateTime reassigmentDate) 
        { 
            var reassign = new Reassign(id,olderEmplyeeId,newEmployeeId,reassignBy,reassigmentDate);

            return reassign;
        }

        public void Update(int olderEmplyeeId, int newEmployeeId, int reassignBy, DateTime reassigmentDate)
        {
            DomainValidation(olderEmplyeeId, newEmployeeId, reassignBy, reassigmentDate);
        }

        public void DomainValidation(int olderEmplyeeId, int newEmployeeId, int reassignBy, DateTime reassigmentDate) 
        {
            DomainExceptionValidation.When(olderEmplyeeId  == 0,"Erro: o valor é obrigatório.");
            DomainExceptionValidation.When(newEmployeeId == 0, "Erro: o valor é obrigatório.");
            DomainExceptionValidation.When(reassignBy == 0, "Erro: o valor é obrigatório.");
            DomainExceptionValidation.When(reassigmentDate>DateTime.Now, "Erro: o data não pode ser maior que a data" +
                "atual.");

            OlderEmployeeId = olderEmplyeeId;
            NewEmployeeId = newEmployeeId;
            ReassignBy = reassignBy;
            ReassignmentDate = reassigmentDate;
        }
        public void SetListing(Listing listing) 
        {
            if(listing == null) 
            {
                throw new ArgumentNullException();
            }

            Listing = listing;
            ListingId = listing.Id;
        }
    }
}
