using System;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Xml.Linq;
using Transit.Core.Data;

namespace Transit.Mvc.Controllers
{
    public class KmlController : Controller
    {
        private readonly IRouteRepository routeRepository;

        public KmlController(IRouteRepository routeRepository)
        {
            this.routeRepository = routeRepository;
        }

        public ActionResult Stops(string id)
        {
            var route = routeRepository.GetRoute(id);
            XNamespace ns = "http://www.opengis.net/kml/2.2";
            var kml = new XDocument(
                new XDeclaration("1.0", "UTF-8", null),
                new XElement(ns + "kml",
                    new XElement(ns + "Document",
                        new XElement(ns + "name", "Cedar Rapids Transit"),
                        new XElement(ns + "description", "Cedar Rapids Transit - {0} Stops".FormatWith(id)),
                            from stop in route.Stops
                            select new XElement(ns + "Placemark",
                                new XElement(ns + "name", stop.Location),
                                new XElement(ns + "description", stop.Description),
                                new XElement(ns + "Point",
                                    new XElement(ns + "coordinates", "{0},{1}".FormatWith(stop.Longitude, stop.Latitude)))
                            )
                    )
                )
            );

            Response.AddHeader("content-disposition", "attachment; filename={0}.stops.kml".FormatWith(id));

            return Content(kml.ToString(SaveOptions.None), "text/plain", Encoding.UTF8);
        }

        public ActionResult Route(string id)
        {
            var route = routeRepository.GetRoute(id);
            XNamespace ns = "http://www.opengis.net/kml/2.2";

            var styleId = "route{0}".FormatWith(route.Id);

            var kml = new XDocument(
                new XDeclaration("1.0", "UTF-8", null),
                new XElement(ns + "kml",
                    new XElement(ns + "Document",
                        new XElement(ns + "name", "Cedar Rapids Transit"),
                        new XElement(ns + "description", "Cedar Rapids Transit - {0}".FormatWith(id)),
                        new XElement(ns + "Style",
                            new XAttribute("id", styleId),
                            new XElement(ns + "LineStyle",
                                new XElement(ns + "color", route.Color),
                                new XElement(ns + "width", 3)
                            )
                        ),
                        new XElement(ns + "Placemark",
                            new XElement(ns + "name", route.Name),
                            new XElement(ns + "description", route.Description),
                            new XElement(ns + "styleUrl", "#" + styleId),
                            new XElement(ns + "LineString",
                                new XElement(ns + "altitudeMode", "relative"),
                                new XElement(ns + "coordinates", route.Stops.Aggregate(new StringBuilder(), (sb, stop) => sb.AppendFormat("{0},{1},0 ", stop.Longitude, stop.Latitude)))
                            )
                        )
                    )
                )
            );

            Response.AddHeader("content-disposition", "attachment; filename={0}.route.kml".FormatWith(id));

            return Content(kml.ToString(SaveOptions.None), "text/plain", Encoding.UTF8);
        }
    }
}
