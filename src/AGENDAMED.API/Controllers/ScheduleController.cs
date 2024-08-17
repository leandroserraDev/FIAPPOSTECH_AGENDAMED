using AGENDAMED.Application.AppServices.user.doctor.schedule;
using AGENDAMED.Application.Interface.AppServices.speciality;
using AGENDAMED.Application.Interface.AppServices.user.doctor.schedule;
using AGENDAMED.Domain.Enums;
using AGENDAMED.Domain.Interface.Services.notification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AGENDAMED.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ScheduleController : MainController
    {
        private readonly IScheduleSpecialityDoctorAppService _scheduleSpecialityDoctorAppService;
        private readonly INotificationErrorService _notificationErrorService;

        public ScheduleController(IScheduleSpecialityDoctorAppService scheduleSpecialityDoctorAppService, INotificationErrorService notificationErrorService)
       :base(notificationErrorService)
        {
            _scheduleSpecialityDoctorAppService = scheduleSpecialityDoctorAppService;
            _notificationErrorService = notificationErrorService;
        }

        [HttpGet("doctor/{doctorID}/speciality/{specialityID}")]
        public async Task<IActionResult> GetSchedule(string doctorID, long specialityID, DateTime date)
        {
            var result = await _scheduleSpecialityDoctorAppService.GetScheduleSpecialitieDoctor(doctorID, (ESpecialty)specialityID, date);

            return await CustomResponse(result);
                
                }
    }
}
