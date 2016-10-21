using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    public class Motorcycle:Vehicle
    {
        public Motorcycle() {
            spotsNeeded = 1;
            size = VehicleSize.Motorcycle;
        }

        public bool canFitInSpot(ParkingSpot spot)
        {
            return true;
        }

        public void print()
        {
            Console.Write("M");
        }
    }
}
