using System;

namespace Transit.Core.Data
{
    public interface IXmlRouteRepository
    {
        RouteInfo GetRoute(string id);
    }
}
