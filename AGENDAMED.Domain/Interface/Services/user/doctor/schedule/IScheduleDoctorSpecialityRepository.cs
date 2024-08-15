using AGENDAMED.Domain.Entities.user.doctor.schedule;
using AGENDAMED.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Domain.Interface.Services.user.doctor.schedule
{
    public interface IScheduleSpecialityDoctorService : IServiceBase<ScheduleSpecialityDoctor>
    {
        Task<IList<ScheduleSpecialityDoctor>> GetSchedulesDoctor(string doctorID);
        Task<ScheduleSpecialityDoctor> GetScheduleSpecialitieDoctor(string doctorID, ESpecialty speciality, DateTime dataAppointment);
        Task<ScheduleSpecialityDoctor> GetScheduleSpecialitieDoctor(string doctorID, ESpecialty speciality);


    }
}
