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
        public RoleType? Role { get; private set; }
        public int? SupervisorId { get; private set; }
        public Agent Supervisor { get; private set; }
        public List<Agent> Agents { get; private set; }
        public List<Listing> Listings { get; private set; }

        private Agent() : base()
        {
            Role = 0;
            SupervisorId = 0;
            Agents = new ();
            Listings = new ();
        }

        private Agent(string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive, DateTime hiredDate, DateTime dateOfTermination, RoleType? role,
            EntityLink? entityLink, int? entityLinkId, Agent supervisor, int? supervisorId) :
            base(firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive, hiredDate, 
                dateOfTermination,entityLink,entityLinkId)
        {
            Role = role;
            SupervisorId = supervisorId;
            Supervisor = supervisor;
            Agents = new();
            Listings = new();
        }

        private Agent(int id, string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive, DateTime hiredDate, DateTime dateOfTermination, RoleType? role,
             EntityLink? entityLink, int? entityLinkId, Agent supervisor, int? supervisorId) : 
            base(id, firstName, middleNames, lastName, dateOfBirth, gender, photoFileName,isActive, hiredDate,
                dateOfTermination, entityLink, entityLinkId)
        {
            Role = role;
            SupervisorId = supervisorId;
            Supervisor = supervisor;
            Agents = new();
            Listings = new();
        }

        private Agent(Name name, DateTime dateOfBirth, string gender, string photoFileName, bool isActive,
            DateTime hiredDate, DateTime dateOfTermination, RoleType? role, EntityLink? entityLink, int? entityLinkId, 
            Agent supervisor, int? supervisorId) :
            base(name, dateOfBirth, gender, photoFileName, isActive, hiredDate, dateOfTermination, 
                entityLink, entityLinkId)
        {
            Role = role;
            SupervisorId = supervisorId;
            Supervisor = supervisor;
            Agents = new();
            Listings = new();
        }

        private Agent(int id, Name name, DateTime dateOfBirth, string gender, string photoFileName, bool isActive,
           DateTime hiredDate, DateTime dateOfTermination, RoleType? role, EntityLink? entityLink, int? entityLinkId,
            Agent supervisor, int? supervisorId) :
            base(id, name, dateOfBirth, gender, photoFileName, isActive, hiredDate, dateOfTermination,
                entityLink, entityLinkId)
        {
            Role = role;
            SupervisorId = supervisorId;
            Supervisor = supervisor;
            Agents = new();
            Listings = new();
        }

        public static Agent Create(Name name, DateTime dateOfBirth, string gender, string photoFileName, bool isActive,
              DateTime hiredDate, DateTime dateOfTermination, RoleType? role, EntityLink? entityLink, int? entityLinkId,
            Agent supervisor, int? supervisorId)
        {
            var agent = new Agent(name, dateOfBirth, gender, photoFileName, isActive, hiredDate, dateOfTermination,
                role, entityLink, entityLinkId, supervisor,supervisorId);

            return agent;
        }

        public static Agent Create(int id, Name name, DateTime dateOfBirth, string gender, string photoFileName,
            bool isActive, DateTime hiredDate, DateTime dateOfTermination, RoleType? role, EntityLink? entityLink,
            int? entityLinkId,Agent supervisor, int? supervisorId)
        {
            var agent = new Agent(id, name, dateOfBirth, gender, photoFileName, isActive, hiredDate, dateOfTermination,
                role, entityLink, entityLinkId, supervisor, supervisorId);

            return agent;
        }

        public static Agent Create(string firstName, string middleNames, string lastName, DateTime dateOfBirth,
            string gender, string photoFileName, bool isActive, DateTime hiredDate, DateTime dateOfTermination,
            RoleType? role, EntityLink? entityLink,int? entityLinkId, Agent supervisor, int? supervisorId)
        {
            var agent = new Agent(firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive,
                hiredDate, dateOfTermination, role, entityLink, entityLinkId, supervisor, supervisorId);

            return agent;
        }

        public static Agent Create(int id, string firstName, string middleNames, string lastName, DateTime dateOfBirth,
            string gender, string photoFileName, bool isActive, DateTime hiredDate, DateTime dateOfTermination,
            RoleType? role, EntityLink? entityLink, int? entityLinkId, Agent supervisor, int? supervisorId)
        {
            var agent = new Agent(id, firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive,
                hiredDate, dateOfTermination, role, entityLink, entityLinkId, supervisor, supervisorId);

            return agent;
        }

        public void Update(Name name, DateTime dateOfBirth, string gender, string photoFileName, bool isActive,
              DateTime hiredDate, DateTime dateOfTermination, RoleType? role, EntityLink? entityLink, int? entityLinkId, 
              Agent supervisor, int? supervisorId)
        {
            base.Update(name, dateOfBirth, gender, photoFileName, isActive, hiredDate, dateOfTermination, 
                entityLink, entityLinkId);
            Role = role;
            SupervisorId = supervisorId;
            Supervisor = supervisor;
        }

        public void Update(string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive, DateTime hiredDate, DateTime dateOfTermination, RoleType? role,
            EntityLink? entityLink, int? entityLinkId,Agent supervisor, int? supervisorId)
        {
            base.Update(firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive, hiredDate,
                dateOfTermination, entityLink, entityLinkId);
            Role = role;
            SupervisorId = supervisorId;
            Supervisor = supervisor;
        }
    }
}
