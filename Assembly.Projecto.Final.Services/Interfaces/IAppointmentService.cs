﻿using Assembly.Projecto.Final.Domain.Enums;
using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Dtos.GetDtos;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos;
using Assembly.Projecto.Final.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Interfaces
{
    public interface IAppointmentService:IService<CreateAppointmentServiceDto,AppointmentDto,int>
    {
        public ParticipantDto AddParticipant(int appointmentId, int employeeId);
        public ParticipantDto DeleteParticipant(int appointmentId, int participantId);
        public AppointmentAllDto GetByIdWithParticipants(int id);
    }
}
