using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Models
{
    public class Listing : AuditableEntity<int>
    {
        public string Type { get; private set; }
        public string Status { get; private set; }
        public int? NumberOfRooms { get; private set; }
        public int? NumberOfBathrooms { get; private set; }
        public int? NumberOfKitchens { get; private set; }
        public decimal Price { get; private set; }
        public string Location { get; private set; }
        public double Area { get; private set; }
        public int? Parking { get; private set; }
        public string Description { get; private set; }
        public string MainImageFileName { get; private set; }
        public string OtherImagesFileNames { get; private set; }

        private List<Favorite> _favorites;
        public IReadOnlyCollection<Favorite> Favorites => _favorites.AsReadOnly();

        private List<FeedBack> _feedBacks;
        public IReadOnlyCollection<FeedBack> FeedBacks => _feedBacks.AsReadOnly();
        public int AgentId { get; private set; }
        public Agent Agent { get; private set; }

        private List<Reassign> _reassigns;
        public IReadOnlyCollection<Reassign> Reassigns => _reassigns.AsReadOnly();

        private Listing()
        {
            Type = string.Empty;
            Status = string.Empty;
            NumberOfRooms = 0;
            NumberOfBathrooms = 0;
            NumberOfKitchens = 0;
            Price = 0;
            Location = string.Empty;
            Area = 0;
            Parking = 0;
            Description = string.Empty;
            MainImageFileName = string.Empty;
            OtherImagesFileNames = string.Empty;
            Created = DateTime.Now;
            _favorites = new ();
            _feedBacks = new ();
            _reassigns = new ();
            AgentId = 0;
        }


        private Listing(string type, string status, int? numberOfRooms, int? numberOfBathrooms, int? numberOfKitchens, 
            decimal price, string location, double area, int? parking, string description, string mainImageFileName, 
            string otherImagesFileNames):this()
        {
            DomainValidation(type, status, numberOfRooms, numberOfBathrooms, numberOfKitchens, price, location, area, parking,
               description, mainImageFileName, otherImagesFileNames);
        }

        private Listing(int id,string type, string status, int? numberOfRooms, int? numberOfBathrooms, int? numberOfKitchens,
           decimal price, string location, double area, int? parking, string description, string mainImageFileName,
           string otherImagesFileNames) : this(type,status,numberOfRooms,numberOfBathrooms,numberOfKitchens,
           price,location,area,parking,description,mainImageFileName, otherImagesFileNames)
        {
            Id = id;
        }

        public static Listing Create(string type, string status, int? numberOfRooms, int? numberOfBathrooms, int? numberOfKitchens,
            decimal price, string location, double area, int? parking, string description, string mainImageFileName,
            string otherImagesFileNames) 
        {
            var listing = new Listing(type,status,numberOfRooms,numberOfBathrooms, numberOfKitchens,
             price, location, area, parking,description,mainImageFileName,otherImagesFileNames);

            return listing;
        }

        public static Listing Create(int id,string type, string status, int? numberOfRooms, int? numberOfBathrooms,
            int? numberOfKitchens,decimal price, string location, double area, int? parking, string description, 
            string mainImageFileName,string otherImagesFileNames) 
        {
            var listing = new Listing(id,type, status, numberOfRooms, numberOfBathrooms, numberOfKitchens,
             price, location, area, parking, description, mainImageFileName, otherImagesFileNames);

            return listing;
        }

        public void Update(string type, string status, int? numberOfRooms, int? numberOfBathrooms, int? numberOfKitchens,
            decimal price, string location, double area, int? parking, string description, string mainImageFileName,
            string otherImagesFileNames)
        {

            DomainValidation(type,status,numberOfRooms,numberOfBathrooms,numberOfKitchens,price,location,area,parking,
               description, mainImageFileName,otherImagesFileNames);
        }

        public void DomainValidation(string type, string status, int? numberOfRooms, int? numberOfBathrooms, 
            int? numberOfKitchens,decimal price, string location, double area, int? parking, string description, 
            string mainImageFileName,string otherImagesFileNames) 
        {
            DomainExceptionValidation.When(type == null,"Erro: o tipo de propriedade é obrigatório.");
            DomainExceptionValidation.When(type != null && type.Length > 250, " Erro: o tipo de propriedade não pode" +
                " ter mais de 250 caracteres.");
            DomainExceptionValidation.When(status == null, "Erro: o estado da propriedade é obrigatório.");
            DomainExceptionValidation.When(status != null && status.Length > 50, " Erro: o estado da propriedade não" +
                " pode ter mais de 50 caracteres.");
            DomainExceptionValidation.When(location == null, "Erro: a localização da propriedade é obrigatória.");
            DomainExceptionValidation.When(location != null && location.Length>250 ,"Erro: a localização da propriedade " +
                "não pode ter mais de 250 caracteres.");
            DomainExceptionValidation.When(description == null, "Erro: a descrição da propriedade é obrigatória.");
            DomainExceptionValidation.When(description != null && description.Length>5000, " Erro: a descrição da" +
                "propriedade não pode ter mais de 5000 caracters.");
            DomainExceptionValidation.When(mainImageFileName != null && mainImageFileName.Length > 300, " Erro:" +
                " o nome do ficheiro não pode ter mais de 300 caracteres.");
            DomainExceptionValidation.When(otherImagesFileNames != null && otherImagesFileNames.Length > 1000, "Erro:" +
                " o campo não pode ter mais de 1000 caracteres.");


            Type = type;
            Status = status;
            NumberOfRooms = numberOfRooms;
            NumberOfBathrooms = numberOfBathrooms;
            NumberOfKitchens = numberOfKitchens;
            Price = price;
            Location = location;
            Area = area;
            Parking = parking;
            Description = description;
            MainImageFileName = mainImageFileName;
            OtherImagesFileNames = otherImagesFileNames;
        }
        public void SetAgent(Agent agent) 
        {
            DomainExceptionValidation.When(agent == null, $"Erro: Não foi encontrada a entidade {nameof(agent)}.");

            Agent = agent;
            AgentId = Agent.Id;
        }

        public void AddFavorite(Favorite favorite)
        {
            DomainExceptionValidation.When(favorite == null, $"Erro: Não foi encontrada a entidade {nameof(favorite)}.");

            _favorites.Add(favorite);
        }

        public void AddFeedBack(FeedBack feedBack)
        {
            DomainExceptionValidation.When(feedBack == null, $"Erro: Não foi encontrada a entidade {nameof(feedBack)}.");

            _feedBacks.Add(feedBack);
        }

        public void AddReassign(Reassign reassign) 
        {
             DomainExceptionValidation.When(reassign == null, $"Erro: Não foi encontrada a entidade {nameof(reassign)}.");

            _reassigns.Add(reassign);
        }
    }
}
