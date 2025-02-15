using Assembly.Projecto.Final.Domain.Common;
using System;
using System.Collections.Generic;
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
        public List<Favorite> Favorites { get; private set; }
        public List<FeedBack> FeedBacks { get; private set; }
        public int AgentId { get; private set; }
        public Agent Agent { get; private set; }
        public List<Reassign> Reassigns { get; private set; }

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
            Favorites = new ();
            FeedBacks = new ();
            Reassigns = new ();
            AgentId = 0;
        }


        private Listing(string type, string status, int numberOfRooms, int numberOfBathrooms, int numberOfKitchens, 
            decimal price, string location, double area, int parking, string description, string mainImageFileName, 
            string otherImagesFileNames,Agent agent,int agentId):this()
        {
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
            Agent = agent;
            AgentId = agentId;
        }

        private Listing(int id,string type, string status, int numberOfRooms, int numberOfBathrooms, int numberOfKitchens,
           decimal price, string location, double area, int parking, string description, string mainImageFileName,
           string otherImagesFileNames, Agent agent, int agentId) : this(type,status,numberOfRooms,numberOfBathrooms,numberOfKitchens,
           price,location,area,parking,description,mainImageFileName, otherImagesFileNames,agent,agentId)
        {
            Id = id;
        }

        public static Listing Create(string type, string status, int numberOfRooms, int numberOfBathrooms, int numberOfKitchens,
            decimal price, string location, double area, int parking, string description, string mainImageFileName,
            string otherImagesFileNames, Agent agent, int agentId) 
        {
            var listing = new Listing(type,status,numberOfRooms,numberOfBathrooms, numberOfKitchens,
             price, location, area, parking,description,mainImageFileName,otherImagesFileNames,agent,agentId);

            return listing;
        }

        public static Listing Create(int id,string type, string status, int numberOfRooms, int numberOfBathrooms, int numberOfKitchens,
            decimal price, string location, double area, int parking, string description, string mainImageFileName,
            string otherImagesFileNames, Agent agent, int agentId) 
        {
            var listing = new Listing(id,type, status, numberOfRooms, numberOfBathrooms, numberOfKitchens,
             price, location, area, parking, description, mainImageFileName, otherImagesFileNames, agent, agentId);

            return listing;
        }

        public void Update(string type, string status, int numberOfRooms, int numberOfBathrooms, int numberOfKitchens,
            decimal price, string location, double area, int parking, string description, string mainImageFileName,
            string otherImagesFileNames, Agent agent, int agentId)
        {
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
            Agent= agent;
            AgentId = agentId;
            Updated = DateTime.Now;
        }
    }
}
