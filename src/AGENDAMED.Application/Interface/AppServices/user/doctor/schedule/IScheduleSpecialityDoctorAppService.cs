using AGENDAMED.Domain.Entities.user.doctor.schedule;
using AGENDAMED.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Application.Interface.AppServices.user.doctor.schedule
{
    public interface IScheduleSpecialityDoctorAppService
    {
        Task<ScheduleSpecialityDoctor> Create(ScheduleSpecialityDoctor specialityDoctor);
        Task<ScheduleSpecialityDoctor> Edit(ScheduleSpecialityDoctor specialityDoctor);

        Task<IList<ScheduleSpecialityDoctor>> GetSchedulesDoctor(string doctorID);
        Task<ScheduleSpecialityDoctor> GetScheduleSpecialitieDoctor(string doctorID, ESpecialty speciality, DateTime dataAppointment);
    }
}
