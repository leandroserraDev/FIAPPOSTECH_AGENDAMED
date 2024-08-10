
using AGENDAMED.Domain.Entities.appointment;
using AGENDAMED.Domain.Interface.Repositories.appointment;
using AGENDAMED.Domain.Interface.Services.appointment;
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

        public AppointmentService(IAppointmentRepository appointmentRepository)
            :base(appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
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
