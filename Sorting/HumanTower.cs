
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    public static class HumanTower
    {
        public class HW
        {
            public double Height;
            public double Weight;
        }

        public static int Compute(List<HW> hws)
        { 

            int count = 0;
            for(int i = 0; i < hws.Count; i++)
            {
               for(int j = i+1; j < hws.Count -1; j++)
               {
                   if ((hws[j].Weight > hws[i].Weight) && (hws[j].Height > hws[i].Height))
                   {
                       HW temp = new HW { Height = hws[j].Height, Weight = hws[j].Weight };

                       hws[j].Weight = hws[i].Weight;
                       hws[j].Height = hws[i].Height;

                       hws[i].Weight = temp.Weight;
                       hws[i].Height = temp.Height;
                   }
               }
                
            }

            return count;
        }
    }
}
