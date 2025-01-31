﻿using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Models
{
    public class PersonalContactDetail:AuditableEntity<int>
    {
        public ContactType ContactType { get; private set; }
        public string Value { get; private set; }
        public PersonalContact PersonalContact { get; set; }

        private PersonalContactDetail()
        {
            ContactType = 0;
            Value = string.Empty;
            Created = DateTime.Now;
        }

        private PersonalContactDetail(ContactType contactType, string value) : this()
        {
            ContactType = contactType;
            Value = value;
        }

        private PersonalContactDetail(int id, ContactType contactType, string value) : this(contactType, value)
        {
            Id = Id;
        }
        public static PersonalContactDetail Create(ContactType contactType, string value)
        {
            var personalContactDetail = new PersonalContactDetail(contactType, value);

            return personalContactDetail;
        }

        public static PersonalContactDetail Create(int id, ContactType contactType, string value)
        {
            var personalContactDetail = new PersonalContactDetail(id, contactType, value);

            return personalContactDetail;
        }

        public void Update(ContactType contactType, string value)
        {
            ContactType = contactType;
            Value = value;
            Updated = DateTime.Now;
        }
    }
}
