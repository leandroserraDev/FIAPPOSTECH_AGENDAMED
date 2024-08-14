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
    public class UserCreateDoctorViewModel 
    {
        public UserCreateDoctorViewModel(string nome, string sobrenome, string email, string cRM)
        {
            Nome = nome;
            SobreNome = sobrenome;
            Email = email;
            CRM = cRM; 
        }

        public string Nome { get; set; }
        public string SobreNome{ get; set; }
        public string Email{ get; set; }
        public string CRM { get; set; }


        public User ToDomain()
        {
            var newUser = new User();
            newUser.Name = Nome;
            newUser.LastName = SobreNome;
            newUser.Email = Email;
            newUser.UserName = Email;

            var doctor = new Doctor(CRM);

            newUser.Doctor = doctor;
                
            return newUser;
        }
    }
}
