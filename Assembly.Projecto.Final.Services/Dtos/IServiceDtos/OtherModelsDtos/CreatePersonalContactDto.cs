using Assembly.Projecto.Final.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos
{
    public class CreatePersonalContactDto
    {
        public string Name { get; set; }
        public bool IsPrimary { get; set; }
        public string Notes { get; set; }
        public RoleType? Role { get; set; }
        public int EmployeeId { get; set; }
    }
}
