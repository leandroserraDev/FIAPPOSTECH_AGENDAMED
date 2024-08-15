using AGENDAMED.Domain.Entities.appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Application.DTOs.appointment
{
    public class AppointmentViewModel
    {
        public AppointmentViewModel(Appointment appointment)
        {
            DoctorID = appointment.DoctorID;
            DoctorName = appointment.Doctor.Name + appointment.Doctor.LastName;
            PatientID = appointment.PatientID;
            PatientName = appointment.Doctor.Name + appointment.Patient.LastName;
            SpecialityID = appointment.SpecialityID;
            SpecialityName = appointment.Speciality.Name;
            SpecialityDescription = appointment.Speciality.Description;

        }
        public string DoctorID { get; set; }
        public string DoctorName { get; set; }
        public string PatientID { get; set; }
        public string PatientName { get; set; }
        public long SpecialityID { get; set; }
        public string SpecialityName { get; set; }
        public string SpecialityDescription { get; set; }

        public DateTime DateAppointment { get; set; }
    }
}
