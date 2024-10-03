namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public int PassengerId { get; set; }
        public string? PassportNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? EmailAdress { get; set; }
        public int TelNumber { get; set; }
        public ICollection<Flight> Flights { get; set; } = new List<Flight>(); // Initialize list

        public override string? ToString()
        {
            return "Firstname : " + FirstName + ", Lastame : " + LastName + " Passport Number : " + PassportNumber;
        }

        public Passenger()
        {
            PassportNumber = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            EmailAdress = string.Empty;
        }

        public bool CheckProfile(String firstname, String lastname)
        {
            return this.FirstName == firstname && this.LastName == lastname;
        }

        public bool CheckProfile(String firstname, String lastname, String email)
        {
            return this.FirstName == firstname && this.LastName == lastname && this.EmailAdress == email;
        }

        public virtual void PassengerType() // Fix the typo
        {
            Console.WriteLine("Passenger");
        }
    }
}
