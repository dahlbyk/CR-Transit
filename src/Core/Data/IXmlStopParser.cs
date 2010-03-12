using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Transit.Core.Data
{
    public interface IXmlStopParser
    {
        IDictionary<string, IEnumerable<RouteStopInfo>> Parse(XDocument doc);
    }
}
