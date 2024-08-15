using AGENDAMED.Domain.Entities.user;
using AGENDAMED.Domain.Entities.user.doctor;
using AGENDAMED.Domain.Entities.user.patient;
using AGENDAMED.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Application.DTOs.user.patient
{
    public class UserCreatePatientViewModel : UserCreateViewModel
    {
        public UserCreatePatientViewModel(string nome,string sobrenome, string email, string password) : base(nome, sobrenome, email, password, ERoles.Patient)
        {
        }


        public override User ToDomain()
        {
            var newUser = new User();
            newUser.Name = Nome;
            newUser.LastName = Nome;
            newUser.UserName = Email;

            newUser.Email = Email;
            var patient = new Patient();

            newUser.Patient = patient;
                
            return newUser;
        }
    }
}
