using AGENDAMED.Domain.Entities.user;
using AGENDAMED.Domain.Interface.Services.loggedUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Services.Services.loggedUser
{
    public class LoggedUserService : ILoggedUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private UserManager<User> _userManager;
        public LoggedUserService(IHttpContextAccessor contextAccessor, UserManager<User> userManager)
        {
            _contextAccessor = contextAccessor;
            _userManager = userManager;
        }

        public async Task<User> LoggedUser()
        {
            var userId = _contextAccessor.HttpContext?.User?.Claims?.First().Value;
            var user = await _userManager.FindByIdAsync(userId);

            return await Task.FromResult(user);
        }
    }
}
