using System.Linq;
using System.Web.Mvc;
using Transit.Core.Data;
using Transit.Web.Models;

namespace Transit.Web.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private IRouteRepository routeRepository;

        public HomeController(IRouteRepository routeRepository)
        {
            this.routeRepository = routeRepository;
        }

        public ActionResult Index()
        {
            var model = new HomeModel
            {
                Routes = routeRepository.GetRoutes().OrderBy(r => r.Id)
            };

            return View(model);
        }

        public ActionResult Routes()
        {
            var model = new HomeModel
            {
                Routes = routeRepository.GetRoutes().OrderBy(r => r.Id)
            };

            return View(model);
        }

        //NOTE: No need to specify an About action since empty actions are inferred.
    }
}