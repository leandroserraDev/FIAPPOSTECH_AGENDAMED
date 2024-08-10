using AGENDAMED.Application.DTOs.speciality.doctor;
using AGENDAMED.Application.Interface.AppServices.speciality;
using AGENDAMED.Domain.Enums;
using AGENDAMED.Domain.Interface.Services.speciality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Application.AppServices.speciality
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

        public async Task<bool> Delete(string doctorID, long specialityID)
        {
            var result = await _doctorSpecialityService.DeleteSpeciality(doctorID, specialityID);


            return result;
        }

        public async Task<DoctorSpecialityCreateViewModel> GetSpecialityDoctor(string doctorID)
        {
            var result = await _doctorSpecialityService.GetDoctorSpeciality(doctorID);

            if(result == null)
            {
                return null;
            }

            return await Task.FromResult(new DoctorSpecialityCreateViewModel() { DoctorID = result.DoctorID, Speciality = (ESpecialty)result.SpecialtyID });

        }
    }
}
