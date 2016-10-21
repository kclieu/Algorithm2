using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    public class ParkingLot
    {
        private Level[] levels;
        private const int NUM_LEVELS = 5;

        public ParkingLot()
        {
            levels = new Level[NUM_LEVELS];
            
            for (int i = 0; i < NUM_LEVELS; i++)
            {
                levels[i] = new Level(i, 30);
            }
        }

        public bool parkVehicle(Vehicle vehicle)
        {
            //for (int i = 0; i < levels.Length; i++)
            //{ 
            //    if(levels[i].parkVe)
            //}
        }
    }
}
