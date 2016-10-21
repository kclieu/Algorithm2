using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    public class Bus:Vehicle
    {
        public Bus()
        {
            spotsNeeded = 5;
            size = VehicleSize.Large;
        }

        public bool canFitInSpot(ParkingSpot spot)
        {
            return spot.getSize() == VehicleSize.Large;
        }

        public void print()
        {
            Console.Write("B");
        }
    }
}
