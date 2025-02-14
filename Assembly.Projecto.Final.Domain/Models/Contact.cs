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
        public int EntityLinkId { get; private set; }
        public EntityLink EntityLink { get; private set; }

        private Contact()
        {
            ContactType = 0;
            Value = string.Empty;
            EntityLinkId = 0;
            Created = DateTime.Now;
        }

        private Contact(ContactType contactType, string value, EntityLink entityLink, int entityLinkId) : this()
        {
            ContactType = contactType;
            Value = value;
            EntityLink = entityLink;
            EntityLinkId = entityLinkId;
        }

        private Contact(int id, ContactType contactType, string value, EntityLink entityLink, int entityLinkId) : 
            this(contactType, value,entityLink,entityLinkId)
        {
            Id = Id;
        }
        public static Contact Create(ContactType contactType, string value, EntityLink entityLink, int entityLinkId)
        {
            var contact = new Contact(contactType, value, entityLink, entityLinkId);

            return contact;
        }

        public static Contact Create(int id, ContactType contactType, string value, EntityLink entityLink, 
            int entityLinkId)
        {
            var contact = new Contact(id, contactType, value,entityLink, entityLinkId);

            return contact;
        }

        public void Update(ContactType contactType, string value, EntityLink entityLink, int entityLinkId)
        {
            ContactType = contactType;
            Value = value;
            EntityLink = entityLink;
            EntityLinkId = entityLinkId;
            Updated = DateTime.Now;
        }
    }
}
