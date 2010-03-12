using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap.Configuration.DSL;
using Transit.Core.Data;
using Transit.Core.Models;

namespace Transit.Mvc.Registration
{
    public class DataRegistry : Registry
    {
        public DataRegistry()
        {
            Scan(x =>
            {
                x.AssemblyContainingType<RouteSummary>();
                x.WithDefaultConventions();
            });
            ForRequestedType<IRouteRepository>().TheDefaultIsConcreteType<XmlRouteRepository>();
        }
    }
}
