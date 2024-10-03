using AM.ApplicationCore.Domain;
using AM.ApplicationCore.services;

Console.WriteLine("Hello, World!");
Plane plane = new Plane { Capacity = 100, ManufactureDate = DateTime.Now, planetype = PlaneType.Boing };
Console.WriteLine(plane.ToString());

Plane plane2 = new Plane(PlaneType.Airbus, 200, new DateTime(2024, 09, 02));
Console.WriteLine(plane2.ToString());

Passenger passenger = new Passenger { FirstName = "ahmed", LastName = "amine", EmailAdress = "m@g.c" };
Passenger passenger2 = new Passenger { FirstName = "ahmed2", LastName = "amine2", EmailAdress = "m@g.c2" };
Console.WriteLine(passenger.CheckProfile("ahmed", "f"));
Console.WriteLine(passenger.CheckProfile("ahmed", "amine", "m@g.c"));

Staff staff = new Staff();
staff.PassengerType();

// Create some Flight instances
Flight flight = new Flight
{
    Destination = "Paris",
    Passenger = new List<Passenger>
    {
        new Traveller { BirthDate = new DateTime(1950, 1, 1) }
    }
};

Flight flight2 = new Flight { Destination = "London", FlightDate = DateTime.Now.AddDays(2), EstimatedDuration = (int)TimeSpan.FromHours(3).TotalMinutes };
Flight flight3 = new Flight { Destination = "New York", FlightDate = DateTime.Now.AddDays(3), EstimatedDuration = (int)TimeSpan.FromHours(8).TotalMinutes };

List<Flight> flights = new List<Flight> { flight, flight2, flight3 };

FlightMethods flightMethods = new FlightMethods(flights);

List<DateTime> flightDates = flightMethods.GetFlightDates("Paris");
Console.WriteLine("Flight Dates:");
foreach (DateTime date in flightDates)
{
    Console.WriteLine(date);
}

List<Flight> parisFlights = flightMethods.GetFlights("Destination", "Paris");
Console.WriteLine("Paris Flights:");
foreach (var parisFlight in parisFlights)
{
    Console.WriteLine(parisFlights.ToString());
}

Console.WriteLine("Flight Details:");
flightMethods.ShowFlightDetails(plane);

int programmedFlightNumber = flightMethods.ProgrammedFlightNumber(DateTime.Now);
Console.WriteLine("Programmed Flight Number: " + programmedFlightNumber);

// Test DurationAverage for Paris destination
double durationAverage = flightMethods.DurationAverage("Paris");
Console.WriteLine("Duration Average for Paris: " + TimeSpan.FromMinutes(durationAverage));
Console.WriteLine("Duration Average for Paris: " + durationAverage);

Console.WriteLine("******************************************************************************");

List<Flight> orderedDurationFlights = flightMethods.OrderedDurationFlights();
Console.WriteLine("Ordered Duration Flights:");
foreach (Flight f in orderedDurationFlights)
{
    Console.WriteLine(f.ToString());
}

List<Traveller> seniorTravellers = flightMethods.SeniorTravellers(flight).OfType<Traveller>().ToList();
Console.WriteLine("Senior Travellers: " + seniorTravellers.Count);

Dictionary<string, List<Flight>> destinationGroupedFlights = flightMethods.DestinationGroupedFlights();
Console.WriteLine("Destination Grouped Flights:");
foreach (KeyValuePair<string, List<Flight>> kvp in destinationGroupedFlights)
{
    Console.WriteLine("Destination: " + kvp.Key);
    foreach (Flight f in kvp.Value)
    {
        Console.WriteLine(f.ToString());
    }
}
