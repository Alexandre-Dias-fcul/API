using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos
{
    public class CreateReassignDto
    {
        public int OlderEmployeeId { get; set; }
        public int NewEmployeeId { get; set; }
        public int ReassignBy { get; set; }
        public DateTime ReassignmentDate { get; set; }
    }
}
