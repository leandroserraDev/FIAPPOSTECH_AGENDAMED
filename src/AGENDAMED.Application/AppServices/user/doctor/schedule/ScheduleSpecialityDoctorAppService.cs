using AGENDAMED.Application.DTOs.user.doctor.schedule;
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

        public async Task<ScheduleSpecialityViewModel> Create(ScheduleSpecialityDoctor specialityDoctor)
        {
           var result = await _scheduleSpecialityDoctorService.Create(specialityDoctor);
            if(result == null)
            {
                return null;
            }

            return new ScheduleSpecialityViewModel(result);
        }

        public async Task<ScheduleSpecialityViewModel> Edit(ScheduleSpecialityDoctor specialityDoctor)
        {
            var result = await _scheduleSpecialityDoctorService.Update(specialityDoctor);
            if (result == null)
            {
                return null;
            }

            return new ScheduleSpecialityViewModel(result);

        }

        public async Task<IList<ScheduleSpecialityViewModel>> GetSchedulesDoctor(string doctorID)
        {
            var result = await _scheduleSpecialityDoctorService.GetSchedulesDoctor(doctorID);

            if(result == null)
            {
                return null;
            }

            var list = new List<ScheduleSpecialityViewModel>();
            foreach (var item in result)
            {
                list.Add(new(item));
            }

            return list;
        }

        public async  Task<ScheduleSpecialityDoctor> GetScheduleSpecialitieDoctor(string doctorID, ESpecialty speciality, DateTime dataAppointment)
        {
           return await _scheduleSpecialityDoctorService.GetScheduleSpecialitieDoctor(doctorID, speciality, dataAppointment);
        }

        public  async Task<ScheduleSpecialityViewModel> GetScheduleSpecialitieDoctor(string doctorID, ESpecialty speciality)
        {
            var result = await _scheduleSpecialityDoctorService.GetScheduleSpecialitieDoctor(doctorID, speciality);


            if (result == null)
            {
                return null;
            }

            return new ScheduleSpecialityViewModel(result);
        }
    }
}
