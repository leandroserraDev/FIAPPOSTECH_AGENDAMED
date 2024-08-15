using AGENDAMED.Application.AppServices.user.patient;
using AGENDAMED.Application.DTOs.user.patient;
using AGENDAMED.Application.Interface.AppServices.user.patient;
using AGENDAMED.Domain.Entities.user;
using AGENDAMED.Domain.Entities.user.doctor.schedule;
using AGENDAMED.Domain.Interface.Services.appointment;
using AGENDAMED.Domain.Interface.Services.notification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace AGENDAMED.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : MainController
    {

        private readonly UserManager<User> _userManager;
        private readonly IAppointmentService _appointmentService;
        private readonly IUserPatientAppService _userPatientAppService;
        private readonly INotificationErrorService _notificationErrorService;

        public PatientController(UserManager<User> userManager, IAppointmentService appointmentService, IUserPatientAppService userPatientAppService, INotificationErrorService notificationErrorService)
        :base(notificationErrorService)
        {
            _userManager = userManager;
            _appointmentService = appointmentService;
            _userPatientAppService = userPatientAppService;
            _notificationErrorService = notificationErrorService;
        }

        [HttpGet("appointments/{id}")]
        public async Task<IActionResult> GetMyAppointments(string id)
        {
            var appointments = await _appointmentService.GetPatientAppointments(id);

            return await CustomResponse(appointments);
        }

        [HttpGet("appointment/{id}")]
        public async Task<IActionResult> GetMyAppointments(long id)
        {
            var appointments = await _appointmentService.GetPatientApppointment(id);

            return await CustomResponse(appointments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var result = await _userPatientAppService.GetById(id);

            return await CustomResponse(result);
        }

        [HttpGet("appointments")]
        [Authorize]
        public async Task<IActionResult> GetAppointmens()
        {
            var appointments = await _appointmentService.GetAppointmentsUserLoggedPatient();


            return await CustomResponse(appointments);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetLoggedUserData()
        {
            var result = await _userPatientAppService.GetByLoggedUser();

            return await CustomResponse(result);
        }

        [HttpPost]
        public async  Task<IActionResult> Create(UserCreatePatientViewModel userCreatePatientViewModel)
        {
            var result = await _userPatientAppService.Create(userCreatePatientViewModel);

            return await CustomResponse(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(string id, UserEditPatientViewModel userEditPatientViewModel)
        {
            var result = await _userPatientAppService.Edit(id,userEditPatientViewModel);

            return await CustomResponse(result);
        }


    }
}
