using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Transit.Core.Data
{
    public class XmlRouteRepository : IXmlRouteRepository
    {
        private readonly IXmlRouteParser routeParser;
        private readonly IXmlStopParser stopParser;

        private Dictionary<string, RouteInfo> routes;
        private Dictionary<string, IEnumerable<RouteStopInfo>> stops;

        public XmlRouteRepository(IXmlRouteParser routeParser, IXmlStopParser stopParser)
        {
            this.routeParser = routeParser;
            this.stopParser = stopParser;

            ParseFiles();
        }

        public RouteInfo GetRoute(string id)
        {
            RouteInfo route;
            if (routes.TryGetValue(id, out route))
                return route;
            return null;
        }

        private void ParseFiles()
        {
            XDocument routeDocument = XDocument.Load(@"J:\Dev\Transit\data\IA.CedarRapids\routes.xml");
            routes = routeParser.Parse(routeDocument);

            XDocument stopDocument = XDocument.Load(@"J:\Dev\Transit\data\IA.CedarRapids\stops.xml");
            stops = stopParser.Parse(stopDocument);

            foreach (var route in routes.Values)
                route.Stops = stops[route.Id];
        }
    }
}
