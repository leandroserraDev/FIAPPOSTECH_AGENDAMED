using AGENDAMED.Domain.Entities.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Domain.Interface.Services.loggedUser
{
    public interface ILoggedUserService
    {
        Task<User> LoggedUser();
    }
}
