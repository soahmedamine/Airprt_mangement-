namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public List<Passenger> Passenger { get; set; } = new List<Passenger>();

        public int FlightID { get; set; }
        public string Destination { get; set; } = string.Empty;
        public string Departure { get; set; } = string.Empty;
        public DateTime FlightDate { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public int EstimatedDuration { get; set; }
        public Plane Plane { get; set; } = new Plane(); // Keep this, remove duplicate 'plane'

        public override string? ToString()
        {
            return "Destination : " + Destination + ", Departure : " + Departure;
        }
    }
}
