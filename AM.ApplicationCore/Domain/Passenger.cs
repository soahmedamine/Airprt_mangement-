using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public int PassengerId { get; set; }
        public string PassportNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string EmailAdress { get; set; }
        public int TelNumber { get; set; }
        ICollection<Flight> flights { get; set; }
        public override string? ToString()
        {
            return "Firstname : " + FirstName + ", Lastame : " + LastName+ "Passport Number : "+PassportNumber;
        }

        public Passenger()
        {
        }

        public bool CheckProfile(String firstname , String lastname)
        {
            return this.FirstName == firstname && this.LastName == lastname;
            
        }
        public bool CheckProfile(String firstname, String lastname , String email)
        {
            return this.FirstName == firstname && this.LastName == lastname && this.EmailAdress == email;

        }

        public virtual void PassgerType
            ()
        {
            Console.WriteLine("Passenger");
        }

    }
}
