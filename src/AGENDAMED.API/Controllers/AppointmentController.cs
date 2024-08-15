using AGENDAMED.Application.DTOs.appointment;
using AGENDAMED.Domain.Entities.appointment;
using AGENDAMED.Domain.Interface.Services.appointment;
using AGENDAMED.Domain.Interface.Services.notification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace AGENDAMED.API.Controllers
{
    /// <summary>
    /// Controller Appointment 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AppointmentController : MainController
    {

        private readonly IAppointmentService _appointmentService;
        private readonly INotificationErrorService _notificationErrorService;

        public AppointmentController(IAppointmentService appointmentService, INotificationErrorService notificationErrorService)
            :base(notificationErrorService)
        {
            _appointmentService = appointmentService;
            _notificationErrorService = notificationErrorService;
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
        public async Task<IActionResult> Create(AppointmentCreateViewModel appointment)
        {

            var result = await _appointmentService.Create(appointment.ToDomain());

            return await CustomResponse(result);
        }

        [HttpPut("{id}/reagendar")]
        public async Task<IActionResult> Reagendar(long id, AppointmentCreateViewModel appointment)
        {

            var result = await _appointmentService.Reagendar(id,appointment.ToDomain());

            return await CustomResponse(result);
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> CancelAppointment(long id)
        {
            var result = await _appointmentService.CancelAppointment(id);

            return await CustomResponse(result);
        }

    }
}
