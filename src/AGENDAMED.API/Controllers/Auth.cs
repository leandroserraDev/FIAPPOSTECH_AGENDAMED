using AGENDAMED.API.JWT;
using AGENDAMED.Application.AppServices.user.auth;
using AGENDAMED.Application.Interface.AppServices.user.auth;
using AGENDAMED.Domain.Entities.user;
using AGENDAMED.Domain.Interface.Services.notification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AGENDAMED.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Auth : MainController
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationAppService _authenticationAppService;
        private readonly INotificationErrorService _notificationErrorService;

        public Auth(UserManager<User> userManager, IConfiguration configuration, IAuthenticationAppService authenticationAppService, INotificationErrorService notificationErrorService)
        :base(notificationErrorService)
        {
            _userManager = userManager;
            _configuration = configuration;
            _authenticationAppService = authenticationAppService;
            _notificationErrorService = notificationErrorService;
        }

        [HttpPost]
        public async Task<IActionResult> Authentication(LoginViewModel loginViewModel)
        {
            var user = await _authenticationAppService.Login(loginViewModel.Email, loginViewModel.Password);

            if (user == null)
            {
                await _notificationErrorService.AddNotification("E-mail ou senha inválidos");
                return await CustomResponse();
            }


            var token = await new GerarJWT(_userManager).GerarToken(user, _configuration);

            return await CustomResponse(token);
        
        }
    }
}
