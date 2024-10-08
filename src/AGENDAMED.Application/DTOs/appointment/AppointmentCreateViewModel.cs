﻿using AGENDAMED.Domain.Entities.appointment;
using AGENDAMED.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Application.DTOs.appointment
{
    public class AppointmentCreateViewModel
    {
        public string PatientID { get; set; }
        public string DoctorID { get; set; }
        public DateTime DateAppointment { get; set; }
        public long SpecialityID { get; set; }
        public Appointment ToDomain()
        {
            var newAppointment = new Appointment(PatientID, DoctorID, SpecialityID, DateAppointment);

            return newAppointment;
        }
    }
}
