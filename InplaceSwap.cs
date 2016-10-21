using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    //0-------------x---------y
    public static class InplaceSwap
    {
        public static void Swap(ref int x, ref int y)
        {
            x = x + y;
            y = x - y;
            x = x - y;

            //Console.WriteLine(string.Format("x = {0}, y = {0}", x, y));
        }
    }
}
