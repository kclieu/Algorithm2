using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    class ProgramStringManip
    {
        static void MainStringMan(string[] args)
        {


            string s = "Madam, I'm Adam";
            Console.WriteLine(string.Format("Reverse {0} => {1}", s, StringManipulations.ReverseString(s)));

            string subStr1 = "madam";
            string subStr2 = "ada";

            Console.WriteLine(string.Format("Is substring {0}, {1} is substring of each other: {2}", subStr1, subStr2, StringManipulations.IsSubstring(subStr2, subStr1)));

            int x = 5, y = 6;
            InplaceSwap.Swap(ref x, ref y);
            Console.WriteLine(string.Format("x = {0}  y = {1}", x, y));


            string s1 = "sssbbbdddeee";
            string s2 = s1.Replace("sss", "eee");
            Console.WriteLine(s2);


            Console.WriteLine(StringManipulations.StringToInt("-1234"));

            Console.WriteLine(StringManipulations.StringToInt2("-1234")); 
            Console.WriteLine(StringManipulations.StringToInt2("1234"));

            Console.WriteLine(StringManipulations.IntToString(54321));
            Console.WriteLine(StringManipulations.IntToString2(-54321));
            Console.Read();
        }
    }
}
