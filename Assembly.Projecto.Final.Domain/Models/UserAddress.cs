using Assembly.Projecto.Final.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Models
{
    public class UserAddress: AuditableEntity<int>
    {
        public string Street { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string PostalCode { get; private set; }

        private UserAddress() 
        {
            Street = string.Empty;
            City = string.Empty;
            Country = string.Empty;
            PostalCode = string.Empty;
            Created = DateTime.Now;
        }

        private UserAddress(string street,string city,string country,string postalCode):this()
        {
            Street = street;
            City = city;
            Country = country;
            PostalCode = postalCode;
        }

        public static UserAddress Create(string street, string city, string country, string postalCode) 
        {
            var userAddress = new UserAddress(street,city,country,postalCode);

            return userAddress;
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
