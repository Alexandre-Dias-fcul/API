﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos
{
    public class UpdateAccountDto
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
