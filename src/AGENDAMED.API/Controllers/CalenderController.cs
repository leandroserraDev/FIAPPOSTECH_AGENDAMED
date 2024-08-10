using AGENDAMED.Application.DTOs.Calender;
using AGENDAMED.Domain.Interface.Services.calendar;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace AGENDAMED.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalenderController : ControllerBase
    {
        private readonly ICalendarService _calendarService;

        public CalenderController(ICalendarService calendarService)
        {
            _calendarService = calendarService;
        }

    

        [HttpGet("doctor/id")]
        public async Task<IActionResult> GetCalendar(string doctorID, DateTime dateAppointment)
        {
            var result = await _calendarService.CalendarDoctor(doctorID, dateAppointment, null);


            return Ok(result);
        }
    }
}
