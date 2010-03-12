using System;
using System.Linq;
using System.Xml.Linq;
using NUnit.Framework;
using Transit.Core.Data;


namespace Transit.UnitTests.Core.Data
{
    [TestFixture]
    public class XmlStopParserTests
    {
        [Test]
        public void Test()
        {
            var doc = XDocument.Parse(stops);

            var parser = GetParser();

            var result = parser.Parse(doc);
            var route1 = result["R01"];
            var stop1 = route1.First();

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(2, route1.Count());
            Assert.AreEqual("Lot 44", stop1.Number);
            Assert.AreEqual(" out", stop1.Direction);
            Assert.AreEqual(" Lot 44 SE", stop1.Location);
            Assert.AreEqual("Cedar Rapids", stop1.City);
            Assert.AreEqual("IA", stop1.State);
            Assert.AreEqual(" concrete pad", stop1.Description);
            Assert.AreEqual(0m, stop1.Mile);
            Assert.AreEqual(41.9697953829611m, stop1.Latitude);
            Assert.AreEqual(-91.660023271759m, stop1.Longitude);
            Assert.AreEqual("52403", stop1.PostalCode);
        }

        private static XmlStopParser GetParser()
        {
            return new XmlStopParser();
        }

        private string stops = @"
            <Stops>
	            <Stop>
		            <Route>R01</Route>
		            <Number>Lot 44</Number>
		            <Direction> out</Direction>
		            <Location> Lot 44 SE</Location>
		            <City>Cedar Rapids</City>
		            <State>IA</State>
		            <Description> concrete pad</Description>
		            <Mile>0</Mile>
		            <Latitude>41.9697953829611</Latitude>
		            <Longitude>-91.660023271759</Longitude>
		            <PostalCode>52403</PostalCode>
	            </Stop>
	            <Stop>
		            <Route>R01</Route>
		            <Number>1</Number>
		            <Direction> out</Direction>
		            <Location> C St &amp; 14th Ave SW</Location>
		            <City>Cedar Rapids</City>
		            <State>IA</State>
		            <Description> grass to sidewalk</Description>
		            <Mile>0.4</Mile>
		            <Latitude>41.9651218</Latitude>
		            <Longitude>-91.6635939</Longitude>
		            <PostalCode>52404</PostalCode>
	            </Stop>
                <Stop>
		            <Route>R02</Route>
		            <Number>1</Number>
		            <Direction> out</Direction>
		            <Location> 10th Ave &amp; 4th St  SE</Location>
		            <City>Cedar Rapids</City>
		            <State>IA</State>
		            <Description> concrete pad</Description>
		            <Mile>0.2</Mile>
		            <Latitude>41.9723830841763</Latitude>
		            <Longitude>-91.6587299181701</Longitude>
		            <PostalCode>52404</PostalCode>
	            </Stop>
            </Stops>
            ";
    }
}
