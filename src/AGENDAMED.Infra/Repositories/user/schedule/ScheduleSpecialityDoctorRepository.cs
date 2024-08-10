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
    public class ScheduleSpecialityDoctorRepository : RepositoryBase<ScheduleSpecialityDoctor>, IScheduleSpecialityDoctorRepository
    {
        private readonly ApplicationContext _applicationContext;

        public ScheduleSpecialityDoctorRepository(ApplicationContext applicationContext)
            :base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public Task<IList<ScheduleSpecialityDoctor>> GetSchedulesDoctor(string doctorID)
        {
            throw new NotImplementedException();
        }

        public async Task<ScheduleSpecialityDoctor> GetScheduleSpecialitieDoctor(Expression<Func<ScheduleSpecialityDoctor, bool>> expression)
        {
            var schedule = await _applicationContext.ScheduleSpecialityDoctors
                .Where(expression)
                .Select(obj => new ScheduleSpecialityDoctor(obj.DoctorID, obj.SpecialityID)
                {
                    Schedule = obj.Schedule.Select(sc => new Schedule()
                    {
                        DoctorID = obj.DoctorID,
                        Speciality = obj.SpecialityID,
                        DayOfWeek = sc.DayOfWeek,
                        ScheduleTime = sc.ScheduleTime.Select(sh => new ScheduleTime()
                        {
                            Time = sh.Time
                        }).ToList()
                    }).ToList()
                }
                ).FirstOrDefaultAsync();

            return await Task.FromResult(schedule);
        }
    
    }
}
