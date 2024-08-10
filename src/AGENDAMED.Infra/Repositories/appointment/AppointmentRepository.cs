using AGENDAMED.Domain.Entities.appointment;
using AGENDAMED.Domain.Interface.Repositories.appointment;
using AGENDAMED.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Infra.Repositories.appointment
{
    public class AppointmentRepository: RepositoryBase<Appointment>, IAppointmentRepository
    {
        private readonly ApplicationContext _applicationContext;

        public AppointmentRepository(ApplicationContext applicationContext)
            :base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<List<Appointment>> GetDoctorAppointments(Expression<Func<Appointment, bool>> expression)
        {
            var result = await _applicationContext.Appointments.Where(expression).ToListAsync();

            return await Task.FromResult(result);
        }

        public async Task<List<Appointment>> GetPatientAppointments(Expression<Func<Appointment, bool>> expression)
        {
            var result = await _applicationContext.Appointments.Where(expression).ToListAsync();

            return await Task.FromResult(result);
        }
    }
}
