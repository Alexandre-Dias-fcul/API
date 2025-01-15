﻿using Assembly.Projecto.Final.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assembly.Projecto.Final.Domain.Models
{
    public class Agent:Employee
    {
        public int SupervisorId { get; set; }

        public Agent(string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender, string photoFileName, bool isActive, string role,
            DateTime hiredDate, DateTime dateOfTermination,int supervisorId) :base(firstName,middleNames,lastName,dateOfBirth,gender,photoFileName,isActive,role,hiredDate,dateOfTermination)
        { 
            SupervisorId = supervisorId;
        }

        public Agent(Name name, DateTime dateOfBirth, string gender, string photoFileName, bool isActive, string role,
            DateTime hiredDate, DateTime dateOfTermination, int supervisorId) : base(name, dateOfBirth, gender, photoFileName, isActive, role, hiredDate, dateOfTermination)
        {
            SupervisorId = supervisorId;
        }

        private static Agent Create(Name name, DateTime dateOfBirth, string gender,string photoFileName, bool isActive,
             string role, DateTime hiredDate, DateTime dateOfTermination,int supervisiorId)
        {
            var agent = new Agent(name, dateOfBirth, gender, photoFileName, isActive,role,hiredDate,dateOfTermination,supervisiorId);

            return agent;
        }

        private static Agent Create(string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender, 
            string photoFileName, bool isActive,string role, DateTime hiredDate, DateTime dateOfTermination, int supervisiorId)
        {
            var agent = new Agent(firstName, middleNames,lastName, dateOfBirth, gender, photoFileName, isActive, role, hiredDate, 
                dateOfTermination, supervisiorId);

            return agent;
        }

        private void Update(Name name, DateTime dateOfBirth, string gender, string photoFileName, bool isActive,
             string role, DateTime hiredDate, DateTime dateOfTermination, int supervisiorId)
        {
            base.Update(name, dateOfBirth, gender, photoFileName, isActive, role, hiredDate, dateOfTermination);
            SupervisorId = supervisiorId;
        }

        private void Update(string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive, string role, DateTime hiredDate, DateTime dateOfTermination, int supervisiorId)
        {
            base.Update(firstName,middleNames,lastName, dateOfBirth, gender, photoFileName, isActive, role, hiredDate, 
                dateOfTermination);
            SupervisorId = supervisiorId;
        }

    }
}
