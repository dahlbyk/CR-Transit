using StructureMap.Configuration.DSL;
using Transit.Core.Data;
using Transit.Core.Models;

namespace Transit.Web.Registration
{
    public class DataRegistry : Registry
    {
        public DataRegistry()
        {
            Scan(x =>
            {
                x.AssemblyContainingType<RouteSummary>();
                x.WithDefaultConventions();
                x.ExcludeNamespace("NewRelic");
            });
            For<IRouteRepository>().Use<XmlRouteRepository>();
        }
    }
}
