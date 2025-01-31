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
        public List<PersonalContactDetail> PersonalContactDetails { get; }
        public Employee Employee { get; set; }

        private PersonalContact()
        {
            Name = string.Empty;
            IsPrimary = false;
            Notes = string.Empty;
            Created = DateTime.Now;
        }

        private PersonalContact(string name,bool isPrimary, string notes) : this()
        {
            Name = name;
            IsPrimary = isPrimary;
            Notes = notes;
        }

        private PersonalContact(int id, string name, bool isPrimary, string notes) : 
            this(name,isPrimary,notes)
        {
           Id = id;
        }

        public static PersonalContact Create(string name, bool isPrimary, string notes)
        {
            var personalContact = new PersonalContact(name, isPrimary, notes);

            return personalContact;
        }

        public static PersonalContact Create(int id, string name, bool isPrimary, string notes)
        {
            var personalContact = new PersonalContact(id, name, isPrimary, notes);

            return personalContact;
        }

        public void Update(string name, bool isPrimary, string notes)
        {
            Name = name;
            IsPrimary = isPrimary;
            Notes = notes;
            Updated = DateTime.Now;
        }
    }
}
