using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.interfaces
{
    public interface IFlightMethods
    {
        List<DateTime> GetFlightDates(string destination);
        List<Flight> GetFlights(string filterType, string filterValue);
        void ShowFlightDetails(Plane plane);
        int ProgrammedFlightNumber(DateTime startDate);
        double DurationAverage(string destination);
        List<Flight> OrderedDurationFlights();
        List<Passenger> SeniorTravellers(Flight flight);
        Dictionary<string, List<Flight>> DestinationGroupedFlights(); // Add return type here
    }
}
