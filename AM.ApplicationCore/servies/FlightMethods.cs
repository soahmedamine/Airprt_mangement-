﻿using AM.ApplicationCore.Domain;
using AM.ApplicationCore.interfaces;

namespace AM.ApplicationCore.services
{
    public class FlightMethods : IFlightMethods
    {
        public List<Flight> Flights { get; set; }

        public FlightMethods(List<Flight> flights)
        {
            Flights = flights ?? new List<Flight>(); // Ensure initialization
        }

        // GetFlightDates method as required
        public List<DateTime> GetFlightDates(string destination)
        {
            return Flights.Where(f => f.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase))
                          .Select(f => f.FlightDate)
                          .ToList();
        }

        // GetFlights method based on filter type and filter value
        public List<Flight> GetFlights(string filterType, string filterValue)
        {
            switch (filterType.ToLower())
            {
                case "destination":
                    return Flights.Where(f => f.Destination.Equals(filterValue, StringComparison.OrdinalIgnoreCase)).ToList();
                case "departure":
                    return Flights.Where(f => f.Departure.Equals(filterValue, StringComparison.OrdinalIgnoreCase)).ToList();
                default:
                    throw new ArgumentException("Invalid filter type");
            }
        }

        // ShowFlightDetails - displays flight details related to the plane
        public void ShowFlightDetails(Plane plane)
        {
            var flightsForPlane = Flights.Where(f => f.Plane == plane).ToList();
            foreach (var flight in flightsForPlane)
            {
                Console.WriteLine($"Flight to {flight.Destination} on {flight.FlightDate} with {plane.planetype}");
            }
        }

        // ProgrammedFlightNumber - counts the number of flights starting from a certain date
        public int ProgrammedFlightNumber(DateTime startDate)
        {
            return Flights.Count(f => f.FlightDate >= startDate);
        }

        // DurationAverage - calculates the average flight duration to a given destination
        public double DurationAverage(string destination)
        {
            var relevantFlights = Flights.Where(f => f.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase)).ToList();
            if (!relevantFlights.Any()) return 0;
            return relevantFlights.Average(f => f.EstimatedDuration);
        }

        // OrderedDurationFlights - orders the flights by duration
        public List<Flight> OrderedDurationFlights()
        {
            return Flights.OrderBy(f => f.EstimatedDuration).ToList();
        }

        // SeniorTravellers - retrieves a list of senior travellers (age > 65)
        public List<Passenger> SeniorTravellers(Flight flight)
        {
            if (flight.Passenger == null || !flight.Passenger.Any())
            {
                throw new ArgumentNullException(nameof(flight.Passenger), "Passenger collection cannot be null or empty.");
            }
            return flight.Passenger.OfType<Traveller>().Where(t => (DateTime.Now.Year - t.BirthDate.Year) > 65).Cast<Passenger>().ToList();
        }

        // DestinationGroupedFlights - groups flights by destination
        public Dictionary<string, List<Flight>> DestinationGroupedFlights()
        {
            return Flights.GroupBy(f => f.Destination)
                          .ToDictionary(g => g.Key, g => g.ToList());
        }
    }
}
