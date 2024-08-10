using AGENDAMED.Domain.Entities.appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Domain.Interface.Repositories.appointment
{
    public interface IAppointmentRepository : IRepositoryBase<Appointment>
    {
        Task<List<Appointment>> GetPatientAppointments(Expression<Func<Appointment, bool>> expression);
        Task<List<Appointment>> GetDoctorAppointments(Expression<Func<Appointment, bool>> expression);


    }
}
