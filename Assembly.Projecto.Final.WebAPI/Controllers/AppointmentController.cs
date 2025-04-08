using Assembly.Projecto.Final.Domain.Enums;
using Assembly.Projecto.Final.Services.Dtos.GetDtos;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos;
using Assembly.Projecto.Final.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Assembly.Projecto.Final.WebAPI.Controllers
{
    public class AppointmentController : BaseController
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public IEnumerable<AppointmentDto> GetAll()
        {
            return _appointmentService.GetAll();
        }

        [HttpGet("{id:int}")]
        public ActionResult<AppointmentDto> GetById(int id)
        {
            return Ok(_appointmentService.GetById(id));
        }

        [HttpGet("GetByIdWithParticipants/{id:int}")]
        public ActionResult<AppointmentAllDto> GetByIdWithParticipants(int id)
        {
            return Ok(_appointmentService.GetByIdWithParticipants(id));
        }

        [HttpPost]
        public ActionResult<AppointmentDto> Add(CreateAppointmentDto createAppointmentDto)
        {
            return Ok(_appointmentService.Add(createAppointmentDto));
        }

        [HttpPost("AddParticipant/{appointmentId:int}/{employeeId:int}")]
        public ActionResult<ParticipantDto> AddParticipant([FromRoute] int appointmentId, [FromRoute] int employeeId,
                       [FromQuery] RoleType? role)
        {

            return Ok(_appointmentService.AddParticipant(appointmentId, employeeId, role));
        }

        [HttpPut("{id:int}")]
        public ActionResult<ParticipantDto> Update([FromRoute] int id, [FromBody] AppointmentDto appointmentDto) 
        {
            if (id != appointmentDto.Id) 
            {
                return BadRequest("Os ids do appointment não coincidem.");
            }

            return Ok(_appointmentService.Update(appointmentDto));
        }

        [HttpDelete("DeleteParticipant/{appointmentId:int}/{participantId:int}")]
        public ActionResult<ParticipantDto> DeleteParticipant([FromRoute] int appointmentId,[FromRoute] int participantId) 
        {
            return Ok(_appointmentService.DeleteParticipant(appointmentId, participantId));
        }

        [HttpDelete("{id:int}")]
        public ActionResult<ParticipantDto> Delete(int id) 
        {
            return Ok(_appointmentService.Delete(id));
        }

    }
}
