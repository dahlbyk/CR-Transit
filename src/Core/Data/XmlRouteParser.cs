using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;

namespace Transit.Core.Data
{
    public class XmlRouteParser : IXmlRouteParser
    {
        public IDictionary<string, RouteInfo> Parse(XDocument doc)
        {
            var routes = 
               from route in doc.Element("Routes").Elements("Route")
               select new RouteInfo
               {
                   Id = (string)route.Element("Id"),
                   Name = (string)route.Element("Name"),
                   Description = (string)route.Element("Description"),
                   Direction = (string)route.Element("Direction")
               };

            return routes.ToDictionary(r => r.Id);
        }
    }
}
