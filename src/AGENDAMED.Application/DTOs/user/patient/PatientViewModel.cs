using AGENDAMED.Domain.Entities.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Application.DTOs.user.patient
{
    public class PatientViewModel
    {
        public PatientViewModel(User user)
        {
            ID = user.Id;
            Nome = user.Name;
            Sobrenome = user.LastName;
            Email = user.Email;
            Celular = user.PhoneNumber;
        }
        public string ID { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }



    }
}
