using MvcTurbine.ComponentModel;

namespace Transit.Web.Registration
{
    public class ServiceRegistration : IServiceRegistration
    {
        public void Register(IServiceLocator locator)
        {
            //locator.Register<IRouteRepository, XmlRouteRepository>();
            //locator.Register<IXmlRouteParser, XmlRouteParser>();
            //locator.Register<IXmlStopParser, XmlStopParser>();
            //ObjectFactory.Initialize(x =>
            //{
            //    x.AddRegistry<DataRegistry>();
            //});
        }
    }
}
