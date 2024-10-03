using AM.ApplicationCore.Domain;
using AM.ApplicationCore.services;
using System;

var random = new Random();

// Generate random plane information
Plane plane = new Plane
{
    Capacity = random.Next(100, 300),
    ManufactureDate = DateTime.Now.AddYears(-random.Next(1, 30)),
    planetype = random.Next(0, 2) == 0 ? PlaneType.Boing : PlaneType.Airbus
};
Plane plane2 = new Plane(PlaneType.Airbus, 200, new DateTime(2024, 09, 02));

Console.WriteLine(plane.ToString());
Console.WriteLine(plane2.ToString());

// Generate random passengers
Passenger passenger = new Passenger
{
    FirstName = "ahmed",
    LastName = "amine",
    EmailAdress = "m@g.c",
    TelNumber = random.Next(100000000, 999999999)
};
Passenger passenger2 = new Passenger
{
    FirstName = "ahmed2",
    LastName = "amine2",
    EmailAdress = "m@g.c2",
    TelNumber = random.Next(100000000, 999999999)
};

Console.WriteLine("Testing CheckProfile:");
Console.WriteLine(passenger.CheckProfile("ahmed", "f"));    // Expected: False
Console.WriteLine(passenger.CheckProfile("ahmed", "amine", "m@g.c"));    // Expected: True

Staff staff = new Staff();
staff.PassengerType(); // Expected: "Passenger" followed by "Staff"

// Create random Flight instances
var destinations = new string[] { "Paris", "London", "New York", "Tokyo", "Berlin" };

Flight flight = new Flight
{
    Destination = destinations[random.Next(destinations.Length)],
    FlightDate = DateTime.Now.AddDays(random.Next(1, 100)),
    Passenger = new List<Passenger>
    {
        new Traveller
        {
            FirstName = "John",
            LastName = "Doe",
            BirthDate = new DateTime(random.Next(1940, 2000), random.Next(1, 13), random.Next(1, 28)),
            HealthInformation = "Good",
            Nationality = "US"
        }
    }
};

Flight flight2 = new Flight
{
    Destination = destinations[random.Next(destinations.Length)],
    FlightDate = DateTime.Now.AddDays(random.Next(1, 100)),
    EstimatedDuration = (int)TimeSpan.FromHours(random.Next(2, 12)).TotalMinutes
};

Flight flight3 = new Flight
{
    Destination = destinations[random.Next(destinations.Length)],
    FlightDate = DateTime.Now.AddDays(random.Next(1, 100)),
    EstimatedDuration = (int)TimeSpan.FromHours(random.Next(2, 12)).TotalMinutes
};

List<Flight> flights = new List<Flight> { flight, flight2, flight3 };

// Create FlightMethods instance
FlightMethods flightMethods = new FlightMethods(flights);

// Test GetFlightDates
Console.WriteLine("Testing GetFlightDates for 'Paris':");
List<DateTime> flightDates = flightMethods.GetFlightDates("Paris");
if (flightDates.Count > 0)
{
    foreach (DateTime date in flightDates)
    {
        Console.WriteLine(date);  // Expected: the date of the flight to Paris
    }
}
else
{
    Console.WriteLine("No flights to Paris found.");
}

// Test GetFlights
Console.WriteLine("Testing GetFlights for 'Destination = Paris':");
List<Flight> parisFlights = flightMethods.GetFlights("Destination", "Paris");
foreach (var parisFlight in parisFlights)
{
    Console.WriteLine(parisFlight.ToString());  // Expected: details of the flight to Paris
}

// Test ShowFlightDetails
Console.WriteLine("Testing ShowFlightDetails:");
flightMethods.ShowFlightDetails(plane);  // Expected: Flights linked to 'plane'

// Test ProgrammedFlightNumber
Console.WriteLine("Testing ProgrammedFlightNumber from today:");
int programmedFlightNumber = flightMethods.ProgrammedFlightNumber(DateTime.Now);
Console.WriteLine($"Programmed Flight Number: {programmedFlightNumber}");  // Expected: Number of future flights

// Test DurationAverage
Console.WriteLine("Testing DurationAverage for 'Paris':");
double durationAverage = flightMethods.DurationAverage("Paris");
if (durationAverage > 0)
{
    Console.WriteLine($"Duration Average for Paris: {TimeSpan.FromMinutes(durationAverage)}");  // Expected: Flight duration in TimeSpan
}
else
{
    Console.WriteLine("No flights to Paris found to calculate average.");
}
Console.WriteLine($"Duration Average for Paris in minutes: {durationAverage}");

// Test OrderedDurationFlights
Console.WriteLine("Testing OrderedDurationFlights:");
List<Flight> orderedDurationFlights = flightMethods.OrderedDurationFlights();
foreach (Flight f in orderedDurationFlights)
{
    Console.WriteLine(f.ToString());  // Expected: Flights ordered by duration
}

// Test SeniorTravellers
Console.WriteLine("Testing SeniorTravellers:");
List<Traveller> seniorTravellers = flightMethods.SeniorTravellers(flight).OfType<Traveller>().ToList();
Console.WriteLine($"Senior Travellers Count: {seniorTravellers.Count}");  // Expected: Count of senior travellers (age > 65)

// Test DestinationGroupedFlights
Console.WriteLine("Testing DestinationGroupedFlights:");
Dictionary<string, List<Flight>> destinationGroupedFlights = flightMethods.DestinationGroupedFlights();
foreach (KeyValuePair<string, List<Flight>> kvp in destinationGroupedFlights)
{
    Console.WriteLine($"Destination: {kvp.Key}");
    foreach (Flight f in kvp.Value)
    {
        Console.WriteLine(f.ToString());  // Expected: Flights grouped by destination
    }
}
