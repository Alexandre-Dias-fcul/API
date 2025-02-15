﻿using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assembly.Projecto.Final.Domain.Models
{
    public class Agent : Employee
    {
        public List<Listing> Listings { get; private set; }

        private Agent() : base()
        {
            Listings = new();
        }

        private Agent(string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive, DateTime hiredDate, DateTime dateOfTermination, RoleType role) :
            base(firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive, hiredDate, 
                dateOfTermination, role)
        {
            Listings = new();
        }

        private Agent(int id, string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive, DateTime hiredDate, DateTime dateOfTermination, RoleType role) : 
            base(id, firstName, middleNames, lastName, dateOfBirth, gender, photoFileName,isActive, hiredDate,
                dateOfTermination, role)
        {
            Listings = new();
        }

        private Agent(Name name, DateTime dateOfBirth, string gender, string photoFileName, bool isActive,
            DateTime hiredDate, DateTime dateOfTermination, RoleType role) :
            base(name, dateOfBirth, gender, photoFileName, isActive, hiredDate, dateOfTermination, role)
        {
            Listings = new();
        }

        private Agent(int id, Name name, DateTime dateOfBirth, string gender, string photoFileName, bool isActive,
           DateTime hiredDate, DateTime dateOfTermination, RoleType role) :
            base(id, name, dateOfBirth, gender, photoFileName, isActive, hiredDate, dateOfTermination, role)
        {
            Listings = new();
        }

        public static Agent Create(Name name, DateTime dateOfBirth, string gender, string photoFileName, bool isActive,
              DateTime hiredDate, DateTime dateOfTermination, RoleType role)
        {
            var agent = new Agent(name, dateOfBirth, gender, photoFileName, isActive, hiredDate, dateOfTermination,
                role);

            return agent;
        }

        public static Agent Create(int id, Name name, DateTime dateOfBirth, string gender, string photoFileName,
            bool isActive, DateTime hiredDate, DateTime dateOfTermination, RoleType role)
        {
            var agent = new Agent(id, name, dateOfBirth, gender, photoFileName, isActive, hiredDate, dateOfTermination,
                role);

            return agent;
        }

        public static Agent Create(string firstName, string middleNames, string lastName, DateTime dateOfBirth,
            string gender, string photoFileName, bool isActive, DateTime hiredDate, DateTime dateOfTermination,
            RoleType role, int supervisiorId)
        {
            var agent = new Agent(firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive,
                hiredDate, dateOfTermination, role);

            return agent;
        }

        public static Agent Create(int id, string firstName, string middleNames, string lastName, DateTime dateOfBirth,
            string gender, string photoFileName, bool isActive, DateTime hiredDate, DateTime dateOfTermination,
            RoleType role)
        {
            var agent = new Agent(id, firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive,
                hiredDate, dateOfTermination, role);

            return agent;
        }

        public void Update(Name name, DateTime dateOfBirth, string gender, string photoFileName, bool isActive,
              DateTime hiredDate, DateTime dateOfTermination, RoleType role)
        {
            base.Update(name, dateOfBirth, gender, photoFileName, isActive, hiredDate, dateOfTermination, role);
           
        }

        public void Update(string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive, DateTime hiredDate, DateTime dateOfTermination, RoleType role)
        {
            base.Update(firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive, hiredDate,
                dateOfTermination, role);
        }
    }
}
