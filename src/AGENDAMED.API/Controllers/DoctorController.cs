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
using AGENDAMED.Domain.Enums;
using AGENDAMED.Domain.Interface.Repositories.user.doctor.schedule;
using AGENDAMED.Domain.Interface.Services.appointment;
using AGENDAMED.Domain.Interface.Services.notification;
using AGENDAMED.Domain.Interface.Services.user;
using AGENDAMED.Domain.Interface.Services.user.doctor.schedule;
using AGENDAMED.Infra.Context;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
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
    public class DoctorController : MainController
    {

        private readonly IUserDoctorAppService _userDoctorAppService;
        private readonly IScheduleSpecialityDoctorAppService _scheduleSpecialityDoctorAppService;
        private readonly IDoctorSpecialityAppService _doctorSpecialityAppService;
        private readonly INotificationErrorService _notificationErrorService;
        private readonly IScheduleService _scheduleService;
        private readonly IAppointmentService _appointmentService;
        public DoctorController(IUserDoctorAppService userDoctorAppService,

            IDoctorSpecialityAppService doctorSpecialityAppService,
            INotificationErrorService notificationErrorService, IScheduleSpecialityDoctorAppService scheduleSpecialityDoctorAppService,
            IScheduleService scheduleService, IAppointmentService appointmentService)

            : base(notificationErrorService)
        {
            _userDoctorAppService = userDoctorAppService;
            _doctorSpecialityAppService = doctorSpecialityAppService;
            _notificationErrorService = notificationErrorService;
            _scheduleSpecialityDoctorAppService = scheduleSpecialityDoctorAppService;
            _scheduleService = scheduleService;
            _appointmentService = appointmentService;
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
       
            var result = await _userDoctorAppService.CreateDoctor(createDoctorViewModel);


           return await CustomResponse(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditDoctor(string id, UserEditDoctorViewModel editDoctorViewModel)
        {
        
            var result = await _userDoctorAppService.EditDoctor(id, editDoctorViewModel);
            return await CustomResponse(result);
        }
        [HttpGet("{doctorID}")]
        public async Task<IActionResult> GetDoctorById(string doctorID)
        {
        
            var result = await _userDoctorAppService.GetDoctorById(doctorID);
            return await CustomResponse(result);
        }
        #endregion

        #region Schedule
        [HttpPost("schedule")]
        public async Task<IActionResult> CreateSchedule(ScheduleSpecialityDoctorCreateViewModel scheduleSpecialityDoctorCreateViewModel)
        {
                var result = await _scheduleSpecialityDoctorAppService.Create(scheduleSpecialityDoctorCreateViewModel.ToDomain());

            return await CustomResponse(result);

        }

        [HttpGet("{doctorID}/schedule")]
        public async Task<IActionResult> GetScheduleDoctor(string doctorID)
        {

            var result = await _scheduleSpecialityDoctorAppService.GetSchedulesDoctor(doctorID);

            return await CustomResponse(result);

        }
        [HttpGet("{doctorID}/schedule/{specialityID}")]
        public async Task<IActionResult> GetScheduleDoctor(string doctorID, long specialityID)
        {

            var result = await _scheduleSpecialityDoctorAppService.GetScheduleSpecialitieDoctor(doctorID,(ESpecialty)specialityID);

            return await CustomResponse(result);

        }
        [HttpGet("speciality/{id}")]
        public async Task<IActionResult> GetDoctorBySpeciality(long id)
        {
            var resullt = await _userDoctorAppService.GetActiveBySpecialityID(id);

            return await CustomResponse(resullt);
        }
        


        [HttpPut("schedule")]
        public async Task<IActionResult> EditSchedule(ScheduleSpecialityDoctorCreateViewModel scheduleSpecialityDoctorCreateViewModel)
        {
            var result = await _scheduleSpecialityDoctorAppService.Edit(scheduleSpecialityDoctorCreateViewModel.ToDomain());

            return await CustomResponse(result);
        }



        #endregion

        #region Speciality
        [HttpGet("{doctorID}/speciality")]
        public async Task<IActionResult> GetSpecialitiesDoctor(string doctorID)
        {
            var result = await _doctorSpecialityAppService.GetDoctorSpecialities(doctorID);

            return await CustomResponse(result);
        }

        [HttpGet("scheduleTime")]
        public async Task<IActionResult> GetScheduleTime(string doctorID, long specialityID, DateTime data)
        {
            var result = await _scheduleService.GetScheduleDoctor(doctorID, (ESpecialty)specialityID, data);

            return await CustomResponse(result);
        }



        [HttpPost("speciality")]
        public async Task<IActionResult> CreateSpeciality(DoctorSpecialityCreateViewModel createViewModel)
        {
            var result = await _doctorSpecialityAppService.Create(createViewModel);

            if (await _notificationErrorService.HasNotifications())
            {
                return BadRequest(new {Erros = _notificationErrorService.Notifications(), data = result});
            }

            return await CustomResponse(result);
        }

        [HttpPatch("{doctorID}/speciality/{specialityID}/mudarstatus")]
        public async Task<IActionResult> MudarStatus(string doctorID, long specialityID)
        {
            var result = await _doctorSpecialityAppService.MudarStatus(doctorID,specialityID);

            return await CustomResponse(result);
        }

        #endregion


        [HttpGet("appointments")]
        [Authorize]
        public async Task<IActionResult> GetAppointmens()
        {
            var appointments = await _appointmentService.GetAppointmentsUserLoggedDoctor();

            return await CustomResponse(appointments);
        }
    }
}
