using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Transit.Core.Data
{
    public interface IXmlStopParser
    {
        Dictionary<string, IEnumerable<RouteStopInfo>> Parse(XDocument doc);
    }
}
