using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    public static class PowerSet
    {
        public static List<string> GetPowerSet(string input)
        {
            int n = input.Length;
            int powerSetCount = 1 << n; // 1* 2en
            var ans = new List<string>();

            for (int setMask = 0; setMask < powerSetCount; setMask++)
            { 
                var s = new StringBuilder();

                for(int i = 0; i < n; i++)
                {
                    if ((setMask & (1 << i)) > 0)     //the value of setMask must have a 1 in the position i  to be positive 
                        s.Append(input[i]);            //num &
                }

                ans.Add(s.ToString());
            }

            return ans;
        }


        //boolean getBit(int num, int i)
        //{
        //  return ((num & ( 1 << i)) != 0);           // Note: 1 << i => 00010000
        //}
    }
}
