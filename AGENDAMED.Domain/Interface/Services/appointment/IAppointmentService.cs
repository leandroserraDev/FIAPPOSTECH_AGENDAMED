using AGENDAMED.Domain.Entities.appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Domain.Interface.Services.appointment
{
    public interface IAppointmentService : IServiceBase<Appointment>
    {
        Task<List<Appointment>> GetPatientAppointments(string patientID);
        Task<List<Appointment>> GetAppointmentsOneHour();

        Task<Appointment> GetPatientApppointment(long id);
        Task<Appointment> Reagendar(long id, Appointment entity);

        Task<bool> CancelAppointment(long id);

        Task<List<Appointment>> GetAppointmentsUserLoggedPatient();
        Task<List<Appointment>> GetAppointmentsUserLoggedDoctor();


        Task<List<Appointment>> GetDoctorAppointments(Expression<Func<Appointment, bool>> expression);


    }
}
