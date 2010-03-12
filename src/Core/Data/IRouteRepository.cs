using System;
using System.Collections.Generic;
using Transit.Core.Models;

namespace Transit.Core.Data
{
    public interface IRouteRepository
    {
        RouteInfo GetRoute(string id);
        IEnumerable<RouteSummary> GetRoutes();
    }
}
