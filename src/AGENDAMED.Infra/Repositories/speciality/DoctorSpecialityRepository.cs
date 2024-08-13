using AGENDAMED.Domain.Entities.user.doctor;
using AGENDAMED.Domain.Interface.Repositories;
using AGENDAMED.Domain.Interface.Repositories.speciality;
using AGENDAMED.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Infra.Repositories.speciality
{
    public class DoctorSpecialityRepository : RepositoryBase<DoctorSpecialities>, IDoctorSpecialityRepository
    {
        private readonly ApplicationContext _context;

        public DoctorSpecialityRepository(ApplicationContext context)
            :base(context)
        {
            _context = context;
        }

        public async  Task<bool> DeleteSpeciality(string doctorID, long specialityID)
        {
            var result = await _context.DoctorSpecialities.Where(obj => obj.DoctorID.Equals(doctorID) && obj.SpecialtyID.Equals(specialityID)).ToListAsync();

            if (result.Count > 0)
            {
                _context.RemoveRange(result);
                await _context.SaveChangesAsync();

                return true;

            }

            return false;
        }

        public async Task<bool> DeleteSpecialtyDoctor(string doctorID)
        {
            var result = await _context.DoctorSpecialities.Where(obj => obj.DoctorID.Equals(doctorID)).ToListAsync();

            if (result.Count > 0)
            {
                _context.RemoveRange(result);
                await _context.SaveChangesAsync();

                return true;

            }

            return false;


        }

        public async Task<IList<DoctorSpecialities>> GetDoctorSpecialities(Expression<Func<DoctorSpecialities, bool>> expression)
        {
            var result = await _context.DoctorSpecialities.Where(expression).OrderBy(obj => obj.DtCreated).ToListAsync();
            return result;
        }

        public async Task<DoctorSpecialities> GetDoctorSpeciality(Expression<Func<DoctorSpecialities, bool>> expression)
        {
            var result = await _context.DoctorSpecialities.FirstOrDefaultAsync(expression);
            return result;
        }
    }
}
