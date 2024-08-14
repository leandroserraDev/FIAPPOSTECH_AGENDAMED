using AGENDAMED.Domain.Entities.user.doctor.schedule;
using AGENDAMED.Domain.Enums;
using AGENDAMED.Domain.Interface.Repositories.user.doctor.schedule;
using AGENDAMED.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Infra.Repositories.user.schedule
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly ApplicationContext _applicationContext;

        public ScheduleRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public Task<IList<Schedule>> GetScheduleByExpression(Expression<Func<Schedule, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Schedule>> GetSchedulesDoctor(string doctorID)
        {
            var result = await _applicationContext.Schedules.Where(obj => obj.DoctorID.Equals(doctorID))
                .Select(obj => new Schedule()
                {
                    DayOfWeek = obj.DayOfWeek,
                    DoctorID = obj.DoctorID,
                    Speciality = obj.Speciality,
                    ScheduleTime = obj.ScheduleTime.Select(st => new ScheduleTime(st.DoctorID, st.Speciality, st.DayOfWeek, st.Time)).ToList()
                })
                .ToListAsync();
            return result;
        }

        public async Task<IList<Schedule>> GetSchedulesDoctor(string doctorID, ESpecialty speciality, DateTime dateAppointment)
        {
            var result = await _applicationContext.Schedules.Where(obj => obj.DoctorID.Equals(doctorID))
                .Select(obj => new Schedule()
                {
                    DayOfWeek = obj.DayOfWeek,
                    DoctorID = obj.DoctorID,
                    Speciality = obj.Speciality,
                    ScheduleTime = obj.ScheduleTime.Select(st => new ScheduleTime(st.DoctorID, st.Speciality, st.DayOfWeek, st.Time)).ToList()
                })
                .ToListAsync();

           
            return result;
        }

        public async Task<bool> RemoveRange(List<Schedule> schedules)
        {
            _applicationContext.Schedules.RemoveRange(schedules);
            await _applicationContext.SaveChangesAsync();
            return true;
        }
    }
}
