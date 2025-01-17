using Assembly.Projecto.Final.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Common
{
    public abstract class Person:AuditableEntity<int>
    {
        public Name Name { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Gender { get; private set; }
        public string PhotoFileName { get; private set; }
        public bool IsActive { get; private set; }
       
        protected Person() 
        {
            Id = 0;
            Name = Name.Create(string.Empty,string.Empty,string.Empty);
            DateOfBirth = DateTime.MinValue;
            Gender = string.Empty;
            PhotoFileName = string.Empty;
            IsActive = false;
            Created = DateTime.Now;
        }

        protected Person(Name name,DateTime dateOfBirth,string gender,string photoFileName,bool isActive):this()
        { 
            Name = name;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            PhotoFileName = photoFileName;
            IsActive = isActive;
        }

        protected Person(int id, Name name, DateTime dateOfBirth, string gender, string photoFileName, bool isActive):this() 
        { 
            Id = id;
        }

        protected Person(string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender, 
            string photoFileName, bool isActive):this(Name.Create(firstName,middleNames,lastName), dateOfBirth,gender,
                photoFileName,isActive)
        {
        }
        protected Person(int id,string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender,
           string photoFileName, bool isActive) : this(firstName, middleNames, lastName, dateOfBirth, gender,
               photoFileName, isActive)
        {
            Id = id;
        }

        public void Update(Name name, DateTime dateOfBirth, string gender, string photoFileName, bool isActive) 
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            PhotoFileName = photoFileName;
            IsActive = isActive;
            Updated = DateTime.Now;
        }

        public void Update(string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive)
        {
            Name.Update(firstName,middleNames,lastName);
            DateOfBirth = dateOfBirth;
            Gender = gender;
            PhotoFileName = photoFileName;
            IsActive = isActive;
            Updated = DateTime.Now;
        }
    }
}
