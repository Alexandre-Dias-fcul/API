using Assembly.Projecto.Final.Domain.Enums;
using Assembly.Projecto.Final.Domain.Interfaces;
using Assembly.Projecto.Final.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assembly.Projecto.Final.Domain.Common
{
    public abstract class Employee:Person
    {
        public DateTime? HiredDate { get; private set; }
        public DateTime? DateOfTermination { get; private set; }
        public RoleType Role { get; private set; }
        public List<Contact> Contacts { get; set; } 
        public List<Address> Addresses { get; set; } 
        public Account Account { get; set; }
        public List<PersonalContact> PersonalContacts { get; set; } 
        public List<Listing> Listings { get; set; } 
        public List<Participant> Participants { get; set; } 

        protected Employee(Name name, DateTime dateOfBirth, string gender, string photoFileName, bool isActive,
            DateTime hiredDate, DateTime dateOfTermination, RoleType role) : base(name, dateOfBirth, gender, photoFileName,
                isActive)
        {
            HiredDate = hiredDate;
            DateOfTermination = dateOfTermination;
            Role = role;
            Contacts = new List<Contact>();
            Addresses = new List<Address>();
            PersonalContacts = new List<PersonalContact>();
            Listings = new List<Listing>();
            Participants = new List<Participant>();
        }

        protected Employee(int id, Name name, DateTime dateOfBirth, string gender, string photoFileName, bool isActive,
           DateTime hiredDate, DateTime dateOfTermination, RoleType role) : base(id, name, dateOfBirth, gender,
               photoFileName, isActive)
        {
            HiredDate = hiredDate;
            DateOfTermination = dateOfTermination;
            Role = role;
            Contacts = new List<Contact>();
            Addresses = new List<Address>();
            PersonalContacts = new List<PersonalContact>();
            Listings = new List<Listing>();
            Participants = new List<Participant>();
        }
        protected Employee(string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive, DateTime hiredDate, DateTime dateOfTermination, RoleType role) :
            base(firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive)
        {
            HiredDate = hiredDate;
            DateOfTermination = dateOfTermination;
            Role = role;
            Contacts = new List<Contact>();
            Addresses = new List<Address>();
            PersonalContacts = new List<PersonalContact>();
            Listings = new List<Listing>();
            Participants = new List<Participant>();
        }

        protected Employee(int id, string firstName, string middleNames, string lastName, DateTime dateOfBirth,
           string gender, string photoFileName, bool isActive, DateTime hiredDate, DateTime dateOfTermination,
           RoleType role) : base(id, firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive)
        {
            HiredDate = hiredDate;
            DateOfTermination = dateOfTermination;
            Role = role;
            Contacts = new List<Contact>();
            Addresses = new List<Address>();
            PersonalContacts = new List<PersonalContact>();
            Listings = new List<Listing>();
            Participants = new List<Participant>();
        }

        public void Update(Name name, DateTime dateOfBirth, string gender, string photoFileName, bool isActive,
            DateTime hiredDate, DateTime dateOfTermination, RoleType role)
        {
            base.Update(name, dateOfBirth, gender, photoFileName, isActive);
            HiredDate = hiredDate;
            DateOfTermination = dateOfTermination;
            Role = role;

        }

        public void Update(string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive, DateTime hiredDate, DateTime dateOfTermination, RoleType role)
        {
            base.Update(firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive);
            HiredDate = hiredDate;
            DateOfTermination = dateOfTermination;
            Role = role;
        }
    }
}
