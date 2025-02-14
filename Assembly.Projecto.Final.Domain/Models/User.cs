using Assembly.Projecto.Final.Domain.Common;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Assembly.Projecto.Final.Domain.Models
{
    public class User: Person
    {
        public int? EntityLinkId { get; private set; }
        public EntityLink? EntityLink { get; private set; }
        public List<Favorite> Favorites { get;private set; }
        public List<FeedBack> FeedBacks { get; private set; }

        private User() : base()
        {
            EntityLinkId = 0;
        }

        private User(Name name, DateTime dateOfBirth, string gender, string photoFileName, bool isActive,
            EntityLink? entityLink,int? entityLinkId):
           base(name,dateOfBirth,gender,photoFileName,isActive)
       {
            Favorites = new ();
            FeedBacks = new ();
            EntityLink = entityLink;
            EntityLinkId = entityLinkId;
        }

        private User(int id,Name name, DateTime dateOfBirth, string gender, string photoFileName, bool isActive,
             EntityLink? entityLink, int? entityLinkId) :
            base(id,name, dateOfBirth, gender, photoFileName, isActive)
        {
            Favorites = new ();
            FeedBacks = new ();
            EntityLink = entityLink;
            EntityLinkId = entityLinkId;
        }

        private User(string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive, EntityLink? entityLink, int? entityLinkId) :
            base(firstName,middleNames,lastName,dateOfBirth,gender,photoFileName,isActive)
        {
            Favorites = new ();
            FeedBacks = new ();
            EntityLink = entityLink;
            EntityLinkId = entityLinkId;
        }

        private User(int id,string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender,
           string photoFileName, bool isActive, EntityLink? entityLink, int? entityLinkId) : 
            base(id,firstName, middleNames, lastName, dateOfBirth, gender, photoFileName,
               isActive)
        {
            Favorites = new ();
            FeedBacks = new ();
            EntityLink = entityLink;
            EntityLinkId = entityLinkId;
        }

        public static User Create(Name name, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive, EntityLink? entityLink, int? entityLinkId)
        {
            var user = new User(name, dateOfBirth, gender, photoFileName, isActive,entityLink,entityLinkId);

            return user;
        }

        public static User Create(int id,Name name, DateTime dateOfBirth, string gender,
           string photoFileName, bool isActive, EntityLink? entityLink, int? entityLinkId)
        {
            var user = new User(id,name, dateOfBirth, gender, photoFileName, isActive, entityLink, entityLinkId);

            return user;
        }

        public static User Create(string firstName, string middleNames, string lastName, DateTime dateOfBirth, 
            string gender,string photoFileName, bool isActive, EntityLink? entityLink, int? entityLinkId)
        {
            var user = new User(firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive,
                entityLink,entityLinkId);

            return user;
        }

        public static User Create(int id,string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive, EntityLink? entityLink, int? entityLinkId)
        {
            var user = new User(id,firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive,
                 entityLink, entityLinkId);

            return user;
        }

        public void Update(Name name, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive, EntityLink? entityLink, int? entityLinkId)
        {
            base.Update(name,dateOfBirth,gender,photoFileName,isActive);  
            EntityLink = entityLink;
            EntityLinkId = entityLinkId;
        }

        public void Update(string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive, EntityLink? entityLink, int? entityLinkId)
        {
            base.Update(firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive);
            EntityLink = entityLink;
            EntityLinkId = entityLinkId;
        }
    }
}
