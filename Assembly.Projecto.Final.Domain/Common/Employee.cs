using Assembly.Projecto.Final.Domain.Interfaces;
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
        public string Role { get; private set; }
        public DateTime HiredDate { get; private set; }
        public DateTime DateOfTermination {  get; private set; }

        protected Employee():base() 
        { 
            Role = string.Empty;
            HiredDate = DateTime.MinValue;
            DateOfTermination = DateTime.MinValue;
        }

        protected Employee(Name name, DateTime dateOfBirth, string gender, string photoFileName, bool isActive,string role,
            DateTime hiredDate,DateTime dateOfTermination):base(name, dateOfBirth,gender,photoFileName,isActive)
        {
            Role = role;
            HiredDate = hiredDate;
            DateOfTermination = dateOfTermination;
        }

        protected Employee(string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender, 
            string photoFileName, bool isActive, string role,DateTime hiredDate, DateTime dateOfTermination) : 
            base(firstName,middleNames,lastName, dateOfBirth, gender, photoFileName, isActive)
        {
            Role = role;
            HiredDate = hiredDate;
            DateOfTermination = dateOfTermination;
        }

        public void Update(Name name, DateTime dateOfBirth, string gender, string photoFileName, bool isActive,string role,
            DateTime hiredDate, DateTime dateOfTermination)
        {
            base.Update(name, dateOfBirth, gender, photoFileName, isActive);
            Role = role;
            HiredDate = hiredDate;
            DateOfTermination = dateOfTermination;

        }

        public void Update(string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive, string role,DateTime hiredDate, DateTime dateOfTermination)
        {
            base.Update(firstName,middleNames,lastName, dateOfBirth, gender, photoFileName, isActive);
            Role = role;
            HiredDate = hiredDate;
            DateOfTermination = dateOfTermination;
        }
    }
}
