using AGENDAMED.Domain.Interface.Services.notification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AGENDAMED.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationMailController : ControllerBase
    {
        private readonly INotificationErrorService _notificationErrorService;

        public NotificationMailController(INotificationErrorService notificationErrorService)
        {
            _notificationErrorService = notificationErrorService;
        }

        [HttpGet]
        public async Task<IActionResult> SendEmail()
        {

            return Ok(1);
        }
    }
}
