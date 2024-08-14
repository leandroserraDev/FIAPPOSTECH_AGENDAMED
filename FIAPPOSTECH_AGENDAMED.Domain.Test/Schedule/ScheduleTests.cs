using AGENDAMED.Domain.Entities.user.doctor.schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPPOSTECH_AGENDAMED.Domain.Test.Schedule
{
    public class ScheduleTests
    {
        [Fact]

        public void ReturnNotEqualNull()
        {
            var schedule = new ScheduleSpecialityDoctor(null, AGENDAMED.Domain.Enums.ESpecialty.Geral);

            Assert.Equal(null,schedule.DoctorID);
            
        }
    }
}
