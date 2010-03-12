using System;

namespace Transit.Core.Data
{
    public class RouteStopInfo
    {
        public string Number { get; set; }
        public string Direction { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Description { get; set; }
        public decimal Mile { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string PostalCode { get; set; }
    }
}
