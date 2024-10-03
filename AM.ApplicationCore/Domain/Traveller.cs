namespace AM.ApplicationCore.Domain
{
    public class Traveller : Passenger
    {
        public string HealthInformation { get; set; }
        public string Nationality { get; set; }

        public override string? ToString()
        {
            return "Firstname : " + FirstName + ", Lastame : " + LastName + " Health Information : " + HealthInformation + ", Nationality : " + Nationality;
        }

        public override void PassengerType() // Fix typo
        {
            base.PassengerType(); // Correct base method call
            Console.WriteLine("Traveller");
        }
    }
}
