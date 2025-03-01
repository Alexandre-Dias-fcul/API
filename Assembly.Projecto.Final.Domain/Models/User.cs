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

        private List<Favorite> _favorites;
        public IReadOnlyCollection<Favorite> Favorites => _favorites.AsReadOnly();

        private List<FeedBack> _feedBacks;
        public IReadOnlyCollection<FeedBack> FeedBacks => _feedBacks.AsReadOnly();

        private User() : base()
        {
            EntityLinkId = 0;
        }

        private User(Name name, DateTime? dateOfBirth, string gender, string photoFileName, bool isActive):
           base(name,dateOfBirth,gender,photoFileName,isActive)
       {
            _favorites = new ();
            _feedBacks = new ();
        }

        private User(int id,Name name, DateTime? dateOfBirth, string gender, string photoFileName, bool isActive) 
            :base(id,name, dateOfBirth, gender, photoFileName, isActive)
        {
            _favorites = new();
            _feedBacks = new();
        }

        private User(string firstName, string middleNames, string lastName, DateTime? dateOfBirth, string gender,
            string photoFileName, bool isActive) :
            base(firstName,middleNames,lastName,dateOfBirth,gender,photoFileName,isActive)
        {
            _favorites = new();
            _feedBacks = new();
        }

        private User(int id,string firstName, string middleNames, string lastName, DateTime? dateOfBirth, string gender,
           string photoFileName, bool isActive) : 
            base(id,firstName, middleNames, lastName, dateOfBirth, gender, photoFileName,isActive)
        {
            _favorites = new();
            _feedBacks = new();
        }

        public static User Create(Name name, DateTime? dateOfBirth, string gender,
            string photoFileName, bool isActive)
        {
            var user = new User(name, dateOfBirth, gender, photoFileName, isActive);

            return user;
        }

        public static User Create(int id,Name name, DateTime? dateOfBirth, string gender,
           string photoFileName, bool isActive)
        {
            var user = new User(id,name, dateOfBirth, gender, photoFileName, isActive);

            return user;
        }

        public static User Create(string firstName, string middleNames, string lastName, DateTime? dateOfBirth, 
            string gender,string photoFileName, bool isActive)
        {
            var user = new User(firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive);

            return user;
        }

        public static User Create(int id,string firstName, string middleNames, string lastName, DateTime? dateOfBirth, string gender,
            string photoFileName, bool isActive)
        {
            var user = new User(id,firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive);

            return user;
        }

        public void Update(Name name, DateTime? dateOfBirth, string gender, string photoFileName, bool isActive)
        {
            base.Update(name,dateOfBirth,gender,photoFileName,isActive);
        }

        public void Update(string firstName, string middleNames, string lastName, DateTime? dateOfBirth, string gender,
            string photoFileName, bool isActive)
        {
            base.Update(firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive);
        }

        public void SetEntityLink(EntityLink entityLink)
        {
            if (entityLink == null)
            {
                throw new ArgumentNullException();
            }

            EntityLink = entityLink;
            EntityLinkId = entityLink.Id;
        }

        public void AddFavorite(Favorite favorite) 
        {
            if(favorite == null) 
            {
                throw new ArgumentNullException();
            }

            _favorites.Add(favorite);
        }

        public void AddFeedBack(FeedBack feedBack) 
        { 
            if(feedBack == null) 
            {
                throw new ArgumentNullException();
            }

            _feedBacks.Add(feedBack);
        }
    }
}
