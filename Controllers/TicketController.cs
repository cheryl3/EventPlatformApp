using EventPlatformApp.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EventPlatformApp.Controllers
{
    [ApiController]
    [Route("api/Event/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        //Dependency Injection
        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet("getTicket")]
        public async Task<IActionResult> GetTicket([FromQuery] string eventId)
        {
            _ticketService.InitializeDB();
            var ticketDetails = await _ticketService.GetTicketData(eventId);
            return Ok(ticketDetails);
        }

        [HttpGet("getTop5Amount")]
        public async Task<IActionResult> GetTop5Amount()
        {
            _ticketService.InitializeDB();
            var highestAmount = await _ticketService.GetTop5Events_DollarAmount();
            return Ok(highestAmount);
        }

        [HttpGet("getTop5Sales")]
        public async Task<IActionResult> GetTop5Sales()
        {
            _ticketService.InitializeDB();
            var highestSales = await _ticketService.GetTop5Events_SalesCount();
            return Ok(highestSales);
        }
    }
}
