using System.Linq;
using System.Web.Mvc;
using Transit.Core.Data;

namespace Transit.Web.Controllers
{
    public class DataController : Controller
    {
        private readonly IRouteRepository routeRepository;

        public DataController(IRouteRepository routeRepository)
        {
            this.routeRepository = routeRepository;
        }

        public ActionResult Routes(string id)
        {
            var routeIds = id == "" ? routeRepository.GetRoutes().Select(r => r.Id) : new[] { id };

            var routes = routeIds.Select(routeId => routeRepository.GetRoute(routeId)).ToArray();

            return Json(routes, JsonRequestBehavior.AllowGet);
        }
    }
}