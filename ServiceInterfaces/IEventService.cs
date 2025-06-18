using EventPlatformApp.Models;

namespace EventPlatformApp.ServiceInterfaces
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetUpcomingEvents(int upcomingDays);

        Task<List<Event>> GetAllEvents();
    }
}
