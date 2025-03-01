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
        private Staff(Name name, DateTime? dateOfBirth, string gender,
            string photoFileName, bool isActive, DateTime? hiredDate, DateTime? dateOfTermination) :
            base(name, dateOfBirth, gender, photoFileName, isActive, hiredDate, dateOfTermination)
        {
        }

        private Staff(int id, Name name, DateTime? dateOfBirth, string gender,
            string photoFileName, bool isActive, DateTime? hiredDate, DateTime? dateOfTermination) :
            base(id, name, dateOfBirth, gender, photoFileName, isActive, hiredDate, dateOfTermination)
        {
        }

        private Staff(string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive, DateTime hiredDate, DateTime dateOfTermination) :
            base(firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive, hiredDate,
                dateOfTermination)
        {

        }

        private Staff(int id, string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive, DateTime hiredDate, DateTime dateOfTermination) :
            base(id, firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive, hiredDate,
                dateOfTermination)
        {

        }

        public static Staff Create(Name name, DateTime dateOfBirth, string gender, string photoFileName, bool isActive,
           DateTime hiredDate, DateTime dateOfTermination)
        {
            var staff = new Staff(name, dateOfBirth, gender, photoFileName, isActive, hiredDate, dateOfTermination);

            return staff;
        }

        public static Staff Create(int id, Name name, DateTime dateOfBirth, string gender, string photoFileName, bool isActive
            , DateTime hiredDate, DateTime dateOfTermination, EntityLink? entityLink, int? entityLinkId)
        {
            var staff = new Staff(id, name, dateOfBirth, gender, photoFileName, isActive, hiredDate, dateOfTermination);

            return staff;
        }

        public static Staff Create(string firstName, string middleNames, string lastName, DateTime dateOfBirth,
            string gender, string photoFileName, bool isActive, DateTime hiredDate, DateTime dateOfTermination)
        {
            var staff = new Staff(firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive,
                hiredDate, dateOfTermination);

            return staff;
        }

        public static Staff Create(int id, string firstName, string middleNames, string lastName, DateTime dateOfBirth,
            string gender,string photoFileName, bool isActive, DateTime hiredDate, DateTime dateOfTermination)
        {
            var staff = new Staff(id, firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive,
                hiredDate, dateOfTermination);

            return staff;
        }

        public void Update(Name name, DateTime dateOfBirth, string gender, string photoFileName, bool isActive,
              DateTime hiredDate, DateTime dateOfTermination)
        {
            base.Update(name, dateOfBirth, gender, photoFileName, isActive, hiredDate, dateOfTermination);
        }

        public void Update(string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive, DateTime hiredDate, DateTime dateOfTermination)
        {
            base.Update(firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive, hiredDate,
                dateOfTermination);
        }
    }
}
