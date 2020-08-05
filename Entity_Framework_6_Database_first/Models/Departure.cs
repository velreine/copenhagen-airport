using System;
using System.Collections.Generic;

namespace Entity_Framework_6_Database_first.Models
{
    public partial class Departure
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public DateTime TimeOfDeparture { get; set; }
        public int OperatorId { get; set; }

        public virtual AirlineCompany Operator { get; set; }
        public virtual Route Route { get; set; }
    }
}
