using MvcTurbine.StructureMap;

namespace Transit.Mvc.Registration
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
