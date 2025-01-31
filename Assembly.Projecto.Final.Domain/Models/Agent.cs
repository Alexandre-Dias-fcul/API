using Assembly.Projecto.Final.Domain.Common;
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
        public int? SupervisorId { get; private set; }

        private Agent(string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive, DateTime hiredDate, DateTime dateOfTermination, RoleType role, int supervisorId) :
            base(firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive, hiredDate, dateOfTermination, role)
        {
            SupervisorId = supervisorId;
        }

        private Agent(int id, string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive, DateTime hiredDate, DateTime dateOfTermination, RoleType role,
            int supervisorId) : base(id, firstName, middleNames, lastName, dateOfBirth, gender, photoFileName,
                isActive, hiredDate, dateOfTermination, role)
        {
            SupervisorId = supervisorId;
        }

        private Agent(Name name, DateTime dateOfBirth, string gender, string photoFileName, bool isActive,
            DateTime hiredDate, DateTime dateOfTermination, RoleType role, int supervisorId) :
            base(name, dateOfBirth, gender, photoFileName, isActive, hiredDate, dateOfTermination, role)
        {
            SupervisorId = supervisorId;
        }

        private Agent(int id, Name name, DateTime dateOfBirth, string gender, string photoFileName, bool isActive,
           DateTime hiredDate, DateTime dateOfTermination, RoleType role, int supervisorId) :
            base(id, name, dateOfBirth, gender, photoFileName, isActive, hiredDate, dateOfTermination, role)
        {
            SupervisorId = supervisorId;
        }

        public static Agent Create(Name name, DateTime dateOfBirth, string gender, string photoFileName, bool isActive,
              DateTime hiredDate, DateTime dateOfTermination, RoleType role, int supervisiorId)
        {
            var agent = new Agent(name, dateOfBirth, gender, photoFileName, isActive, hiredDate, dateOfTermination,
                role, supervisiorId);

            return agent;
        }

        public static Agent Create(int id, Name name, DateTime dateOfBirth, string gender, string photoFileName,
            bool isActive, DateTime hiredDate, DateTime dateOfTermination, RoleType role, int supervisiorId)
        {
            var agent = new Agent(id, name, dateOfBirth, gender, photoFileName, isActive, hiredDate, dateOfTermination,
                role, supervisiorId);

            return agent;
        }

        public static Agent Create(string firstName, string middleNames, string lastName, DateTime dateOfBirth,
            string gender, string photoFileName, bool isActive, DateTime hiredDate, DateTime dateOfTermination,
            RoleType role, int supervisiorId)
        {
            var agent = new Agent(firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive,
                hiredDate, dateOfTermination, role, supervisiorId);

            return agent;
        }

        public static Agent Create(int id, string firstName, string middleNames, string lastName, DateTime dateOfBirth,
            string gender, string photoFileName, bool isActive, DateTime hiredDate, DateTime dateOfTermination,
            RoleType role, int supervisiorId)
        {
            var agent = new Agent(id, firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive,
                hiredDate, dateOfTermination, role, supervisiorId);

            return agent;
        }

        public void Update(Name name, DateTime dateOfBirth, string gender, string photoFileName, bool isActive,
              DateTime hiredDate, DateTime dateOfTermination, RoleType role, int supervisiorId)
        {
            base.Update(name, dateOfBirth, gender, photoFileName, isActive, hiredDate, dateOfTermination, role);
            SupervisorId = supervisiorId;
        }

        public void Update(string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive, DateTime hiredDate, DateTime dateOfTermination, RoleType role,
            int supervisiorId)
        {
            base.Update(firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive, hiredDate,
                dateOfTermination, role);

            SupervisorId = supervisiorId;
        }
    }
}
