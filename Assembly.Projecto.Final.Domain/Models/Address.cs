using Assembly.Projecto.Final.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Models
{
    public class Address: AuditableEntity<int>
    {
        public string Street { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string PostalCode { get; private set; }
        public List<EntityLink> EntityLinks { get; set; }

        private Address()
        {
            Street = string.Empty;
            City = string.Empty;
            Country = string.Empty;
            PostalCode = string.Empty;
            Created = DateTime.Now;
        }

        private Address(string street, string city, string country, string postalCode) : this()
        {
            Street = street;
            City = city;
            Country = country;
            PostalCode = postalCode;
        }

        private Address(int id, string street, string city, string country, string postalCode) :
            this(street, city, country, postalCode)
        {
            Id = id;
        }
        public static Address Create(string street, string city, string country, string postalCode)
        {
            var address = new Address(street, city, country, postalCode);

            return address;
        }

        public static Address Create(int id, string street, string city, string country, string postalCode)
        {
            var address = new Address(id, street, city, country, postalCode);

            return address;
        }

        public void Update(string street, string city, string country, string postalCode)
        {
            Street = street;
            City = city;
            Country = country;
            PostalCode = postalCode;
            Updated = DateTime.Now;
        }
    }
}
