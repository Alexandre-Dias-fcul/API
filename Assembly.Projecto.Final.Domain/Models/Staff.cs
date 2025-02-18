using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assembly.Projecto.Final.Domain.Models
{
    public class Staff:Employee
    {
        private Staff() : base()
        {
        }
        private Staff(Name name, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive, DateTime hiredDate, DateTime dateOfTermination,
             EntityLink? entityLink, int? entityLinkId) :
            base(name, dateOfBirth, gender, photoFileName, isActive, hiredDate, dateOfTermination,
                entityLink, entityLinkId)
        {
        }

        private Staff(int id, Name name, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive, DateTime hiredDate, DateTime dateOfTermination,
             EntityLink? entityLink, int? entityLinkId) :
            base(id, name, dateOfBirth, gender, photoFileName, isActive, hiredDate, dateOfTermination, 
                entityLink, entityLinkId)
        {
        }

        private Staff(string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive, DateTime hiredDate, DateTime dateOfTermination,
             EntityLink? entityLink, int? entityLinkId) :
            base(firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive, hiredDate,
                dateOfTermination, entityLink, entityLinkId)
        {

        }

        private Staff(int id, string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive, DateTime hiredDate, DateTime dateOfTermination,
             EntityLink? entityLink, int? entityLinkId) :
            base(id, firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive, hiredDate,
                dateOfTermination, entityLink, entityLinkId)
        {

        }

        public static Staff Create(Name name, DateTime dateOfBirth, string gender, string photoFileName, bool isActive,
           DateTime hiredDate, DateTime dateOfTermination, EntityLink? entityLink, int? entityLinkId)
        {
            var staff = new Staff(name, dateOfBirth, gender, photoFileName, isActive, hiredDate, dateOfTermination
                , entityLink, entityLinkId);

            return staff;
        }

        public static Staff Create(int id, Name name, DateTime dateOfBirth, string gender, string photoFileName, bool isActive
            , DateTime hiredDate, DateTime dateOfTermination, EntityLink? entityLink, int? entityLinkId)
        {
            var staff = new Staff(id, name, dateOfBirth, gender, photoFileName, isActive, hiredDate, dateOfTermination,
                 entityLink, entityLinkId);

            return staff;
        }

        public static Staff Create(string firstName, string middleNames, string lastName, DateTime dateOfBirth,
            string gender, string photoFileName, bool isActive, DateTime hiredDate, DateTime dateOfTermination,
             EntityLink? entityLink, int? entityLinkId)
        {
            var staff = new Staff(firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive,
                hiredDate, dateOfTermination, entityLink, entityLinkId);

            return staff;
        }

        public static Staff Create(int id, string firstName, string middleNames, string lastName, DateTime dateOfBirth,
            string gender,string photoFileName, bool isActive, DateTime hiredDate, DateTime dateOfTermination, 
            EntityLink? entityLink, int? entityLinkId)
        {
            var staff = new Staff(id, firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive,
                hiredDate, dateOfTermination, entityLink, entityLinkId);

            return staff;
        }

        public void Update(Name name, DateTime dateOfBirth, string gender, string photoFileName, bool isActive,
              DateTime hiredDate, DateTime dateOfTermination, EntityLink? entityLink, 
              int? entityLinkId)
        {
            base.Update(name, dateOfBirth, gender, photoFileName, isActive, hiredDate, dateOfTermination, 
                entityLink, entityLinkId);
        }

        public void Update(string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive, DateTime hiredDate, DateTime dateOfTermination,
            EntityLink? entityLink, int? entityLinkId)
        {
            base.Update(firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive, hiredDate,
                dateOfTermination, entityLink, entityLinkId);
        }
    }
}
