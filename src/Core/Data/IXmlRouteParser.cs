using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Transit.Core.Data
{
    public interface IXmlRouteParser
    {
        Dictionary<string, RouteInfo> Parse(XDocument doc);
    }
}
