using Assembly.Projecto.Final.Domain.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Models
{
    public class EmployeeContact:AuditableEntity<int>
    {
        public string ContactType { get; private set; }
        public string Value { get; private set; }

        private EmployeeContact() 
        {
            ContactType = string.Empty;
            Value = string.Empty;
            Created = DateTime.UtcNow;
        }

        private EmployeeContact(string contactType, string value):this() 
        {
            ContactType = contactType;
            Value = value;
        } 

        public static EmployeeContact Create(string contactType, string value) 
        {
            var employeeContact = new EmployeeContact(contactType, value);

            return employeeContact;
        }

        public void Update(string contactType, string value) 
        {
            ContactType = contactType;
            Value = value;
            Updated = DateTime.UtcNow;
        }
    }
}
