using AGENDAMED.Application.DTOs.user.auth;
using AGENDAMED.Domain.Entities.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Application.Interface.AppServices.user.auth
{
    public interface IAuthenticationAppService
    {
        Task<UserAuthViewModel> Login(string email, string password);
        Task<UserAuthViewModel> Logout();
    }
}
