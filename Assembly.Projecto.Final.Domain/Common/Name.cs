using Assembly.Projecto.Final.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Common
{
    public class Name
    {
        public string FirstName { get; private set; }
        public string[] MiddleNames { get; private set; }
        public string LastName { get; private set; }
        public string FullName => $"{FirstName} {string.Join(" ", MiddleNames)} {LastName}";

        private Name()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            MiddleNames = [];
        }

        private Name(string firstName, string lastName) : this()
        {
            DomainValidation(firstName, lastName);
        }

        private Name(string firstName, string middleNames, string lastName)
            : this(firstName, lastName)
        {
            DomainValidation(middleNames);
        }

        private Name(string fullName)
            : this(
                  fullName.Split(" ")[0],fullName.Split(" ").Length>2 ? string.Join(" ",fullName.Split(" ")[1..^1]):"",
                  fullName.Split(" ")[^1]
                  )
        {
        }

        public static Name Create(string firstName, string middleNames, string lastName)
        {
            var name = new Name(firstName, middleNames, lastName);
         
            return name;
        }

        public void Update(string firstName, string middleNames, string lastName)
        {
            DomainValidation(firstName, lastName);
            DomainValidation(middleNames);
        }

        public Name Create(string fullName)
        {
            return new Name(fullName);
        }

        public void Update(string fullName) 
        {
           DomainValidation(fullName.Split(" ")[0], fullName.Split(" ")[^1]);

           DomainValidation(fullName.Split(" ").Length > 2 ? string.Join(" ", fullName.Split(" ")[1..^1]) : "");
        }

        public void DomainValidation(string firstName, string lastName) 
        {
            DomainExceptionValidation.When(firstName == null,"Erro: primeiro nome é obrigatório.");
            DomainExceptionValidation.When(firstName != null && firstName.Length > 100, "Erro: o primeiro " +
                "nome não pode ter mais de 100 caracteres.");
            DomainExceptionValidation.When(lastName == null,"Erro: o último nome é obrigatório.");
            DomainExceptionValidation.When(lastName != null && lastName.Length>100,"Erro: O ultimo nome não pode " +
                "ter mais de 100 caracteres.");
                
            FirstName = firstName;
            
            LastName = lastName;
        }

        public void DomainValidation(string middlenames) 
        {
            DomainExceptionValidation.When(middlenames != null && middlenames.Length > 500, "Erro: os nomes do meio não podem" +
                " ter mais de 500 caracters.");

            MiddleNames = middlenames.Split(" ");

        }
    }
}
