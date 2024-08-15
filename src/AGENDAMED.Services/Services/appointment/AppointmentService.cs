
using AGENDAMED.Domain.Entities.appointment;
using AGENDAMED.Domain.Interface.Repositories.appointment;
using AGENDAMED.Domain.Interface.Services.appointment;
using AGENDAMED.Domain.Interface.Services.email.appointment;
using AGENDAMED.Domain.Interface.Services.loggedUser;
using AGENDAMED.Domain.Interface.Services.notification;
using AGENDAMED.Services.Services.loggedUser;
using Hangfire;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AGENDAMED.Services.Services.appointment
{
    public class AppointmentService : ServiceBase<Appointment>, IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly ILoggedUserService _loggedUserService;
        private readonly INotificationErrorService _notificationErrorService;
        private readonly IConfiguration _configuration;
        public AppointmentService(IAppointmentRepository appointmentRepository, ILoggedUserService loggedUserService, INotificationErrorService notificationErrorService, IConfiguration configuration)
            : base(appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
            _loggedUserService = loggedUserService;
            _notificationErrorService = notificationErrorService;
            _configuration = configuration;
        }

        public override async Task<Appointment> Create(Appointment entity)
        {
            var result = await base.Create(entity);
            ///enviar email
            ///
            var appoint = await _appointmentRepository.GetPatientApppointment(obj => obj.ID.Equals(result.ID));
            var email = new EmailAppointment(string.Concat(appoint.Doctor.Email, ",", appoint.Patient.Email), "Consulta Agendada", "Nova Consulta", _configuration);
            email.SendEmail();
            return result;
        }
        public async Task<bool> CancelAppointment(long id)
        {
            var usuarioLogado = await _loggedUserService.LoggedUser();

            var appointToCancel = await _appointmentRepository.GetPatientApppointmentInclude(obj => obj.ID.Equals(id));

            if (appointToCancel == null) 
            {
                await _notificationErrorService.AddNotification("Consulta não encontrada");
                return false;
            }

            if (appointToCancel.Deleted)
            {
                await _notificationErrorService.AddNotification("Consulta já foi cancelada");
                return false;
            }

            if(appointToCancel.DoctorID != usuarioLogado.Id && appointToCancel.PatientID != usuarioLogado.Id) 
            {
                await _notificationErrorService.AddNotification("Você não tem permissão");
                return false;
            }

            appointToCancel.MudarStatus();

            var result = await _appointmentRepository.Update(appointToCancel);

            ///enviar email
            ///
            var appoint = await _appointmentRepository.GetPatientApppointment(obj => obj.ID.Equals(result.ID));
            var email = new EmailAppointment(string.Concat(appoint.Doctor.Email, ",", appoint.Patient.Email), "Consulta Cancelada", "Consulta Cancelada", _configuration);
            email.SendEmail();

            return true;
        }

        public async  Task<List<Appointment>> GetAppointmentsUserLoggedPatient()
        {
            var usuarioLogado = await _loggedUserService.LoggedUser();
           var result = await _appointmentRepository.GetPatientAppointments(obj => obj.PatientID.Equals(usuarioLogado.Id));
            return result.ToList();
        }

        public async Task<List<Appointment>> GetAppointmentsUserLoggedDoctor()
        {
            var usuarioLogado = await _loggedUserService.LoggedUser();
            var result = await _appointmentRepository.GetPatientAppointments(obj => obj.DoctorID.Equals(usuarioLogado.Id));
            return result.ToList();
        }

        public async Task<List<Appointment>> GetDoctorAppointments(Expression<Func<Appointment, bool>> expression)
        {
            var result = await _appointmentRepository.GetDoctorAppointments(expression);

            return result;
        }

        public async Task<List<Appointment>> GetPatientAppointments(string patientID)
        {
            var result = await _appointmentRepository.GetDoctorAppointments(obj => obj.PatientID.Equals(patientID));

            return result;
        }

        public async Task<Appointment> GetPatientApppointment(long id)
        {
            return await _appointmentRepository.GetPatientApppointment(obj => obj.ID.Equals(id));
        }

        public async Task<Appointment> Reagendar(long id, Appointment entity)
        {
            var result = await _appointmentRepository.GetPatientApppointment(obj => obj.ID.Equals(id));
            var userLogged = await _loggedUserService.LoggedUser();
            if (result == null) {
                await _notificationErrorService.AddNotification("Não encontrada");
                return null;
            }

            if(result.DoctorID != userLogged.Id && result.PatientID != userLogged.Id)
            {
                await _notificationErrorService.AddNotification("Sem permissão");
                return null;
            }

            result.AddDate(entity.Date);

            var resultUpdate = await _appointmentRepository.Update(entity);



            if(resultUpdate != null)
            {
                var appoint = await _appointmentRepository.GetPatientApppointment(obj => obj.ID.Equals(result.ID));
                var email = new EmailAppointment(string.Concat(appoint.Doctor.Email, ",", appoint.Patient.Email), "Consulta Cancelada", "Consulta Cancelada", _configuration);
                email.SendEmail();
                return resultUpdate;
            }


            return null;
        }

        private void SendEmailHangFire()
        {
            

        }

        public async Task<List<Appointment>> GetAppointmentsOneHour()
        {
            return await _appointmentRepository.GetAppointmentsOneHour();
        }
    }
}
