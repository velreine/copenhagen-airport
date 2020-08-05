using System;
using System.Collections.Generic;

namespace Entity_Framework_6_Database_first.Models
{
    public partial class AirlineCompany
    {
        public AirlineCompany()
        {
            Departure = new HashSet<Departure>();
            ExtraPermittedRouteOperators = new HashSet<ExtraPermittedRouteOperators>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Departure> Departure { get; set; }
        public virtual ICollection<ExtraPermittedRouteOperators> ExtraPermittedRouteOperators { get; set; }
    }
}
