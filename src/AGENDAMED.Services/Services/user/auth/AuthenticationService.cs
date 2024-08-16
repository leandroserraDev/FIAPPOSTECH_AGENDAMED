using AGENDAMED.Domain.Entities.user;
using AGENDAMED.Domain.Interface.Repositories.user;
using AGENDAMED.Domain.Interface.Services.notification;
using AGENDAMED.Domain.Interface.Services.user.auth;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Services.Services.user.auth
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserRepository _userRepository;
        private INotificationErrorService _notificationErrorService;

        public AuthenticationService(UserManager<User> userManager, INotificationErrorService notificationErrorService, IUserRepository userRepository)
        {
            _userManager = userManager;
            _notificationErrorService = notificationErrorService;
            _userRepository = userRepository;
        }

        public async Task<User> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if(user == null)
            {
                await _notificationErrorService.AddNotification("Usuário não encontrado");
                return null;
            }

            var resultPassword = await _userManager.CheckPasswordAsync(user, password);
            if (!resultPassword)
            {
                await _notificationErrorService.AddNotification("Usuário ou senha inválida");
                return null;
            }


            return user;
        }

        public Task<User> Logout()
        {
            throw new NotImplementedException();
        }
    }
}
