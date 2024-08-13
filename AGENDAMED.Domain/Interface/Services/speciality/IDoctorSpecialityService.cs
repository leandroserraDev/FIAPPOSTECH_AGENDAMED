using AGENDAMED.Domain.Entities.user.doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Domain.Interface.Services.speciality
{
    public interface IDoctorSpecialityService : IServiceBase<DoctorSpecialities>
    {
        Task<DoctorSpecialities> GetDoctorSpeciality(string doctorID);
        Task<IList<DoctorSpecialities>> GetDoctorSpecialities(string doctorID);
        Task<bool> MudarStatus(string doctorID, long specialityID);


    }
}
