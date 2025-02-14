using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Models
{
    public class PersonalContactDetail : AuditableEntity<int>
    {
        public ContactType ContactType { get; private set; }
        public string Value { get; private set; }
        public int PersonalContactId { get; private set; }
        public PersonalContact PersonalContact { get; private set; }

        private PersonalContactDetail()
        {
            ContactType = 0;
            Value = string.Empty;
            Created = DateTime.Now;
            PersonalContactId = 0;
        }

        private PersonalContactDetail(ContactType contactType, string value, PersonalContact personalContact,
            int personalContactId) : this()
        {
            ContactType = contactType;
            Value = value;
            PersonalContact = personalContact;
            PersonalContactId = personalContactId;
        }

        private PersonalContactDetail(int id, ContactType contactType, string value, PersonalContact personalContact,
            int personalContactId) : this(contactType, value, personalContact,personalContactId)
        {
            Id = Id;
        }
        public static PersonalContactDetail Create(ContactType contactType, string value, PersonalContact personalContact,
            int personalContactId)
        {
            var personalContactDetail = new PersonalContactDetail(contactType, value, personalContact, personalContactId);

            return personalContactDetail;
        }

        public static PersonalContactDetail Create(int id, ContactType contactType, string value, 
            PersonalContact personalContact,int personalContactId)
        {
            var personalContactDetail = new PersonalContactDetail(id, contactType, value, personalContact, 
                personalContactId);

            return personalContactDetail;
        }

        public void Update(ContactType contactType, string value, PersonalContact personalContact, int personalContactId)
        {
            ContactType = contactType;
            Value = value;
            Updated = DateTime.Now;
            PersonalContact = personalContact;
            PersonalContactId = personalContactId;
        }
    }
}
