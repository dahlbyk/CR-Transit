using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Transit.Core.Data
{
    public class XmlRouteParser
    {
        public ILookup<string, IEnumerable<RouteInfo>> Parse(XDocument doc)
        {
            var groups = 
               from route in doc.Element("Routes").Elements("Route")
               let id = (string)route.Element("Id")
               let routeInfo = new RouteInfo
               {
                   Name = (string)route.Element("Name"),
                   Description = (string)route.Element("Description"),
                   Direction = (string)route.Element("Direction")
               }
               group routeInfo by id;

            return groups.ToLookup(g => g.Key, g => g.AsEnumerable());
        }
    }
}
