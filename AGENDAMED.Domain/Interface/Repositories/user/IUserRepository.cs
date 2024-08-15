using AGENDAMED.Domain.Entities.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Domain.Interface.Repositories.user
{
    public interface IUserRepository: IRepositoryBase<User>
    {

        Task<User> GetUsers();
        Task<List<User>> GetUsersDoctor();
        Task<List<User>> GetUsersPatients();
        Task<User> GetUserById(string id);

        Task<User> GetUserDoctorById(string doctorID);
        Task<List<User>> GetActiveBySpecialityID(long specialityID);
        Task<User> GetUserDoctorEmail(string email);




    }
}
