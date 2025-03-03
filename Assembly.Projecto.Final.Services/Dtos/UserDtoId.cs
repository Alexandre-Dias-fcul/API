using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Dtos
{
    public class UserDtoId:PersonDtoId
    {
        public EntityLinkDto EntityLink { get; set; }
    }
}
