using MvcTurbine.ComponentModel;
using MvcTurbine.Web;
using Transit.Web.Registration;

namespace Transit.Web
{
    public class DefaultMvcApplication : TurbineApplication
    {
        //NOTE: You want to hit this piece of code only once.
        static DefaultMvcApplication()
        {
            //TODO: Specify your own service locator here.
            ServiceLocatorManager.SetLocatorProvider(() => new ServiceLocator());
        }
    }
}