using AGENDAMED.Domain.Entities.user.doctor.schedule;
using AGENDAMED.Domain.Enums;
using AGENDAMED.Domain.Interface.Repositories;
using AGENDAMED.Domain.Interface.Repositories.appointment;
using AGENDAMED.Domain.Interface.Repositories.user.doctor.schedule;
using AGENDAMED.Domain.Interface.Services.notification;
using AGENDAMED.Domain.Interface.Services.user.doctor.schedule;
using AGENDAMED.Domain.ValueObject;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Xml.Schema;

namespace AGENDAMED.Services.Services.user.doctor.schedule
{
    public class ScheduleSpecialityDoctorService : ServiceBase<ScheduleSpecialityDoctor>, IScheduleSpecialityDoctorService
    {
        private readonly IScheduleSpecialityDoctorRepository _scheduleDoctorSpecialityRepository;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly INotificationErrorService _notificationErrorService;

        public ScheduleSpecialityDoctorService(IScheduleSpecialityDoctorRepository scheduleDoctorSpecialityRepository,
                                               IAppointmentRepository appointmentRepository,
                                               INotificationErrorService notificationErrorService,
                                               IScheduleRepository scheduleRepository)
            : base(scheduleDoctorSpecialityRepository)
        {
            _scheduleDoctorSpecialityRepository = scheduleDoctorSpecialityRepository;
            _appointmentRepository = appointmentRepository;
            _notificationErrorService = notificationErrorService;
            _scheduleRepository = scheduleRepository;
        }

        public async Task<IList<ScheduleSpecialityDoctor>> GetSchedulesDoctor(string doctorID)
        {
            var result = await _scheduleDoctorSpecialityRepository.GetSchedulesDoctor(doctorID);
                            

            return result;
        }

        public override async Task<ScheduleSpecialityDoctor> Create(ScheduleSpecialityDoctor entity)
        {
            var result = await _scheduleDoctorSpecialityRepository
                              .GetScheduleSpecialitieDoctor(obj => obj.DoctorID.Equals(entity.DoctorID)
                                                                   &&
                                                                   obj.SpecialityID.Equals(entity.SpecialityID));

            if (result != null)
            {
               var resultEdit = await Update(entity);
                if(resultEdit == null) 
                {
                    await _notificationErrorService.AddNotification("Aconteceu um erro inesperado");
                    return null; 
                
                };
                return await Task.FromResult(resultEdit);
            }
            var resultCreate = await _scheduleDoctorSpecialityRepository.Create(entity);
            return resultCreate;
        }

        public override async Task<ScheduleSpecialityDoctor> Update(ScheduleSpecialityDoctor entity)
        {
            var result = await _scheduleDoctorSpecialityRepository.GetScheduleSpecialitieDoctor(obj => obj.DoctorID.Equals(entity.DoctorID)
                                                                                                       &&
                                                                                                       obj.SpecialityID.Equals(entity.SpecialityID));
            if (result != null) 
            {
                var schedules = await _scheduleRepository.RemoveRange(result.Schedule);

            }
            result.Schedule = entity.Schedule;

            return await base.Update(entity);
        }

        public async Task<ScheduleSpecialityDoctor> GetScheduleSpecialitieDoctor(string doctorID, ESpecialty speciality, DateTime dataAppointment)
        {
            var predicadeBuilder = PredicateBuilder.New<ScheduleSpecialityDoctor>();

            predicadeBuilder = predicadeBuilder.And(obj => obj.DoctorID.Equals(doctorID) && !obj.Deleted)
                                               .And(obj => obj.SpecialityID.Equals((long)speciality))
                                               .And(obj => obj.Schedule.Select(sc => sc.DayOfWeek).Contains((long)dataAppointment.DayOfWeek));

            var result = await _scheduleDoctorSpecialityRepository.GetScheduleSpecialitieDoctor(predicadeBuilder);



            var appointmentsDoctor = await _appointmentRepository.GetDoctorAppointments(obj => obj.DoctorID.Equals(doctorID)
                                                                                            && obj.SpecialityID.Equals(speciality));



            result.Schedule.Select(obj => obj.ScheduleTime)
                .ToList()
                .RemoveAll(st => st.Select(stm => stm.Time.ToString()).Contains(dataAppointment.ToString("hh:mm")));



            return result;


        }

        public async Task<ScheduleSpecialityDoctor> GetScheduleSpecialitieDoctor(string doctorID, ESpecialty speciality)
        {
            var predicadeBuilder = PredicateBuilder.New<ScheduleSpecialityDoctor>();

            predicadeBuilder = predicadeBuilder.And(obj => obj.DoctorID.Equals(doctorID))
                                               .And(obj => obj.SpecialityID.Equals((long)speciality));

            var result = await _scheduleDoctorSpecialityRepository.GetScheduleSpecialitieDoctor(predicadeBuilder);


            return result;
        }
    }
}
