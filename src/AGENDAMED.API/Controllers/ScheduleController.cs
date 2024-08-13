using AGENDAMED.Application.AppServices.user.doctor.schedule;
using AGENDAMED.Application.Interface.AppServices.speciality;
using AGENDAMED.Application.Interface.AppServices.user.doctor.schedule;
using AGENDAMED.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AGENDAMED.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleSpecialityDoctorAppService _scheduleSpecialityDoctorAppService;

        public ScheduleController(IScheduleSpecialityDoctorAppService scheduleSpecialityDoctorAppService)
        {
            _scheduleSpecialityDoctorAppService = scheduleSpecialityDoctorAppService;
        }

        [HttpGet("doctor/{doctorID}/speciality/{specialityID}")]
        public async Task<IActionResult> GetSchedule(string doctorID, long specialityID, DateTime date)
        {
            var result = await _scheduleSpecialityDoctorAppService.GetScheduleSpecialitieDoctor(doctorID, (ESpecialty)specialityID, date);

            return Ok(new { data = result});
        }
    }
}
