using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Transit.Core.Data
{
    public class XmlRouteParser : IXmlRouteParser
    {
        public Dictionary<string, RouteInfo> Parse(XDocument doc)
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
