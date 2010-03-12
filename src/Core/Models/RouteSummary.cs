using System;
using Transit.Core.Data;

namespace Transit.Core.Models
{
    public class RouteSummary
    {
        public RouteSummary(RouteInfo routeInfo)
        {
            Id = routeInfo.Id;
            Name = routeInfo.Name;
            Description = routeInfo.Description;
        }

        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}
