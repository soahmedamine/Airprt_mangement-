// See https://aka.ms/new-console-template for more information

using AM.ApplicationCore.Domain;
using AM.ApplicationCore.services;
using System.ComponentModel.DataAnnotations;

Console.WriteLine("Hello, World!");
Plane plane = new Plane();
plane.Capacity = 100;
plane.ManufactureDate = DateTime.Now;
plane.planetype = PlaneType.Boing;
Console.WriteLine(plane.ToString());
Plane plane2 = new Plane(PlaneType.Airbus, 200, new DateTime(2024, 09, 02));
Console.WriteLine(plane2.ToString());
Passenger passenger = new Passenger { FirstName = "ahmed", LastName = "amine", EmailAdress = "m@g.c" };
Passenger passenger2 = new Passenger { FirstName = "ahmed2", LastName = "amine2", EmailAdress = "m@g.c2" };
Console.WriteLine(passenger.CheckProfile("ahmed", "f"));
Console.WriteLine(passenger.CheckProfile("ahmed", "amine", "m@g.c"));
Staff staff = new Staff();
staff.PassgerType();
staff.PassgerType();

// Create some Flight instances
// Create some Flight instances
Flight flight1 = new Flight
{
    Destination = "Paris",
    passengers = new List<Passenger>
    {
        new Traveller { BirthDate = new DateTime(1950, 1, 1) },
    }
};
Flight flight2 = new Flight { Destination = "London", FlightDate = DateTime.Now.AddDays(2), EstimatedDuration = (int)TimeSpan.FromHours(3).TotalMinutes };
Flight flight3 = new Flight { Destination = "New York", FlightDate = DateTime.Now.AddDays(3), EstimatedDuration = (int)TimeSpan.FromHours(8).TotalMinutes };


// Add Flights to a list
List<Flight> flights = new List<Flight>();
flights.Add(flight1);
flights.Add(flight2);
flights.Add(flight3);

// Instantiate FlightMethods with the list of flights
FlightMethods flightMethods = new FlightMethods(flights);

// Test the GetFlightDates method
List<DateTime> flightDates = flightMethods.GetFlightDates("Paris");
Console.WriteLine("Flight Dates:");
foreach (DateTime date in flightDates)
{
    Console.WriteLine(date);
}

// Test the GetFlights method with destination filter
List<Flight> parisFlights = flightMethods.GetFlights("Destination", "Paris");
Console.WriteLine("Paris Flights:");
foreach (Flight flight in parisFlights)
{
    Console.WriteLine(flight.ToString());
}

// Test ShowFlightDetails
Console.WriteLine("Flight Details:");
flightMethods.ShowFlightDetails(plane);

// Test ProgrammedFlightNumber
int programmedFlightNumber = flightMethods.ProgrammedFlightNumber(DateTime.Now);
Console.WriteLine("Programmed Flight Number: " + programmedFlightNumber);

// Test DurationAverage for Paris destination
double durationAverage = flightMethods.DurationAverage("Paris");
Console.WriteLine("Duration Average for Paris: " + TimeSpan.FromMinutes(durationAverage));
Console.WriteLine("Duration Average for Paris: " + durationAverage);

// Test OrderedDurationFlights
List<Flight> orderedDurationFlights = flightMethods.OrderedDurationFlights();
Console.WriteLine("Ordered Duration Flights:");
foreach (Flight flight in orderedDurationFlights)
{
    Console.WriteLine(flight.ToString());
}

// Test SeniorTravellers (assuming senior passengers are created in the flight)
// Test SeniorTravellers (assuming senior passengers are created in the flight)
List<Traveller> seniorTravellers = flightMethods.SeniorTravellers(flight1);
Console.WriteLine("Senior Travellers: " + seniorTravellers.Count);


// Create some Flight instances
Flight flight4 = new Flight { Destination = "Paris", FlightDate = DateTime.Now.AddDays(1), EstimatedDuration = (int)TimeSpan.FromHours(2).TotalMinutes };
Flight flight5 = new Flight { Destination = "London", FlightDate = DateTime.Now.AddDays(2), EstimatedDuration = (int)TimeSpan.FromHours(3).TotalMinutes };
Flight flight6 = new Flight { Destination = "New York", FlightDate = DateTime.Now.AddDays(3), EstimatedDuration = (int)TimeSpan.FromHours(8).TotalMinutes };


// Test SeniorTravellers (assuming senior passengers are created in the flight)
List<Traveller> seniorTravellers1 = flightMethods.SeniorTravellers(flight1);
Console.WriteLine("Senior Travellers: " + seniorTravellers1.Count);



// Test SeniorTravellers (assuming senior passengers are created in the flight)
List<Traveller> seniorTravellers2 = flightMethods.SeniorTravellers(flight2);
Console.WriteLine("Senior Travellers: " + seniorTravellers2.Count);


// Test DestinationGroupedFlights
Dictionary<string, List<Flight>> destinationGroupedFlights = flightMethods.DestinationGroupedFlights();
Console.WriteLine("Destination Grouped Flights:");
foreach (KeyValuePair<string, List<Flight>> kvp in destinationGroupedFlights)
{
    Console.WriteLine("Destination: " + kvp.Key);
    foreach (Flight flight in kvp.Value)
    {
        Console.WriteLine(flight.ToString());
    }
}

