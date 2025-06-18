using EventPlatformApp.Data;
using EventPlatformApp.Models;
using EventPlatformApp.ServiceInterfaces;
using NHibernate;
using NHibernate.Linq;

namespace EventPlatformApp.Services
{
    public class TicketService : ITicketService
    {
        private readonly ISessionFactory _sessionFactory;
        private readonly DatabaseHelper _databaseHelper;
        private readonly IEventService _eventService;
        private readonly string _dbFilePath;


        public TicketService(ISessionFactory sessionFactory, IEventService eventService, IWebHostEnvironment env)
        {
            _sessionFactory = sessionFactory;
            _databaseHelper = new DatabaseHelper();
            _eventService = eventService;
            var dbFileName = "skillsAssessmentEvents.db";
            _dbFilePath = Path.Combine(env.ContentRootPath, "Data", dbFileName);
        }

        public async void InitializeDB()
        {
            List<Event> eventData = new List<Event>();
            eventData = await _eventService.GetAllEvents();

            _databaseHelper.CreateTicketTable(eventData, _dbFilePath);
            //_databaseHelper.PopulateAmountAndSalesData(eventData, _dbFilePath);
        }

        public async Task<List<Ticket>> GetTicketData(string eventId)
        {
            var session = _sessionFactory.OpenSession();
            var ticketData = new List<Ticket>();
            var eventTickets = new List<Ticket>();
            try
            {
                ticketData = await session.Query<Ticket>()
                    .Select(e => new Ticket
                    {
                        EventId = e.EventId,
                        EventName = e.EventName,
                        TicketId = e.TicketId,
                        TicketType = e.TicketType,
                        Price = e.Price,
                        Sold = e.Sold,
                    })
                    .ToListAsync();

                eventTickets = ticketData.Where(t => t.EventId == eventId).ToList();

                session.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return eventTickets;
        }

        public async Task<List<Ticket>> GetTop5Events_DollarAmount()
        {
            var session = _sessionFactory.OpenSession();
            var top5Price = new List<Ticket>();

            try
            {
                top5Price = await session.Query<Ticket>()
                    .Select(e => new Ticket
                    {
                        EventId = e.EventId,
                        EventName = e.EventName,
                        TicketId = e.TicketId,
                        TicketType = e.TicketType,
                        Price = e.Price,
                        Sold = e.Sold,
                    })
                    .OrderByDescending(t => t.Price)
                    .Take(5)
                    .ToListAsync();

                session.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return top5Price;
        }

        public async Task<List<Ticket>> GetTop5Events_SalesCount()
        {
            var session = _sessionFactory.OpenSession();
            var top5Sales = new List<Ticket>();

            try
            {
                top5Sales = await session.Query<Ticket>()
                    .Select(e => new Ticket
                    {
                        EventId = e.EventId,
                        EventName = e.EventName,
                        TicketId = e.TicketId,
                        TicketType = e.TicketType,
                        Price = e.Price,
                        Sold = e.Sold,
                    })
                    .OrderByDescending(t => t.Sold)
                    .Take(5)
                    .ToListAsync();

                session.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return top5Sales;
        }

    }
}
