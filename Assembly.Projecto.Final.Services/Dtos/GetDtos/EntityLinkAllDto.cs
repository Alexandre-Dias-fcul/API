using Assembly.Projecto.Final.Domain.Enums;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Dtos.GetDtos
{
    public class EntityLinkAllDto
    {
        public int Id { get; set; }
        public EntityType EntityType { get; set; }
        public int? EntityId { get; set; }
        public List<ContactDto> Contacts { get; set; } = new();
        public List<AddressDto> Addresses { get; set; } = new();
        public AccountDto Account { get; set; } = new();
    }
}
