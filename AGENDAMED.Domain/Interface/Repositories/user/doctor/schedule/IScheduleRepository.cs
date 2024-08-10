using AGENDAMED.Domain.Entities.user.doctor.schedule;
using AGENDAMED.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Domain.Interface.Repositories.user.doctor.schedule
{
    public interface IScheduleRepository
    {
        Task<IList<Schedule>> GetSchedulesDoctor(string doctorID);
        Task<IList<Schedule>> GetScheduleByExpression(Expression<Func<Schedule, bool>> expression);
        Task<bool> RemoveRange(List<Schedule> schedules);
        Task<IList<Schedule>> GetSchedulesDoctor(string doctorID, ESpecialty speciality, DateTime dateAppointment);

    }
}
