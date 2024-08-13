using AGENDAMED.Application.DTOs.user.auth;
using AGENDAMED.Application.Interface.AppServices.user.auth;
using AGENDAMED.Domain.Entities.user;
using AGENDAMED.Domain.Interface.Services.user.auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Application.AppServices.user.auth
{
    public class AuthenticationAppService : IAuthenticationAppService
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationAppService(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<UserAuthViewModel> Login(string email, string password)
        {
            var result = await _authenticationService.Login(email, password);

            if(result == null)
            {
                return null;
            }

            return await Task.FromResult(new UserAuthViewModel(result));
        }

        public Task<UserAuthViewModel> Logout()
        {
            throw new NotImplementedException();
        }
    }
}
