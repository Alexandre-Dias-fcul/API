using Assembly.Projecto.Final.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Models
{
    public class Contact: AuditableEntity<int>
    {
        public string ContactType { get; private set; }
        public string Value { get; private set; }

        private Contact()
        {
            ContactType = string.Empty;
            Value = string.Empty;
            Created = DateTime.Now;
        }

        private Contact(string contactType, string value) : this()
        {
            ContactType = contactType;
            Value = value;
        }

        private Contact(int id, string contactType, string value) : this(contactType, value)
        {
            Id = Id;
        }
        public static Contact Create(string contactType, string value)
        {
            var contact = new Contact(contactType, value);

            return contact;
        }

        public static Contact Create(int id, string contactType, string value)
        {
            var contact = new Contact(id, contactType, value);

            return contact;
        }

        public void Update(string contactType, string value)
        {
            ContactType = contactType;
            Value = value;
            Updated = DateTime.Now;
        }
    }
}
