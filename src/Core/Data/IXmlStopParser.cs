using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Transit.Core.Data
{
    public interface IXmlStopParser
    {
        ILookup<string, IEnumerable<RouteStopInfo>> Parse(XDocument doc);
    }
}
