﻿using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.EmployeeUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Dtos.GetDtos
{
    public class UserAllDto:PersonDto
    {
        public EntityLinkAllDto? EntityLink { get; set; } = new();
    }
}
