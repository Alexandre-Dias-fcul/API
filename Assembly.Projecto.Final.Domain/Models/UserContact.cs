using Assembly.Projecto.Final.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Models
{
    public class UserContact: AuditableEntity<int>
    {
        public string ContactType { get; private set; }
        public string Value { get; private set; }

        private UserContact() 
        { 
            ContactType = string.Empty;
            Value = string.Empty;
            Created = DateTime.Now;
        }

        private UserContact(string contactType, string value):this()
        {
            ContactType = contactType;
            Value = value;
        }

        private UserContact(int id,string contactType, string value) : this(contactType,value)
        {
            Id = Id;
        }
        public static UserContact Create(string contactType, string value)
        { 
            var userContact = new UserContact(contactType,value);

            return userContact;
        }

        public static UserContact Create(int id,string contactType, string value)
        {
            var userContact = new UserContact(id,contactType, value);

            return userContact;
        }


        public void Update(string contactType, string value)
        { 
            ContactType = contactType;
            Value = value;
            Updated = DateTime.Now;
        }
    }
}
