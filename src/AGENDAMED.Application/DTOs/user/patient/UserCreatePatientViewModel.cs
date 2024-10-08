﻿using AGENDAMED.Domain.Entities.user;
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
    public class UserEditPatientViewModel
    {


        public  User ToDomain()
        {
            var newUser = new User();
            newUser.Name = Nome;
            newUser.LastName = Nome;
            newUser.Email = Email;
            var patient = new Patient();

            newUser.Patient = patient;
                
            return newUser;
        }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }


    }
}
