using Assembly.Projecto.Final.Domain.Enums;
using Assembly.Projecto.Final.Domain.Models;

namespace Assembly.Projecto.Final.WebAPI.Dtos
{
    public class ContactDto
    {
        public ContactType ContactType { get; set; }
        public string Value { get; set; }

    }
}
