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
        Task<User> GetUserDoctor(string id);
        Task<User> GetUserDoctorEmail(string email);




    }
}
