using EventPlatformApp.Models;
using EventPlatformApp.ServiceInterfaces;
using EventPlatformApp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NHibernate;
using ISession = NHibernate.ISession;

namespace EventPlatformApp.Tests
{
    [TestClass]
    public class EventServiceTest
    {
        private Mock<IEventService> _mockEventService;
        private EventService _eventService;
        private Mock<ISessionFactory> _mockSessionFactory;
        private Mock<ISession> _mockSession;

        [TestInitialize]
        public void Setup()
        {
            _mockEventService = new Mock<IEventService>();

            _mockSession = new Mock<ISession>();
            _mockSessionFactory = new Mock<ISessionFactory>();

            _mockSessionFactory.Setup(x => x.OpenSession())
                .Returns(_mockSession.Object);
            
            _eventService = new EventService(_mockSessionFactory.Object);
        }

        [TestMethod]
        public async Task Test_GetUpcomingEvents_ShouldReturn_EventListForSpecifiedDays()
        {
            //Arrange
            int upcomingDays = 30;

            var expected = new List<Event>
                {
                    new Event
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Test Event"
                    }
                };

            _mockEventService.Setup(x => x.GetUpcomingEvents(upcomingDays))
                .ReturnsAsync(expected);

            //Act
            var actual = await _eventService.GetUpcomingEvents(upcomingDays);

            //Assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count() > 0);
            Assert.AreEqual(expected[0].Name, actual.ToList()[0].Name);
        }

        [TestMethod]
        public async Task Test_GetUpcomingEvents_ShouldReturn_Exception()
        {
            //Arrange
            int upcomingDays = 60;

            _mockEventService.Setup(x => x.GetUpcomingEvents(upcomingDays))
                .ThrowsAsync(new Exception("Test Exception"));

            //Act
            var actual = await _eventService.GetUpcomingEvents(upcomingDays);

            //Assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count() == 0);
        }

        [TestMethod]
        public async Task Test_GetAllEvents_ShouldReturn_AllEvents()
        {
            //Arrange
            
            var expected = new List<Event>
                {
                    new Event
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Test Event 1"
                    },
                    new Event
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Test Event 2"
                    }
                };

            _mockEventService.Setup(x => x.GetAllEvents())
                .ReturnsAsync(expected);

            //Act
            var actual = await _eventService.GetAllEvents();

            //Assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count() > 0);
            Assert.AreEqual(expected[0].Name, actual.ToList()[0].Name);
        }

        [TestMethod]
        public async Task Test_GetAllEvents_ShouldReturn_Exception()
        {
            //Arrange
            
            _mockEventService.Setup(x => x.GetAllEvents())
                .ThrowsAsync(new Exception("Test Exception"));

            //Act
            var actual = await _eventService.GetAllEvents();

            //Assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count() == 0);
        }
    }
}
