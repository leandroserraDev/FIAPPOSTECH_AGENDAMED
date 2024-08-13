using AGENDAMED.Application.DTOs.user.doctor.speciality;
using AGENDAMED.Domain.Entities.user.doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Application.Interface.AppServices.speciality
{
    public interface IDoctorSpecialityAppService
    {
        Task<bool> MudarStatus(string doctorID, long specialityID);
        Task<DoctorSpecialityCreateViewModel> Create(DoctorSpecialityCreateViewModel objet);
        Task<DoctorSpecialityViewModel> GetSpecialityDoctor(string doctorID);
        Task<IList<DoctorSpecialityViewModel>> GetDoctorSpecialities(string doctorID);

    }
}
