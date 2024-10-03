namespace AM.ApplicationCore.Domain
{
    public enum PlaneType
    {
        Boing,
        Airbus,
    }

    public class Plane
    {
        public int PlaneId { get; set; }
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public PlaneType planetype { get; set; }
        public ICollection<Flight> Flights { get; set; } = new List<Flight>(); // Initialize list

        public override string? ToString()
        {
            return "Capacity : " + Capacity + ", Manufacture Date : " + ManufactureDate + ", Plane type : " + planetype;
        }

        public Plane() { }

        public Plane(PlaneType planetype, int capacity, DateTime manufactureDate)
        {
            this.planetype = planetype;
            Capacity = capacity;
            ManufactureDate = manufactureDate;
        }
    }
}
