﻿using Assembly.Projecto.Final.Domain.Common;
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

        private List<PersonalContactDetail> _personalContactDetails;
        public IReadOnlyCollection<PersonalContactDetail> PersonalContactDetails =>
                                                                 _personalContactDetails.AsReadOnly();
        public int EmployeeId { get; private set; }
        public Employee Employee { get; private set; }

        private PersonalContact()
        {
            Name = string.Empty;
            IsPrimary = false;
            Notes = string.Empty;
            Created = DateTime.Now;
            _personalContactDetails = new();
        }

        private PersonalContact(string name,bool isPrimary, string notes) : this()
        {
            Name = name;
            IsPrimary = isPrimary;
            Notes = notes;
        }

        private PersonalContact(int id, string name, bool isPrimary, string notes) 
            : this(name,isPrimary,notes)
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

        public void SetEmployee(Employee employee) 
        {
            if (employee == null)
            {
                throw new ArgumentNullException();
            }

            Employee = employee;
        }

        public void AddPersonalContactDetail(PersonalContactDetail personalContactDetail)
        {
            if(personalContactDetail == null) 
            {
                throw new ArgumentNullException();
            }

            _personalContactDetails.Add(personalContactDetail);
        }
    }
}
