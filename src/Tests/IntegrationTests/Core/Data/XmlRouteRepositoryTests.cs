using System;
using System.Linq;
using NUnit.Framework;
using Transit.Core.Data;

namespace Transit.IntegrationTests.Core.Data
{
    [TestFixture]
    public class XmlRouteRepositoryTests
    {
        private static XmlRouteParser routeParser;
        private XmlStopParser stopParser;

        [SetUp]
        public void SetUp()
        {
            routeParser = new XmlRouteParser();
            stopParser = new XmlStopParser();
        }

        [TestCase("R01", "Ellis Park", 93)]
        [TestCase("R05B", "Blairs Ferry - Lindale", 119)]
        public void GetRoute_returns_a_route(string routeId, string routeDescription, int stopCount)
        {
            var repository = GetRepository();

            var route = repository.GetRoute(routeId);

            Assert.AreEqual(routeId, route.Id);
            Assert.AreEqual(routeDescription, route.Description);
            Assert.AreEqual(stopCount, route.Stops.Count());
        }

        private XmlRouteRepository GetRepository()
        {
            return new XmlRouteRepository(routeParser, stopParser);
        }
    }
}
