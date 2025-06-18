using EventPlatformApp.Models;
using EventPlatformApp.ServiceInterfaces;
using NHibernate;
using NHibernate.Linq;

namespace EventPlatformApp.Services
{
    public class EventService : IEventService
    {
        private readonly ISessionFactory _sessionFactory;

        public EventService(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public async Task<IEnumerable<Event>> GetUpcomingEvents(int upcomingDays)
        {
            var session = _sessionFactory.OpenSession();
            var allEvents = new List<Event>();
            IEnumerable<Event> upcomingEvents = new List<Event>();
            try
            {
                allEvents = await session.Query<Event>()
                    .Select(e => new Event
                    {
                        Id = e.Id,
                        Name = e.Name,
                        StartsOn = e.StartsOn,
                        EndsOn = e.EndsOn
                    })
                    .ToListAsync();

                upcomingEvents = allEvents.Where(e => e.StartsOn >= DateTime.Today
                    && e.EndsOn <= DateTime.Today.AddDays(upcomingDays));

                /* ***************************************************************************
                 * Steps to debug & extract Events table info from skillsAssessmentEvents.db file
                 * 
                 
                var data = session.CreateSQLQuery("SELECT 1 FROM EVENTS LIMIT 1")
                    .UniqueResult();
                var dataTable = session.CreateSQLQuery("SELECT * FROM Events")
                    .List();

                var connString = "Data Source=skillsAssessmentEvents.db;Version=3;";
                using var connection = new SQLiteConnection(connString);
                connection.Open();

                using var cmd = new SQLiteCommand("PRAGMA table_info(Events);", connection);
                
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var name = reader["name"].ToString();
                        var type = reader["type"].ToString();
                        Console.WriteLine($"Column: {name}, Type: {type}");
                    }
                }

                ********************************************************************** */

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return upcomingEvents.ToList();
        }

        public async Task<List<Event>> GetAllEvents()
        {
            var session = _sessionFactory.OpenSession();
            var allEvents = new List<Event>();

            try
            {
                allEvents = await session.Query<Event>()
                    .Select(e => new Event
                    {
                        Id = e.Id,
                        Name = e.Name,
                        StartsOn = e.StartsOn,
                        EndsOn = e.EndsOn,
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            session.Close();
            return allEvents;
        }
    }
}
