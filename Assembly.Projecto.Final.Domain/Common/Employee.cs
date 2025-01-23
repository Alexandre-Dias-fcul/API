﻿using Assembly.Projecto.Final.Domain.Enums;
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
        public DateTime HiredDate { get; private set; }
        public DateTime DateOfTermination {  get; private set; }
        public List<Contact> Contacts { get; set; }
        public List<Address> Addresses { get; set; }
        public Account Account { get; set; }
        public List<PersonalContact> PersonalContacts { get; set; }
        public List<Appointment> Appointments { get; set; }
        public List<Listing> Listings { get; set; }
        
        protected Employee():base() 
        { 
            HiredDate = DateTime.MinValue;
            DateOfTermination = DateTime.MinValue;
        }

        protected Employee(Name name, DateTime dateOfBirth, string gender, string photoFileName, bool isActive,
            DateTime hiredDate,DateTime dateOfTermination):base(name, dateOfBirth,gender,photoFileName,isActive)
        {
            HiredDate = hiredDate;
            DateOfTermination = dateOfTermination;
        }

        protected Employee(int id,Name name, DateTime dateOfBirth, string gender, string photoFileName, bool isActive,
           DateTime hiredDate, DateTime dateOfTermination) : base(id, name, dateOfBirth, gender, photoFileName, isActive)
        {
            HiredDate = hiredDate;
            DateOfTermination = dateOfTermination;
        }
        protected Employee(string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender, 
            string photoFileName, bool isActive,DateTime hiredDate, DateTime dateOfTermination) : 
            base(firstName,middleNames,lastName, dateOfBirth, gender, photoFileName, isActive)
        {
            HiredDate = hiredDate;
            DateOfTermination = dateOfTermination;
        }

        protected Employee(int id,string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender,
           string photoFileName, bool isActive, DateTime hiredDate, DateTime dateOfTermination) :
           base(id,firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive)
        {
            HiredDate = hiredDate;
            DateOfTermination = dateOfTermination;
        }

        public void Update(Name name, DateTime dateOfBirth, string gender, string photoFileName, bool isActive,
            DateTime hiredDate, DateTime dateOfTermination)
        {
            base.Update(name, dateOfBirth, gender, photoFileName, isActive);
            HiredDate = hiredDate;
            DateOfTermination = dateOfTermination;

        }

        public void Update(string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive,DateTime hiredDate, DateTime dateOfTermination)
        {
            base.Update(firstName,middleNames,lastName, dateOfBirth, gender, photoFileName, isActive);
            HiredDate = hiredDate;
            DateOfTermination = dateOfTermination;
        }
    }
}
