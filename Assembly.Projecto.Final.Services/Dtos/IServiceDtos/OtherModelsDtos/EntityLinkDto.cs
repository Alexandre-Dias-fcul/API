﻿using Assembly.Projecto.Final.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos
{
    public class EntityLinkDto
    {
        public int Id { get; set; }
        public EntityType EntityType { get; set; }
        public int? EntityId { get; set; }
    }
}
