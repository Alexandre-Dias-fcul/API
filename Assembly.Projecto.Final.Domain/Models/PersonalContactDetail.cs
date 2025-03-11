using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Domain.Enums;
using Assembly.Projecto.Final.Domain.Validations;
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
        }

        private PersonalContactDetail(ContactType contactType, string value) : this()
        {
            DomainValidation(contactType, value);
        }

        private PersonalContactDetail(int id, ContactType contactType, string value) : this(contactType, value)
        {
            Id = Id;
        }
        public static PersonalContactDetail Create(ContactType contactType, string value)
        {
            var personalContactDetail = new PersonalContactDetail(contactType, value);

            return personalContactDetail;
        }

        public static PersonalContactDetail Create(int id, ContactType contactType, string value)
        {
            var personalContactDetail = new PersonalContactDetail(id, contactType, value);

            return personalContactDetail;
        }

        public void Update(ContactType contactType, string value)
        {
            DomainValidation(contactType, value);
        }

        public void DomainValidation(ContactType contactType, string value) 
        {
            DomainExceptionValidation.When(value == null,"Erro: o contacto é obrigatório.");
            DomainExceptionValidation.When(value != null && value.Length>300,"Erro: o contacto não pode ter mais de " +
                "300 caracteres.");

            ContactType = contactType;
            Value = value;
        }

        public void SetPersonalContact(PersonalContact personalContact) 
        {
            PersonalContact = personalContact;
            PersonalContactId = personalContact.Id;
        }
    }
}
