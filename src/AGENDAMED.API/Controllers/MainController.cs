using AGENDAMED.Domain.Interface.Services.notification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AGENDAMED.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotificationErrorService _notificationErrorService;

        protected MainController(INotificationErrorService notificationErrorService)
        {
            _notificationErrorService = notificationErrorService;
        }

        protected async Task< IActionResult> CustomResponse(object result = null)
        {

            if (!await _notificationErrorService.HasNotifications())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                data = result,
                error = _notificationErrorService.Notifications()
            });
        }

    }
}
