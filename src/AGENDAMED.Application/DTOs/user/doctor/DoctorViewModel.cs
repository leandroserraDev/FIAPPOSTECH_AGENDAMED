using AGENDAMED.Domain.Entities.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Application.DTOs.user.doctor
{
    public class DoctorViewModel
    {
        public DoctorViewModel(User user)
        {
            Id = user.Id;
            Nome = user.Name;
            Sobrenome = user.LastName;
            Email = user.Email;

            Specialities = new List<Specialities>();
            foreach (var item in user.Doctor.Specialities)
            {
                Specialities.Add(new doctor.Specialities(item.Speciality));
            }

        }
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome{ get; set; }

        public string Email { get; set; }
        public List<Specialities> Specialities { get; set; }
    }
}
