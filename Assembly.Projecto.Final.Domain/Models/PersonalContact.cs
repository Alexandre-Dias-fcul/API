using Assembly.Projecto.Final.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Models
{
    public class PersonalContact:AuditableEntity<int>
    {
        public string ContactName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Address { get; private set; }

        private PersonalContact()
        {
            ContactName = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
            Address = string.Empty;
            Created = DateTime.Now;
        }

        private PersonalContact(string contactName, string email, string phoneNumber, string address) : this()
        {
            ContactName = contactName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        private PersonalContact(int id,string contactName, string email, string phoneNumber, string address) : 
            this(contactName,email,phoneNumber,address)
        {
           Id = id;
        }

        public static PersonalContact Create(string contactName, string email, string phoneNumber, string address)
        {
            var personalContact = new PersonalContact(contactName,email,phoneNumber,address);

            return personalContact;
        }

        public static PersonalContact Create(int id,string contactName, string email, string phoneNumber, string address)
        {
            var personalContact = new PersonalContact(id,contactName, email, phoneNumber, address);

            return personalContact;
        }

        public void Update(string contactName, string email, string phoneNumber, string address)
        {
            ContactName = contactName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            Updated = DateTime.Now;
        }
    }
}
