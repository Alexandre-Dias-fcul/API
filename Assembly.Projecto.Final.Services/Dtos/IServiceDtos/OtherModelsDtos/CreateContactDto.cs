﻿using Assembly.Projecto.Final.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos
{
    public  class CreateContactDto
    {
        public ContactType ContactType { get; set; }
        public string Value { get; set; }
    }
}
