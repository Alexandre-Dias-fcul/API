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
        public string Name { get; private set; }
        public bool IsPrimary {  get; private set; }
        public string Notes { get; private set; }
        public List<PersonalContactDetail> PersonalContactDetails { get; private set; }
        public int EmployeeId { get; private set; }
        public Employee Employee { get; private set; }

        private PersonalContact()
        {
            Name = string.Empty;
            IsPrimary = false;
            Notes = string.Empty;
            Created = DateTime.Now;
            PersonalContactDetails = new();
        }

        private PersonalContact(string name,bool isPrimary, string notes, Employee employee) : this()
        {
            Name = name;
            IsPrimary = isPrimary;
            Notes = notes;
            Employee = employee;
        }

        private PersonalContact(int id, string name, bool isPrimary, string notes, Employee employee) : 
            this(name,isPrimary,notes,employee)
        {
           Id = id;
        }

        public static PersonalContact Create(string name, bool isPrimary, string notes, Employee employee)
        {
            var personalContact = new PersonalContact(name, isPrimary, notes,employee);

            return personalContact;
        }

        public static PersonalContact Create(int id, string name, bool isPrimary, string notes, Employee employee)
        {
            var personalContact = new PersonalContact(id, name, isPrimary, notes,employee);

            return personalContact;
        }

        public void Update(string name, bool isPrimary, string notes, Employee employee)
        {
            Name = name;
            IsPrimary = isPrimary;
            Notes = notes;
            Updated = DateTime.Now;
            Employee = Employee;
        }
    }
}
