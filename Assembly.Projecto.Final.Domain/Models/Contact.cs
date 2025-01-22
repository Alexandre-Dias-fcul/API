using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Domain.Enums;
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

        private Contact()
        {
            ContactType = 0;
            Value = string.Empty;
            Created = DateTime.Now;
        }

        private Contact(ContactType contactType, string value) : this()
        {
            ContactType = contactType;
            Value = value;
        }

        private Contact(int id, ContactType contactType, string value) : this(contactType, value)
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
            ContactType = contactType;
            Value = value;
            Updated = DateTime.Now;
        }
    }
}
