using System;
using System.Collections.Generic;
using Transit.Core.Models;

namespace Transit.Mvc.Models
{
    public class HomeModel
    {
        public IEnumerable<RouteSummary> Routes { get; set; }
    }
}
