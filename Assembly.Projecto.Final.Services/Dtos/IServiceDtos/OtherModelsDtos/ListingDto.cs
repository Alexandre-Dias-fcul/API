using Assembly.Projecto.Final.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos
{
    public class ListingDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public ListingStatus Status { get; set; }
        public int? NumberOfRooms { get; set; }
        public int? NumberOfBathrooms { get; set; }
        public int? NumberOfKitchens { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public double Area { get; set; }
        public int? Parking { get; set; }
        public string Description { get; set; }
        public string MainImageFileName { get; set; }
        public string OtherImagesFileNames { get; set; }
        public int AgentId { get; set; }
    }
}
