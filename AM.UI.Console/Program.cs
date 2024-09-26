// See https://aka.ms/new-console-template for more information

using AM.ApplicationCore.Domain;
using System.ComponentModel.DataAnnotations;

Console.WriteLine("Hello, World!");
Plane plane = new Plane();
plane.Capacity = 100;
plane.ManufactureDate = DateTime.Now;
plane.planetype = PlaneType.Boing;
Console.WriteLine(plane.ToString());
Plane plane2 = new Plane(PlaneType.Airbus , 200 ,new DateTime(2024,09,02));
Console.WriteLine( plane2.ToString());
Passenger passenger = new Passenger { FirstName = "khalil", LastName = "boukadida", EmailAdress = "m@g.c" };
Console.WriteLine(passenger.CheckProfile("khalil", "f"));
Console.WriteLine(passenger.CheckProfile("khalil", "boukadida", "m@g.c"));