using Assembly.Projecto.Final.Domain.Interfaces;
using Assembly.Projecto.Final.Domain.Validations;
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
        public DateTime? DateOfBirth { get; private set; }
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
        }

        protected Person(Name name,DateTime? dateOfBirth,string gender,string photoFileName,bool isActive):this()
        { 
            Name = name;
            DomainValidation(dateOfBirth, gender, photoFileName, isActive);
        }

        protected Person(int id, Name name, DateTime? dateOfBirth, string gender, string photoFileName, bool isActive)
            :this() 
        { 
            Id = id;
            Name = name;
        }

        protected Person(string firstName, string middleNames, string lastName, DateTime? dateOfBirth, string gender, 
            string photoFileName, bool isActive):this(Name.Create(firstName,middleNames,lastName), dateOfBirth,gender,
                photoFileName,isActive)
        {
        }
        protected Person(int id,string firstName, string middleNames, string lastName, DateTime? dateOfBirth, string gender,
           string photoFileName, bool isActive) : this(firstName, middleNames, lastName, dateOfBirth, gender,
               photoFileName, isActive)
        {
            Id = id;
        }

        public void Update(Name name, DateTime? dateOfBirth, string gender, string photoFileName, bool isActive) 
        {
            Name.Update(name.FirstName,string.Join(" ",name.MiddleNames),name.LastName);
            DomainValidation(dateOfBirth, gender, photoFileName, isActive);
        }

        public void Update(string firstName, string middleNames, string lastName, DateTime? dateOfBirth, string gender,
            string photoFileName, bool isActive)
        {

           Name.Update(firstName,middleNames,lastName);

           DomainValidation(dateOfBirth,gender,photoFileName,isActive);
        }

        public void DomainValidation(DateTime? dateOfBirth, string gender,string photoFileName, bool isActive) 
        {
            DomainExceptionValidation.When(gender != null && gender.Length > 50, "Erro: o género não pode ter mais de " +
                "50 caracters.");
            DomainExceptionValidation.When(photoFileName != null && photoFileName.Length > 300, "Erro: o PhotoFileName " +
                " não pode ter mais de 300 caracteres.");

            DomainExceptionValidation.When(dateOfBirth > DateTime.Now, "Erro: a data de nascimento não pode ser " +
                "posterior à data atual.");

            DateOfBirth = dateOfBirth;
            Gender = gender;
            PhotoFileName = photoFileName;
            IsActive = isActive;
        }
    }
}
