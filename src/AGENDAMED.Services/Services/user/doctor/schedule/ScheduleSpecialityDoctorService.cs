using AGENDAMED.Domain.Entities.user.doctor.schedule;
using AGENDAMED.Domain.Enums;
using AGENDAMED.Domain.Interface.Repositories;
using AGENDAMED.Domain.Interface.Repositories.appointment;
using AGENDAMED.Domain.Interface.Repositories.user.doctor.schedule;
using AGENDAMED.Domain.Interface.Services.notification;
using AGENDAMED.Domain.Interface.Services.user.doctor.schedule;
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

        public Task<IList<ScheduleSpecialityDoctor>> GetSchedulesDoctor(string doctorID)
        {
            throw new NotImplementedException();
        }

        public override async Task<ScheduleSpecialityDoctor> Create(ScheduleSpecialityDoctor entity)
        {
            var result = await _scheduleDoctorSpecialityRepository
                              .GetScheduleSpecialitieDoctor(obj => obj.DoctorID.Equals(entity.DoctorID)
                                                                   &&
                                                                   obj.SpecialityID.Equals(entity.SpecialityID));

            if (result != null)
            {
                await _notificationErrorService.AddNotification($"Já existe uma agenda para a especialidade: {(ESpecialty)entity.SpecialityID}");
                return null;
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


            return await base.Update(entity);
        }

        public async Task<ScheduleSpecialityDoctor> GetScheduleSpecialitieDoctor(string doctorID, ESpecialty speciality, DateTime dataAppointment)
        {
            var predicadeBuilder = PredicateBuilder.New<ScheduleSpecialityDoctor>();

            predicadeBuilder = predicadeBuilder.And(obj => obj.DoctorID.Equals(doctorID) && !obj.Deleted)
                                               .And(obj => obj.SpecialityID.Equals((long)speciality))
                                               .And(obj => obj.Schedule.Select(sc => sc.DayOfWeek).Equals(dataAppointment.DayOfWeek));

            var result = await _scheduleDoctorSpecialityRepository.GetScheduleSpecialitieDoctor(predicadeBuilder);



            var appointmentsDoctor = await _appointmentRepository.GetDoctorAppointments(obj => obj.DoctorID.Equals(doctorID)
                                                                                            && obj.SpecialityID.Equals(speciality));



            result.Schedule.Select(obj => obj.ScheduleTime)
                .ToList()
                .RemoveAll(st => st.Select(stm => stm.Time.ToString("HH:MM")).Contains(dataAppointment.ToString("HH:MM")));



            return result;


        }
    }
}
