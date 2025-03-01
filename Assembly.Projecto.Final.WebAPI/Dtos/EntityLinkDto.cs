using Assembly.Projecto.Final.Domain.Models;

namespace Assembly.Projecto.Final.WebAPI.Dtos
{
    public class EntityLinkDto
    {
        public List<ContactDto> Contacts { get; set; } = new();
        public List<AddressDto> Addresses { get; set; } = new();
        public AccountDto Account { get; set; } = new();
    }
}
