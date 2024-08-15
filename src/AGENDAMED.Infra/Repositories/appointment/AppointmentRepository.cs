using AGENDAMED.Domain.Entities.appointment;
using AGENDAMED.Domain.Interface.Repositories.appointment;
using AGENDAMED.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Infra.Repositories.appointment
{
    public class AppointmentRepository: RepositoryBase<Appointment>, IAppointmentRepository
    {
        private readonly ApplicationContext _applicationContext;

        public AppointmentRepository(ApplicationContext applicationContext)
            :base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<List<Appointment>> GetAppointmentsOneHour()
        {
            var result = await _applicationContext.Appointments
                .Where(obj => 
                (obj.Date.DayOfYear - DateTime.Now.DayOfYear) ==1

                &&
                !obj.Deleted
                )
                .Select(obj=>
                    new Appointment(obj.PatientID, obj.DoctorID, obj.SpecialityID, obj.Date)
                    {
                        Patient = obj.Patient
                    }
                )
                .ToListAsync();

            return result;

        }

        public async Task<List<Appointment>> GetDoctorAppointments(Expression<Func<Appointment, bool>> expression)
        {
            var result = await _applicationContext.Appointments.Where(expression).ToListAsync();

            return await Task.FromResult(result);
        }

        public async Task<List<Appointment>> GetPatientAppointments(Expression<Func<Appointment, bool>> expression)
        {
            var result = await _applicationContext.Appointments.Where(expression)
                .Select(obj => new Appointment(obj.PatientID, obj.DoctorID, obj.SpecialityID, obj.Date,obj.Deleted)
                {
                    ID = obj.ID,
                    Doctor = new Domain.Entities.user.User() {Id =obj.Doctor.Id,Name = obj.Doctor.Name, LastName = obj.Doctor.LastName, Email = obj.Doctor.Email }
                    ,
                    Patient = new Domain.Entities.user.User() { Id = obj.Patient.Id, Name = obj.Patient.Name, LastName = obj.Patient.LastName, Email = obj.Patient.Email }
                    ,
                    Speciality = new Domain.Entities.speciality.Speciality() { Name = obj.Speciality.Name, Description = obj.Speciality.Description}
                })
                .ToListAsync();

            return await Task.FromResult(result);
        }

        public async Task<Appointment> GetPatientApppointment(Expression<Func<Appointment, bool>> expression)
        {
            var result = await _applicationContext.Appointments.Where(expression)
                 .Select(obj => new Appointment(obj.PatientID, obj.DoctorID, obj.SpecialityID, obj.Date)
                 {
                     ID = obj.ID,
                     Doctor = new Domain.Entities.user.User() { Id = obj.Doctor.Id, Name = obj.Doctor.Name, LastName = obj.Doctor.LastName, Email = obj.Doctor.Email }
                     ,
                     Patient = new Domain.Entities.user.User() { Id = obj.Patient.Id, Name = obj.Patient.Name, LastName = obj.Patient.LastName, Email = obj.Patient.Email }
                     ,
                     Speciality = new Domain.Entities.speciality.Speciality() { Name = obj.Speciality.Name, Description = obj.Speciality.Description }
                 })
                 .FirstOrDefaultAsync();

            return await Task.FromResult(result);
        }

        public async  Task<Appointment> GetPatientApppointmentInclude(Expression<Func<Appointment, bool>> expression)
        {
            var result = await _applicationContext.Appointments.Where(expression)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return await Task.FromResult(result);
        }
    }
}
