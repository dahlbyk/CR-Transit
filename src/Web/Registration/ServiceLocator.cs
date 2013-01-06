using MvcTurbine.StructureMap;

namespace Transit.Web.Registration
{
    public class ServiceLocator : StructureMapServiceLocator
    {
        public ServiceLocator()
        {
            Container.Configure(x => {
                x.AddRegistry<DataRegistry>();
            });
        }
    }
}
