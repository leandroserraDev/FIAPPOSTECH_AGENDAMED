using AGENDAMED.Domain.Entities.user.doctor.schedule;
using AGENDAMED.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Application.DTOs.user.doctor.schedule
{
    public class ScheduleSpecialityDoctorCreateViewModel
    {
        public string DoctorID { get; set; }
        public long Speciality { get; set; }
        public List<ScheduleCreateViewModel> Schedule{ get; set; }

        public ScheduleSpecialityDoctor ToDomain()
        {
            var newSchedule = new ScheduleSpecialityDoctor(DoctorID, Speciality);

            Schedule.ForEach(obj =>
            {

                newSchedule.Schedule.Add(obj.ToDomain());
            });

            return newSchedule;
        }

    }
}
