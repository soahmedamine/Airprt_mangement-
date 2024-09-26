using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public int FlightID { get; set; }
        public string Destination { get; set; }
        public string Departure { get; set; }
        public DateTime FlightDate { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public int EstimatedDuration { get; set; }
        Plane plane { get; set; }
        ICollection<Passenger> passengers { get; set; }

        public override string? ToString()
        {
            return "Destination : "+Destination+", Departure : "+Departure;
        }
    }
}
