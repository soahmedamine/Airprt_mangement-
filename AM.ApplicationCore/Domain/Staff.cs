namespace AM.ApplicationCore.Domain
{
    public class Staff : Passenger
    {
        public DateTime EmployementDate { get; set; }
        public string Function { get; set; } = string.Empty;
        public float Salary { get; set; }

        public override string? ToString()
        {
            return "Firstname : " + FirstName + ", Lastame : " + LastName + " Passport Number : " + PassportNumber + ", Function : " + Function + ", Employement Date : " + EmployementDate;
        }

        public override void PassengerType() // Fix typo
        {
            base.PassengerType(); // Correct base method call
            Console.WriteLine("Staff");
        }
    }
}
