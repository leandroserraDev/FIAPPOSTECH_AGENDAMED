using AGENDAMED.Domain.Entities.user;
using AGENDAMED.Domain.Entities.user.doctor.schedule;
using AGENDAMED.Domain.Interface.Services.appointment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace AGENDAMED.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {

        private readonly UserManager<User> _userManager;
        private readonly IAppointmentService _appointmentService;

        public PatientController(UserManager<User> userManager, IAppointmentService appointmentService)
        {
            _userManager = userManager;
            _appointmentService = appointmentService;
        }

        [HttpGet("appointments/{id}")]
        public async Task<IActionResult> GetMyAppointments(string id)
        {
            var appointments = await _appointmentService.GetPatientAppointments(id);

            return Ok(appointments);
        }

        [HttpPost]
        public async Task<IActionResult> TGeste(ScheduleSpecialityDoctor teste)
        {
            return Ok(teste);
        }


    }
}
