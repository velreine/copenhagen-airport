using System;
using System.Collections.Generic;

namespace Entity_Framework_6_Database_first.Models
{
    public partial class Route
    {
        public Route()
        {
            Departure = new HashSet<Departure>();
            ExtraPermittedRouteOperators = new HashSet<ExtraPermittedRouteOperators>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int OriginId { get; set; }
        public int DestinationId { get; set; }
        public int OwningCompanyId { get; set; }
        public bool? OwnerOperatesThisRoute { get; set; }

        public virtual Airport Destination { get; set; }
        public virtual Airport Origin { get; set; }
        public virtual ICollection<Departure> Departure { get; set; }
        public virtual ICollection<ExtraPermittedRouteOperators> ExtraPermittedRouteOperators { get; set; }
    }
}
