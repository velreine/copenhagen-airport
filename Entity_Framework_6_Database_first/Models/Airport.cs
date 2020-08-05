using System;
using System.Collections.Generic;

namespace Entity_Framework_6_Database_first.Models
{
    public partial class Airport
    {
        public Airport()
        {
            RouteDestination = new HashSet<Route>();
            RouteOrigin = new HashSet<Route>();
        }

        public int Id { get; set; }
        public string Iata { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Route> RouteDestination { get; set; }
        public virtual ICollection<Route> RouteOrigin { get; set; }
    }
}
