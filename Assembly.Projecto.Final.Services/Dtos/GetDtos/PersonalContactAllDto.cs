using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Dtos.GetDtos
{
    public class PersonalContactAllDto
    {
        public string Name { get; private set; }
        public bool IsPrimary { get; private set; }
        public string Notes { get; private set; }
        public List<PersonalContactDetailDto> PersonalContactDetails { get; set; }
    }
}
