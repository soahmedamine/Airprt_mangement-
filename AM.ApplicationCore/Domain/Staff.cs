using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Staff : Passenger
    {
        internal string EmailAddress;

        public DateTime EmployementDate { get; set; }
        public string Function { get; set; }
        public float Salary { get; set; }
        public override string? ToString()
        {
            return "Firstname : " + FirstName + ", Lastame : "
                   + LastName + "Passport Number : " + PassportNumber+", Function : "
                   +Function+", Empoyement Date : "+EmployementDate;
        }

        public override void PassgerType()
        {
            base.PassgerType();
            Console.WriteLine("Staff");
        }
    }
}
