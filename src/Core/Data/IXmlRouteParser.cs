using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Transit.Core.Data
{
    public interface IXmlRouteParser
    {
        ILookup<string, IEnumerable<RouteInfo>> Parse(XDocument doc);
    }
}
