using System;
using System.Collections.Generic;

namespace Transit.Core.Data
{
    public class RouteInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Direction { get; set; }
        public IEnumerable<RouteStopInfo> Stops { get; set; }
    }
}
