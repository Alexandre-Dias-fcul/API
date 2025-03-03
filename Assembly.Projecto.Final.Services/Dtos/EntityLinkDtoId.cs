using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Dtos
{
    public class EntityLinkDtoId
    {
        public List<ContactDtoId> Contacts { get; set; } = new();
        public List<AddressDtoId> Addresses { get; set; } = new();
        public AccountDto Account { get; set; } = new();
    }
}
