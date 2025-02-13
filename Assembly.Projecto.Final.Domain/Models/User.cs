using Assembly.Projecto.Final.Domain.Common;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Assembly.Projecto.Final.Domain.Models
{
    public class User: Person
    {
        public int? EntityLinkId { get; set; }
        public EntityLink? EntityLink { get; set; }
        public List<Favorite> Favorites { get; set; }
        public List<FeedBack> FeedBacks { get; set; }

        private User() : base()
        {
        }

        private User(Name name, DateTime dateOfBirth, string gender, string photoFileName, bool isActive):
           base(name,dateOfBirth,gender,photoFileName,isActive)
       {
            Favorites = new List<Favorite>();
            FeedBacks = new List<FeedBack>();
        }

        private User(int id,Name name, DateTime dateOfBirth, string gender, string photoFileName, bool isActive) :
            base(id,name, dateOfBirth, gender, photoFileName, isActive)
        {
            Favorites = new List<Favorite>();
            FeedBacks = new List<FeedBack>();

        }

        private User(string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive):base(firstName,middleNames,lastName,dateOfBirth,gender,photoFileName,isActive)
        {
            Favorites = new List<Favorite>();
            FeedBacks = new List<FeedBack>();
        }

        private User(int id,string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender,
           string photoFileName, bool isActive) : base(id,firstName, middleNames, lastName, dateOfBirth, gender, photoFileName,
               isActive)
        {
            Favorites = new List<Favorite>();
            FeedBacks = new List<FeedBack>();
        }

        public static User Create(Name name, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive)
        {
            var user = new User(name, dateOfBirth, gender, photoFileName, isActive);

            return user;
        }

        public static User Create(int id,Name name, DateTime dateOfBirth, string gender,
           string photoFileName, bool isActive)
        {
            var user = new User(id,name, dateOfBirth, gender, photoFileName, isActive);

            return user;
        }

        public static User Create(string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive)
        {
            var user = new User(firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive);

            return user;
        }

        public static User Create(int id,string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive)
        {
            var user = new User(id,firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive);

            return user;
        }

        public void Update(Name name, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive)
        {
            base.Update(name,dateOfBirth,gender,photoFileName,isActive);            
        }

        public void Update(string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive)
        {
            base.Update(firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive);
        }
    }
}
