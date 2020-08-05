using System;
using System.Collections.Generic;

namespace Entity_Framework_6_Database_first.Models
{
    public partial class ExtraPermittedRouteOperators
    {
        public int Id { get; set; }
        public int AirlineCompanyId { get; set; }
        public int RouteId { get; set; }

        public virtual AirlineCompany AirlineCompany { get; set; }
        public virtual Route Route { get; set; }
    }
}
