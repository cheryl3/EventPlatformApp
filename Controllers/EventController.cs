using EventPlatformApp.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventPlatformApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        //Dependency Injection
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet("getEvent")]
        public async Task<IActionResult> GetEvent([FromQuery] int days)
        {
            var eventList = await _eventService.GetUpcomingEvents(days);
            return Ok(eventList);
        }
    }
}
