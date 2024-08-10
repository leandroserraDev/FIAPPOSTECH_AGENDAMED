using AGENDAMED.Domain.Entities.user.doctor;
using AGENDAMED.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Application.DTOs.speciality.doctor
{
    public class DoctorSpecialityCreateViewModel
    {
        public ESpecialty Speciality{ get; set; }
        public string DoctorID { get; set; }


        public DoctorSpecialities ToDomain()
        {
            var newDoctorSpeciality = new DoctorSpecialities() { DoctorID = DoctorID, SpecialtyID = (long)Speciality };

            return newDoctorSpeciality;
        }
    }
}
