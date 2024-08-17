using AGENDAMED.Domain.Entities.speciality;
using AGENDAMED.Domain.Entities.user;
using AGENDAMED.Domain.Entities.user.doctor;
using AGENDAMED.Domain.Interface.Repositories.user;
using AGENDAMED.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Infra.Repositories.user
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly ApplicationContext _applicationContext;

        public UserRepository(ApplicationContext applicationContext)
            : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<List<User>> GetActiveBySpecialityID(long specialityID)
        {
            var result = await _applicationContext.Users
                .Where(obj => obj.Doctor != null && !obj.Doctor.Deleted)
                .Select(obj => new User
                {
                    Id = obj.Id,
                    Name = obj.Name,
                    LastName = obj.LastName,
                    Email = obj.Email,
                    Doctor = new Doctor()
                    {
                        CRM = obj.Doctor.CRM,
                        Specialities = obj.Doctor.Specialities.Select(sp => new DoctorSpecialities() { Speciality = sp.Speciality }).ToList()
                    }
                }).ToListAsync();

            return result;
        }

        public override async Task<IList<User>> GetAll()
        {
            var result = await _applicationContext.Users
                .Select(obj => new User
                {
                    Id = obj.Id,
                    UserName = obj.UserName,
                    Email = obj.Email,
                    Doctor = new Doctor()
                    {
                        CRM = obj.Doctor.CRM,
                        Specialities = obj.Doctor.Specialities.Select(sp => new DoctorSpecialities() { Speciality = sp.Speciality }).ToList()
                    }
                }).ToListAsync();

            return result;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var result = await _applicationContext.Users
              .Where(obj => obj.Email.Equals(email))
              .Select(obj => new User
              {
                  Id = obj.Id,
                  Name = obj.Name,
                  LastName = obj.LastName,
                  UserName = obj.UserName,
                  Email = obj.Email,
                  Doctor = new Doctor()
                  {
                      CRM = obj.Doctor.CRM,
                      Specialities = obj.Doctor.Specialities.Select(sp => new DoctorSpecialities()
                      {
                          Speciality = new Speciality()
                          {
                              Name = sp.Speciality.Name,
                              Description = sp.Speciality.Description

                          }
                      }).ToList()
                  }
              }).FirstOrDefaultAsync();

            return await Task.FromResult(result);
        }

        public async Task<User> GetUserById(string id)
        {
            var result = await _applicationContext.Users.Where(obj => obj.Id.Equals(id))
                .AsNoTracking()
                .Include(obj => obj.Doctor)
                .ThenInclude(obj => obj.Specialities)
                .Include(obj =>  obj.Patient)
                .FirstOrDefaultAsync();

            return await Task.FromResult(result);
        }

        public async Task<User> GetUserDoctorById(string doctorID)
        {
            var result = await _applicationContext.Users.Include(obj => obj.Doctor)
                .ThenInclude(obj => obj.Specialities).ThenInclude(obj => obj.Speciality)
                .FirstOrDefaultAsync(obj => obj.Id.Equals(doctorID));

            return result;
        }

        public async Task<User> GetUserDoctorEmail(string email)
        {
            var result = await _applicationContext.Users
             .Where(obj => obj.Doctor != null && obj.Email.Equals(email))
             .Select(obj => new User
             {
                 Id = obj.Id,
                 Name = obj.Name,
                 LastName= obj.LastName,
                 UserName = obj.UserName,
                 Email = obj.Email,
                 Doctor = new Doctor()
                 {
                     CRM = obj.Doctor.CRM,
                     Specialities = obj.Doctor.Specialities.Select(sp => new DoctorSpecialities()
                     {
                         Speciality = new Speciality()
                         {
                             Name = sp.Speciality.Name,
                             Description = sp.Speciality.Description

                         }
                     }).ToList()
                 }
             }).FirstOrDefaultAsync();

            return await Task.FromResult(result);
        }

        public async Task<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetUsersDoctor()
        {
            var result = await _applicationContext.Users
           .Where(obj => obj.Doctor != null)
           .Select(obj => new User
           {
               Id = obj.Id,
               Name = obj.Name,
               LastName = obj.LastName,
               Email = obj.Email,
               Doctor = new Doctor()
               {
                   CRM = obj.Doctor.CRM,
                   Specialities = obj.Doctor.Specialities.Select(sp => new DoctorSpecialities()
                   {
                       Speciality = new Speciality()
                       {
                           Name = sp.Speciality.Name,
                           Description = sp.Speciality.Description

                       }
                   }).ToList()
               }
           }).ToListAsync();

            return result;
        }

        public async Task<List<User>> GetUsersPatients()
        {
            return null;

        }
    }
}
