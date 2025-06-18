using EventPlatformApp.Models;

namespace EventPlatformApp.ServiceInterfaces
{
    public interface ITicketService
    {
        public void InitializeDB();

        public Task<List<Ticket>> GetTicketData(string eventId);

        public Task<List<Ticket>> GetTop5Events_DollarAmount();

        public Task<List<Ticket>> GetTop5Events_SalesCount();
    }
}
