using AGENDAMED.Domain.Entities.user.doctor.schedule;
using AGENDAMED.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Domain.Interface.Services.user.doctor.schedule
{
    public interface IScheduleService
    {
        Task<IList<Schedule>> GetSchedulesDoctor(string doctorID);
        Task<IList<Schedule>> GetSchedulesDoctor(string doctorID, ESpecialty speciality, DateTime dateAppointment);
        Task<Schedule> GetScheduleDoctor(string doctorID, ESpecialty speciality, DateTime dateAppointment);

    }
}
