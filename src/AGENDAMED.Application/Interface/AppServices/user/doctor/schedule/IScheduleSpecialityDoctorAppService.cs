using AGENDAMED.Application.DTOs.user.doctor.schedule;
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
        Task<ScheduleSpecialityViewModel> Create(ScheduleSpecialityDoctor specialityDoctor);
        Task<ScheduleSpecialityViewModel> Edit(ScheduleSpecialityDoctor specialityDoctor);

        Task<IList<ScheduleSpecialityViewModel>> GetSchedulesDoctor(string doctorID);
        
        Task<ScheduleSpecialityDoctor> GetScheduleSpecialitieDoctor(string doctorID, ESpecialty speciality, DateTime dataAppointment);
        Task<ScheduleSpecialityViewModel> GetScheduleSpecialitieDoctor(string doctorID, ESpecialty speciality);

    }
}
