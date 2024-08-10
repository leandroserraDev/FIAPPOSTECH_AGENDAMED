using AGENDAMED.Domain.Entities.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Domain.Interface.Services.user
{
    public interface IUserService: IServiceBase<User>
    {
        Task<User>CreatePatient(User user, string password);
        Task<User> UpdatePatient(User user);
        Task<User> DeletePatient(User user);
        Task<User> CreateDoctor(User user);
        Task<User> UpdateDoctor(string id,User user);
        Task<User> DeleteDoctor(User user);
        Task<List<User>> GetUsersDoctor();
        Task<User> GetDoctorById(string id);
        Task<User> GetPatientById(string id);

        Task<List<User>> GetUsersPatients();

    }
}
