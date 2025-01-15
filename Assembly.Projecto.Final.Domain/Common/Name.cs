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
            FirstName = firstName;
            LastName = lastName;
        }

        private Name(string firstName, string middleNames, string lastName)
            : this(firstName, lastName)
        {
            MiddleNames = middleNames.Split(" ");
        }

        private Name(string fullName)
            : this(
                  fullName.Split(" ")[0],
                  fullName.Split(" ")[fullName.Split(" ").Length - 1]
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
            FirstName = firstName;
            MiddleNames = middleNames.Split(" ");
            LastName = lastName;

        }

        public Name Create(string fullName)
        {
            return new Name(fullName);
        }

        public void Update(string fullName) 
        {
            FirstName = fullName.Split(" ")[0];
            LastName = fullName.Split(" ")[fullName.Split(" ").Length - 1];

        }
    }
}
