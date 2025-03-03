using Assembly.Projecto.Final.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Dtos
{
    public class PersonDtoId
    {
        public int Id { get; set; }
        public NameDto Name { get; set; } = new();
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string PhotoFileName { get; set; }
        public bool IsActive { get; set; }
    }
}
