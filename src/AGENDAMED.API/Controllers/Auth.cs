using AGENDAMED.API.JWT;
using AGENDAMED.Application.AppServices.user.auth;
using AGENDAMED.Application.Interface.AppServices.user.auth;
using AGENDAMED.Domain.Entities.user;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AGENDAMED.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Auth : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationAppService _authenticationAppService;

        public Auth(UserManager<User> userManager, IConfiguration configuration, IAuthenticationAppService authenticationAppService)
        {
            _userManager = userManager;
            _configuration = configuration;
            _authenticationAppService = authenticationAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Authentication(LoginViewModel loginViewModel)
        {
            var user = await _authenticationAppService.Login(loginViewModel.Email, loginViewModel.Password);

            if (user == null)
            {
                return BadRequest(new {Message = "E-mail ou senha inválidos"});
            }


            var token = await new GerarJWT(_userManager).GerarToken(user, _configuration);

            return Ok(new {data = token});
        
        }
    }
}
