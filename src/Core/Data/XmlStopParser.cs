﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Transit.Core.Data
{
    public class XmlStopParser
    {
        public ILookup<string, IEnumerable<RouteStop>> Parse(XDocument doc)
        {
            var groups = 
               from stop in doc.Element("Stops").Elements("Stop")
               let route = (string)stop.Element("Route")
               let routeStop = new RouteStop
               {
                   Number = (string)stop.Element("Number"),
                   Direction = (string)stop.Element("Direction"),
                   Location = (string)stop.Element("Location"),
                   City = (string)stop.Element("City"),
                   State = (string)stop.Element("State"),
                   Description = (string)stop.Element("Description"),
                   Mile = (decimal)stop.Element("Mile"),
                   Latitude = (decimal)stop.Element("Latitude"),
                   Longitude = (decimal)stop.Element("Longitude"),
                   PostalCode = (string)stop.Element("PostalCode")
               }
               group routeStop by route;

            return groups.ToLookup(g => g.Key, g => g.AsEnumerable());
        }
    }
}