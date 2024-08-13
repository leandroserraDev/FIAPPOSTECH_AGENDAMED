using AGENDAMED.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Application.DTOs.user.doctor.speciality
{
    public class DoctorSpecialityViewModel
    {
        public DoctorSpecialityViewModel(ESpecialty speciality, string doctorID, bool deleted)
        {
            Speciality = speciality;
            DoctorID = doctorID;
            Deleted = deleted;
            Description = speciality.ToString();
        }

        public ESpecialty Speciality { get; set; }
        public string Description { get; set; }
        public string DoctorID { get; set; }
        public bool Deleted { get; set; }
    }
}
