using AGENDAMED.Domain.Entities.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Domain.Interface.Services.user.auth
{
    public interface IAuthenticationService 
    {
        Task<User> Login(string email, string password);
        Task<User> Logout();
    }
}
