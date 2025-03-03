using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Dtos
{
    public class EmployeeDtoId:PersonDtoId
    {
        public DateTime? HiredDate { get; set; }
        public DateTime? DateOfTermination { get; set; }
        public EntityLinkDtoId EntityLink { get; set; } = new();
    }
}
