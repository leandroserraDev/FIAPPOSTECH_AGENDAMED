using AGENDAMED.Application.DTOs.appointment;
using AGENDAMED.Domain.Entities.appointment;
using AGENDAMED.Domain.Interface.Services.appointment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AGENDAMED.API.Controllers
{
    /// <summary>
    /// Controller Appointment 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {

        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        /// <summary>
        /// Get list apointment system
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public async Task<IActionResult> List()
        {

            return Ok();
        }

        /// <summary>
        /// Create a appoint
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> List(AppointmentCreateViewModel appointment)
        {
            var result = await _appointmentService.Create(appointment.ToDomain());

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelAppointment(int id)
        {
            return Ok();
        }

    }
}
