using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public enum PlaneType
    {
        Boing,
        Airbus,
    }
    public class Plane
    {
        internal PlaneType PlaneType;

        //the public references the getters and setters and the variable is always private
        public int PlaneId { get; set; }
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public PlaneType planetype { get; set; }
        ICollection<Flight> flights { get; set; }

        public override string? ToString()
        {
            return "Capacity : " + Capacity + ", Manufacture Date : " +ManufactureDate + ", Plane type : " +planetype;
        }

        public Plane()
        {
        }

        public Plane(PlaneType planetype , int capacity, DateTime manufactureDate)
        {
            this.planetype = planetype;
            Capacity = capacity;
            ManufactureDate = manufactureDate;
            
        }
    }
}
