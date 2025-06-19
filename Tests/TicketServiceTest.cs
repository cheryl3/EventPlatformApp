using EventPlatformApp.Models;
using EventPlatformApp.ServiceInterfaces;
using EventPlatformApp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NHibernate;

namespace EventPlatformApp.Tests
{
    [TestClass]
    public class TicketServiceTest
    {
        private Mock<ITicketService> _mockTicketService;
        private Mock<IEventService> _mockEventService;
        private Mock<ISessionFactory> _mockSessionFactory;
        private Mock<IWebHostEnvironment> _mockWebHostEnv;
        private TicketService _ticketService;

        [TestInitialize]
        public void Setup()
        {
            _mockTicketService = new Mock<ITicketService>();
            _mockSessionFactory = new Mock<ISessionFactory>();
            _mockEventService = new Mock<IEventService>();
            _mockWebHostEnv = new Mock<IWebHostEnvironment>();
            _ticketService = new TicketService(_mockSessionFactory.Object, _mockEventService.Object, _mockWebHostEnv.Object);
        }

        [TestMethod]
        public async Task Test_GetTicketData_ShouldReturn_EventDataForSpecifiedEventID ()
        {
            //Arrange
            string eventID = Guid.NewGuid().ToString();

            var expected = new List<Ticket>
            {
                new Ticket
                {
                    TicketId = 1,
                    EventId = eventID,
                    EventName = "Test Event",
                    TicketType = "VIP",
                    Price = 250,
                    Sold = 700
                }
            };

            _mockTicketService.Setup(x => x.GetTicketData(eventID))
                .ReturnsAsync(expected);

            //Act
            var actual = await _ticketService.GetTicketData(eventID);

            //Assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count() > 0);
            Assert.AreEqual(expected[0].TicketType, actual[0].TicketType);
        }

        [TestMethod]
        public async Task Test_GetTicketData_ShouldReturn_Exception()
        {
            //Arrange
            string eventID = Guid.NewGuid().ToString();

            _mockTicketService.Setup(x => x.GetTicketData(eventID))
                .ThrowsAsync(new Exception("Test Exception"));

            //Act
            var actual = await _ticketService.GetTicketData(eventID);

            //Assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count() == 0);
        }
    }
}
