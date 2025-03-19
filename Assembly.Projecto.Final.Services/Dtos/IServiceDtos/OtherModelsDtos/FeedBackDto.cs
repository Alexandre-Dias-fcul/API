using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos
{
    public class FeedBackDto
    {
        public int Id { get; set; }
        public int? Rate { get; set; }
        public string Comment { get; set; }
        public DateTime? CommentDate { get; set; }
    }
}
