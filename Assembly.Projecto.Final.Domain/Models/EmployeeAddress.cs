using Assembly.Projecto.Final.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Models
{
    public class EmployeeAddress: AuditableEntity<int>
    {
         public string Street { get; private set; }
         public string City { get; private set; }
         public string Country { get; private set; }
         public string PostalCode { get; private set; }

        private EmployeeAddress() 
        { 
            Street = string.Empty;
            City = string.Empty;
            Country = string.Empty;
            PostalCode = string.Empty;
            Created = DateTime.Now;
        }

        private EmployeeAddress(string street, string city, string country, string postalCode):this()
        {
            Street = street;
            City = city;
            Country = country;
            PostalCode = postalCode;
        }

        public static EmployeeAddress Create(string street, string city, string country, string postalCode) 
        {
            var employeeAddress = new EmployeeAddress(street,city,country,postalCode);

            return employeeAddress;
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
