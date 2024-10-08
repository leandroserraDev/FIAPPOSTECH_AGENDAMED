﻿using AGENDAMED.Domain.Entities.speciality;
using AGENDAMED.Domain.Entities.user;
using AGENDAMED.Domain.Entities.user.doctor;
using AGENDAMED.Domain.Entities.user.patient;
using AGENDAMED.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Domain.Entities.appointment
{
    public class Appointment : EntityID
    {

        



        public Appointment(string patientID, string doctorID, long specialityID, DateTime date)
        {
            PatientID = patientID;
            DoctorID = doctorID;
            SpecialityID = specialityID;
            Date = date;
        }

        public Appointment(string patientID, string doctorID, long specialityID, DateTime date,bool deleted)
            :base(deleted)
        {
            PatientID = patientID;
            DoctorID = doctorID;
            SpecialityID = specialityID;
            Date = date;
        }



        public string PatientID { get; private set; }

        public virtual User Patient{ get;  set; }
        public string DoctorID { get; private set; }
        public virtual User Doctor{ get;  set; } 
        public long SpecialityID { get; private set; }
        public virtual Speciality Speciality{ get;  set; }
        public DateTime Date { get; private set; }

        protected Appointment() { }


        public void AddDate(DateTime date)
        {

            Date = date;
        }
    }
}
