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
    public class Contact: AuditableEntity<int>
    {
        public ContactType ContactType { get; private set; }
        public string Value { get; private set; }
        public int EntityLinkId { get; private set; }
        public EntityLink EntityLink { get; private set; }

        private Contact()
        {
            ContactType = 0;
            Value = string.Empty;
            EntityLinkId = 0;
        }

        private Contact(ContactType contactType, string value) : this()
        {
            DomainValidation(contactType, value);
        }

        private Contact(int id, ContactType contactType, string value) : 
            this(contactType, value)
        {
            Id = Id;
        }
        public static Contact Create(ContactType contactType, string value)
        {
            var contact = new Contact(contactType, value);

            return contact;
        }

        public static Contact Create(int id, ContactType contactType, string value)
        {
            var contact = new Contact(id, contactType, value);

            return contact;
        }

        public void Update(ContactType contactType, string value)
        {
            DomainValidation(contactType, value);
        }

        public void DomainValidation(ContactType contactType, string value) 
        {
            DomainExceptionValidation.When(value == null, "Erro: o valor do contacto é obrigatório.");
            DomainExceptionValidation.When(value != null && value.Length > 300, "Erro: o valor do contacto não pode" +
                "ter mais de 300 caracteres.");

            ContactType = contactType;
            Value = value;
        }
        public void SetEntityLink(EntityLink entityLink) 
        {
            DomainExceptionValidation.When(entityLink == null, 
                $"Erro: Não foi encontrada a entidade {nameof(entityLink)}.");

            EntityLink = entityLink;
            EntityLinkId = entityLink.Id;
        }
    }
}
