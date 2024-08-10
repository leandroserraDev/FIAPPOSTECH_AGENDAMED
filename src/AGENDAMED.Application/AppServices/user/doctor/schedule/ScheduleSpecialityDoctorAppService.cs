using AGENDAMED.Application.Interface.AppServices.user.doctor.schedule;
using AGENDAMED.Domain.Entities.user.doctor.schedule;
using AGENDAMED.Domain.Enums;
using AGENDAMED.Domain.Interface.Services.user.doctor.schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Application.AppServices.user.doctor.schedule
{
    public class ScheduleSpecialityDoctorAppService : IScheduleSpecialityDoctorAppService
    {
        private readonly IScheduleSpecialityDoctorService _scheduleSpecialityDoctorService;

        public ScheduleSpecialityDoctorAppService(IScheduleSpecialityDoctorService scheduleSpecialityDoctorService)
        {
            _scheduleSpecialityDoctorService = scheduleSpecialityDoctorService;
        }

        public async Task<ScheduleSpecialityDoctor> Create(ScheduleSpecialityDoctor specialityDoctor)
        {
            return await _scheduleSpecialityDoctorService.Create(specialityDoctor);
        }

        public async Task<ScheduleSpecialityDoctor> Edit(ScheduleSpecialityDoctor specialityDoctor)
        {
            return await _scheduleSpecialityDoctorService.Update(specialityDoctor);

        }

        public async Task<IList<ScheduleSpecialityDoctor>> GetSchedulesDoctor(string doctorID)
        {
            return await _scheduleSpecialityDoctorService.GetSchedulesDoctor(doctorID);
        }

        public async  Task<ScheduleSpecialityDoctor> GetScheduleSpecialitieDoctor(string doctorID, ESpecialty speciality, DateTime dataAppointment)
        {
           return await _scheduleSpecialityDoctorService.GetScheduleSpecialitieDoctor(doctorID, speciality, dataAppointment);
        }
    }
}
