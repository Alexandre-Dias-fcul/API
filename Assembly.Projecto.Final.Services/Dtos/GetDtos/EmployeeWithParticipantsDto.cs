﻿using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.EmployeeUserDtos;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Dtos.GetDtos
{
    public class EmployeeWithParticipantsDto:PersonDto
    {
        public DateTime? HiredDate { get; set; }
        public DateTime? DateOfTermination { get; set; }
        public List<ParticipantWithAppointmentDto> Participants { get; set; }
    }
}
