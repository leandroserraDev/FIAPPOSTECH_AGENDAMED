using AGENDAMED.Domain.Entities.user.doctor;
using AGENDAMED.Domain.Interface.Repositories;
using AGENDAMED.Domain.Interface.Repositories.speciality;
using AGENDAMED.Domain.Interface.Services.notification;
using AGENDAMED.Domain.Interface.Services.speciality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Services.Services.speciality
{
    public class DoctorSpecialityService : ServiceBase<DoctorSpecialities>, IDoctorSpecialityService
    {
        private readonly IDoctorSpecialityRepository _doctorSpecialityRepository;
        private readonly INotificationErrorService _notificationErrorService;

        public DoctorSpecialityService(IDoctorSpecialityRepository doctorSpecialityRepository, INotificationErrorService notificationErrorService)
            : base(doctorSpecialityRepository)
        {
            _doctorSpecialityRepository = doctorSpecialityRepository;
            _notificationErrorService = notificationErrorService;
        }

        public override async Task<DoctorSpecialities> Create(DoctorSpecialities entity)
        {

            var result = await _doctorSpecialityRepository.GetDoctorSpeciality(obj => obj.DoctorID.Equals(entity.DoctorID) 
                                                           && 
                                                           obj.SpecialtyID.Equals(entity.SpecialtyID));

            if(result != null)
            {

                await _notificationErrorService.AddNotification("Doutor já cadastrado na especialidade.");
                return null;
            }


            return await base.Create(entity);
        }

        public async Task<bool> DeleteSpeciality(string doctorID, long specialityID)
        {
            var result = await _doctorSpecialityRepository.DeleteSpeciality(doctorID, specialityID);

            return result;
        }

        public async Task<DoctorSpecialities> GetDoctorSpeciality(string doctorID)
        {
            return await _doctorSpecialityRepository.GetDoctorSpeciality(obj => obj.DoctorID.Equals(doctorID)); 
        }
    }
}
