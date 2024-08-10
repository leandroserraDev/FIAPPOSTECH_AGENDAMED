using AGENDAMED.Domain.Entities.appointment;
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
    public interface IScheduleSpecialityDoctorRepository : IRepositoryBase<ScheduleSpecialityDoctor>
    {
        Task<IList<ScheduleSpecialityDoctor>> GetSchedulesDoctor(string doctorID);
        Task<ScheduleSpecialityDoctor> GetScheduleSpecialitieDoctor(Expression<Func<ScheduleSpecialityDoctor, bool>> expression);
    }
}
