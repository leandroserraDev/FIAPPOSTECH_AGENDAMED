using AGENDAMED.Application.DTOs.speciality.doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Application.Interface.AppServices.speciality
{
    public interface IDoctorSpecialityAppService
    {
        Task<bool> Delete(string doctorID, long specialityID);
        Task<DoctorSpecialityCreateViewModel> Create(DoctorSpecialityCreateViewModel objet);
        Task<DoctorSpecialityCreateViewModel> GetSpecialityDoctor(string doctorID);
    }
}
