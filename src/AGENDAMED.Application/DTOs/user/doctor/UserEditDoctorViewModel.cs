using AGENDAMED.Domain.Entities.user;
using AGENDAMED.Domain.Entities.user.doctor;
using AGENDAMED.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Application.DTOs.user.doctor
{
    public class UserEditDoctorViewModel
    {

        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        public string CRM { get; set; }

        public User ToDomain()
        {
            var newUser = new User();
            newUser.Name = Nome;
            newUser.LastName = Sobrenome;

            var doctor = new Doctor(CRM);

            //foreach(var item in Specialties)
            //{
            //    doctor.Specialities.Add(new DoctorSpecialities() { SpecialtyID = (long)item });
            //}

            newUser.Doctor = doctor;
                
            return newUser;
        }
    }
}
