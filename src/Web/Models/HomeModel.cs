using System.Collections.Generic;
using Transit.Core.Models;

namespace Transit.Web.Models
{
    public class HomeModel
    {
        public IEnumerable<RouteSummary> Routes { get; set; }
    }
}
