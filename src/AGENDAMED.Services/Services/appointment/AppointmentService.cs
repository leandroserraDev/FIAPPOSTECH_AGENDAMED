
using AGENDAMED.Domain.Entities.appointment;
using AGENDAMED.Domain.Interface.Repositories.appointment;
using AGENDAMED.Domain.Interface.Services.appointment;
using AGENDAMED.Domain.Interface.Services.loggedUser;
using AGENDAMED.Services.Services.loggedUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Services.Services.appointment
{
    public class AppointmentService : ServiceBase<Appointment>, IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly ILoggedUserService _loggedUserService;

        public AppointmentService(IAppointmentRepository appointmentRepository, ILoggedUserService loggedUserService)
            : base(appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
            _loggedUserService = loggedUserService;
        }

        public async  Task<List<Appointment>> GetAppointmentsUserLogged()
        {
            var usuarioLogado = await _loggedUserService.LoggedUser();
           var result = await _appointmentRepository.GetPatientAppointments(obj => obj.PatientID.Equals(usuarioLogado.Id));
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
    }
}
