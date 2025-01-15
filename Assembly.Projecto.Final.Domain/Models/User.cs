using Assembly.Projecto.Final.Domain.Common;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Assembly.Projecto.Final.Domain.Models
{
    public class User: Person
    {
        private User() :base()
        { 
        }
       private User(Name name, DateTime dateOfBirth, string gender, string photoFileName, bool isActive) :
            base(name,dateOfBirth,gender,photoFileName,isActive)
       { 
        

       }

        private User(string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive):base(firstName,middleNames,lastName,dateOfBirth,gender,photoFileName,isActive)
        { 
        }

        private static Person Create(Name name, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive)
        {
            var person = new User(name, dateOfBirth, gender, photoFileName, isActive);

            return person;
        }

        private static Person Create(string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive)
        {
            var person = new User(firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive);

            return person;
        }

        private void Update(Name name, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive)
        {
            base.Update(name,dateOfBirth,gender,photoFileName,isActive);            
        }

        private void Update(string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive)
        {
            base.Update(firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive);
        }
    }
}
