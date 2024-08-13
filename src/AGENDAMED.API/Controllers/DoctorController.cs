using AGENDAMED.Application.DTOs.user;
using AGENDAMED.Application.DTOs.user.doctor;
using AGENDAMED.Application.DTOs.user.doctor.schedule;
using AGENDAMED.Application.DTOs.user.doctor.speciality;
using AGENDAMED.Application.DTOs.user.patient;
using AGENDAMED.Application.Interface.AppServices.speciality;
using AGENDAMED.Application.Interface.AppServices.user.doctor;
using AGENDAMED.Application.Interface.AppServices.user.doctor.schedule;
using AGENDAMED.Domain.Entities.user;
using AGENDAMED.Domain.Entities.user.doctor;
using AGENDAMED.Domain.Interface.Repositories.user.doctor.schedule;
using AGENDAMED.Domain.Interface.Services.notification;
using AGENDAMED.Domain.Interface.Services.user;
using AGENDAMED.Infra.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Remoting;

namespace AGENDAMED.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {

        private readonly IUserDoctorAppService _userDoctorAppService;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IScheduleSpecialityDoctorAppService _scheduleSpecialityDoctorAppService;
        private readonly IDoctorSpecialityAppService _doctorSpecialityAppService;
        private readonly INotificationErrorService _notificationErrorService;

        public DoctorController(IUserDoctorAppService userDoctorAppService, 
            IScheduleRepository scheduleRepository, 
            IDoctorSpecialityAppService doctorSpecialityAppService, 
            INotificationErrorService notificationErrorService, IScheduleSpecialityDoctorAppService scheduleSpecialityDoctorAppService)
        {
            _userDoctorAppService = userDoctorAppService;
            _scheduleRepository = scheduleRepository;
            _doctorSpecialityAppService = doctorSpecialityAppService;
            _notificationErrorService = notificationErrorService;
            _scheduleSpecialityDoctorAppService = scheduleSpecialityDoctorAppService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var result = await _userDoctorAppService.GetDoctors();
            return Ok(result);
        }

        #region User Doctor
        [HttpPost]
        public async Task<IActionResult> CreateDoctor(UserCreateDoctorViewModel createDoctorViewModel)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest();
            }

            var result = await _userDoctorAppService.CreateDoctor(createDoctorViewModel);


            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditDoctor(string id, UserEditDoctorViewModel editDoctorViewModel)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest();
            }

            var result = await _userDoctorAppService.EditDoctor(id, editDoctorViewModel);
            if(result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
        [HttpGet("{doctorID}")]
        public async Task<IActionResult> GetDoctorById(string doctorID)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest();
            }

            var result = await _userDoctorAppService.GetDoctorById(doctorID);
            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
        #endregion

        #region Schedule
        [HttpPost("schedule")]
        public async Task<IActionResult> CreateSchedule(ScheduleSpecialityDoctorCreateViewModel scheduleSpecialityDoctorCreateViewModel)
        {
            var result = await _scheduleSpecialityDoctorAppService.Create(scheduleSpecialityDoctorCreateViewModel.ToDomain());

            if(await _notificationErrorService.HasNotifications())
            {
                return BadRequest(new { Errors = _notificationErrorService.Notifications(), data = result });
            }
            return Ok(result);

        }

        [HttpGet("{doctorID}/schedule")]
        public async Task<IActionResult> GetScheduleDoctor(string doctorID)
        {

            var result = await _scheduleRepository.GetSchedulesDoctor(doctorID);

            return Ok(result);

        }

        [HttpPut("schedule")]
        public async Task<IActionResult> EditSchedule(ScheduleSpecialityDoctorCreateViewModel scheduleSpecialityDoctorCreateViewModel)
        {
            var result = await _scheduleSpecialityDoctorAppService.Edit(scheduleSpecialityDoctorCreateViewModel.ToDomain());

            if (await _notificationErrorService.HasNotifications())
            {
                return BadRequest(new { Errors = _notificationErrorService.Notifications(), data = result });
            }
            return Ok(result);
        }

        #endregion

        #region Speciality
        [HttpGet("{doctorID}/speciality")]
        public async Task<IActionResult> GetSpecialitiesDoctor(string doctorID)
        {
            var result = await _doctorSpecialityAppService.GetDoctorSpecialities(doctorID);


            return Ok(new {data= result });
        }




        [HttpPost("speciality")]
        public async Task<IActionResult> CreateSpeciality(DoctorSpecialityCreateViewModel createViewModel)
        {
            var result = await _doctorSpecialityAppService.Create(createViewModel);

            if (await _notificationErrorService.HasNotifications())
            {
                return BadRequest(new {Erros = _notificationErrorService.Notifications(), data = result});
            }

            return Ok(new {data = result});
        }

        [HttpPatch("{doctorID}/speciality/{specialityID}/mudarstatus")]
        public async Task<IActionResult> MudarStatus(string doctorID, long specialityID)
        {
            var result = await _doctorSpecialityAppService.MudarStatus(doctorID,specialityID);

            if (await _notificationErrorService.HasNotifications())
            {
                return BadRequest(new { Erros = _notificationErrorService.Notifications(), data = result });
            }

            return Ok(new { data = result });
        }

        #endregion
    }
}
