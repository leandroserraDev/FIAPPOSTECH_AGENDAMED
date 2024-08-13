using AGENDAMED.Application.DTOs.user.doctor.speciality;
using AGENDAMED.Application.Interface.AppServices.speciality;
using AGENDAMED.Domain.Enums;
using AGENDAMED.Domain.Interface.Services.speciality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Application.AppServices.user.doctor.specialy
{
    public class DoctorSpecialityAppService : IDoctorSpecialityAppService
    {
        private readonly IDoctorSpecialityService _doctorSpecialityService;

        public DoctorSpecialityAppService(IDoctorSpecialityService doctorSpecialityService)
        {
            _doctorSpecialityService = doctorSpecialityService;
        }

        public async Task<DoctorSpecialityCreateViewModel> Create(DoctorSpecialityCreateViewModel doctorSpecialityCreateViewModel)
        {
            var result = await _doctorSpecialityService.Create(doctorSpecialityCreateViewModel.ToDomain());

            if(result == null)
            {
                return null;
            }

            return await Task.FromResult(new DoctorSpecialityCreateViewModel() { DoctorID = result.DoctorID, Speciality = (ESpecialty)result.SpecialtyID });
        }

        public async Task<bool> MudarStatus(string doctorID, long specialityID)
        {
            var result = await _doctorSpecialityService.MudarStatus(doctorID, specialityID);


            return result;
        }

        public async Task<IList<DoctorSpecialityViewModel>> GetDoctorSpecialities(string doctorID)
        {
            var result = await _doctorSpecialityService.GetDoctorSpecialities(doctorID);

            if (result == null)
            {
                return null;
            }
            var list = new List<DoctorSpecialityViewModel>();

            result.ToList().ForEach(obj =>
            {
                list.Add(new((ESpecialty)obj.SpecialtyID, obj.DoctorID, obj.Deleted));
            });

            return list;
        }

        public async Task<DoctorSpecialityViewModel> GetSpecialityDoctor(string doctorID)
        {
            var result = await _doctorSpecialityService.GetDoctorSpeciality(doctorID);

            if(result == null)
            {
                return null;
            }

            return await Task.FromResult(new DoctorSpecialityViewModel((ESpecialty)result.SpecialtyID, result.DoctorID, result.Deleted));

        }
    }
}
