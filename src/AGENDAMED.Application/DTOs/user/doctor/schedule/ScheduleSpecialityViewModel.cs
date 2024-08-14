using AGENDAMED.Domain.Entities.speciality;
using AGENDAMED.Domain.Entities.user.doctor.schedule;
using AGENDAMED.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Application.DTOs.user.doctor.schedule
{
    public class ScheduleSpecialityViewModel
    {
        public ScheduleSpecialityViewModel(ScheduleSpecialityDoctor scheduleSpecialityDoctor)
        {
            DoctorID = scheduleSpecialityDoctor.DoctorID;
            Speciality = scheduleSpecialityDoctor.SpecialityID;
            SpecialityName = ((ESpecialty)scheduleSpecialityDoctor.SpecialityID).ToString();

            Schedule = new List<ScheduleViewModel>();

            foreach(var schedule in scheduleSpecialityDoctor.Schedule)
            {
                Schedule.Add(new ScheduleViewModel(schedule));
            }
            
        }
        public string DoctorID { get; set; }
        public long Speciality{ get; set; }
        public string SpecialityName { get; set; }

        public List<ScheduleViewModel>Schedule{ get; set; }

    }
}
