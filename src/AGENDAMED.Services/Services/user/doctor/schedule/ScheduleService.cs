using AGENDAMED.Domain.Entities.user.doctor.schedule;
using AGENDAMED.Domain.Enums;
using AGENDAMED.Domain.Interface.Repositories.appointment;
using AGENDAMED.Domain.Interface.Repositories.user.doctor.schedule;
using AGENDAMED.Domain.Interface.Services.notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Domain.Interface.Services.user.doctor.schedule
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly INotificationErrorService _notificationErrorService;

        public ScheduleService(IScheduleRepository scheduleRepository, IAppointmentRepository appointmentRepository, INotificationErrorService notificationErrorService)
        {
            _scheduleRepository = scheduleRepository;
            _appointmentRepository = appointmentRepository;
            _notificationErrorService = notificationErrorService;
        }



        public Task<IList<Schedule>> GetSchedulesDoctor(string doctorID)
        {
            throw new NotImplementedException();
        }
        public async Task<Schedule> GetScheduleDoctor(string doctorID, ESpecialty speciality, DateTime dateAppointment)
        {
            var scheduleDoctor = await _scheduleRepository.GetScheduleDoctor(doctorID, speciality, dateAppointment);

            if(scheduleDoctor == null)
            {
                await _notificationErrorService.AddNotification("Não há horários");
                return null;
            }

            var appointmentsDoctorToDate = await _appointmentRepository.GetDoctorAppointments(obj => obj.DoctorID
                                                                                           .Equals(doctorID)
                                                                                           &&
                                                                                           !obj.Deleted
                                                                                           &&
                                                                                           obj.Date.DayOfYear.Equals(dateAppointment.DayOfYear));
            if (appointmentsDoctorToDate != null && dateAppointment.DayOfYear <= DateTime.Now.DayOfYear)
            {
                var getDateTimeSpan = TimeSpan.Parse(dateAppointment.ToString("hh:mm"));

                appointmentsDoctorToDate.ForEach(appointment => {
                var scheduleHourRemove = scheduleDoctor.ScheduleTime
                    .FirstOrDefault(obj => obj.Time < DateTime.Now.TimeOfDay || obj.Time.ToString().Equals(
                    string.Concat(appointment.Date.Hour.ToString(), ":" ,appointment.Date.Minute.ToString("00"), ":00") 
                    ));

                    if (scheduleHourRemove != null) { scheduleDoctor.ScheduleTime.Remove(scheduleHourRemove); };

            });
            }

            return scheduleDoctor;

        }
        public async Task<IList<Schedule>> GetSchedulesDoctor(string doctorID, ESpecialty speciality, DateTime dateAppointment)
        {
           var scheduleDoctor =  await _scheduleRepository.GetSchedulesDoctor(doctorID, speciality, dateAppointment);
            var appointmentsDoctorToDate = await _appointmentRepository.GetDoctorAppointments(obj => obj.DoctorID
                                                                                             .Equals(doctorID) 
                                                                                             && 
                                                                                             obj.Date.Equals(dateAppointment)) ;


            if (appointmentsDoctorToDate != null)
            {
                var getDateTimeSpan = TimeSpan.Parse(dateAppointment.ToString("hh:mm"));
                scheduleDoctor.ToList().RemoveAll(obj => obj.ScheduleTime.Select(obj => obj.Time).Contains(getDateTimeSpan));
            }

            return scheduleDoctor;
        }
    }
}
