using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Transit.Core.Models;

namespace Transit.Core.Data
{
    public class XmlRouteRepository : IRouteRepository
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

        public IEnumerable<RouteSummary> GetRoutes()
        {
            return from route in routes.Values
                   select new RouteSummary(route);
        }

        private void ParseFiles()
        {
            var routeDocument = XDocument.Load(DataPath("routes.xml"));
            routes = routeParser.Parse(routeDocument);

            var stopDocument = XDocument.Load(DataPath("stops.xml"));
            stops = stopParser.Parse(stopDocument);

            foreach (var route in routes.Values)
                route.Stops = stops[route.Id];
        }

        private static string DataPath(string fileName)
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var path = Path.Combine(baseDirectory, @"Data\" + fileName);
            return path;
        }
    }
}
