using System;
using System.Xml.Linq;
using NUnit.Framework;
using Transit.Core.Data;


namespace Transit.UnitTests.Core.Data
{
    [TestFixture]
    public class XmlRouteParserTests
    {
        [Test]
        public void Parse_should_give_us_what_we_want()
        {
            var doc = XDocument.Parse(routes);

            var parser = GetParser();

            var result = parser.Parse(doc);

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("R02", result["R02"].Id);
            Assert.AreEqual("Route 2", result["R02"].Name);
            Assert.AreEqual("Mt Vernon - Memorial", result["R02"].Description);
            Assert.AreEqual("East", result["R02"].Direction);
        }

        private static XmlRouteParser GetParser()
        {
            return new XmlRouteParser();
        }

        private string routes = @"
            <Routes>
              <Route>
                <Id>R01</Id>
                <Name>Route 1</Name>
                <Description>Ellis Park</Description>
                <Direction>West</Direction>
              </Route>
              <Route>
                <Id>R02</Id>
                <Name>Route 2</Name>
                <Description>Mt Vernon - Memorial</Description>
                <Direction>East</Direction>
              </Route>
            </Routes>
            ";
    }
}
