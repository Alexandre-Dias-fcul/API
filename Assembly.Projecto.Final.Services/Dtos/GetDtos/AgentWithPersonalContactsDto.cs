﻿using Assembly.Projecto.Final.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Dtos.GetDtos
{
    public class AgentWithPersonalContactsDto:EmployeeWithPersonalContactsDto
    {
        public RoleType Role { get; set; }
        public int? SupervisorId { get; set; }
    }
}
