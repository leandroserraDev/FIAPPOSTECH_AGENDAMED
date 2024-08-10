
using AGENDAMED.Domain.Entities.user.doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Domain.Interface.Repositories.speciality
{
    public interface IDoctorSpecialityRepository : IRepositoryBase<DoctorSpecialities>
    {
        Task<DoctorSpecialities> GetDoctorSpeciality(Expression<Func<DoctorSpecialities, bool>> expression);
        Task<bool> DeleteSpeciality(string doctorID, long specialityID);
        Task<bool> DeleteSpecialtyDoctor(string doctorID);

    }
}
