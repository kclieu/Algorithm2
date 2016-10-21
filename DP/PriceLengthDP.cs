using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos.DP
{
    //To see this problem let's consider the rod cutting problem in Cormen et al. A company buys long steel rods and cuts them into shorter rods which it sells. How should the company cut up the rods to maximize revenues.
    //We know for i=1,2,...., the price pi that the company charges for a rod of length i inches. This (sample) table gives the price for each rod length.
    //length i	1	2	3	4	5	6	7	8	9	10
    //price pi	1	5	8	9	10	17	17	20	24	30

    public static class PriceLengthDP
    {
        public static double CutRod(double[] p, int n)
        {
            double q = 0;
            if (n == 0)
                return 0;
            q = double.MinValue;

            for (int i = 1; i <= n; i++)
            {
                q = Math.Max(q, p[i] + CutRod(p, n - i));
            }

            return q;
        }

        ////////////////////////////////////////////////////////
        public static double MemoizedCutRod(double[] p, int n)
        {
            /*
            * Initialize a new auxiliary array whose value are double.MinValue.
            * This will be used to store solutions to the subproblems.
            * */

            double[] r = new double[n + 1];
            
            for (int i = 0; i <= n; i++)
            {
                r[i] = double.MinValue;
            }

            return MemoizedCutRodAux(p, n, r);
        
        }

        public static double MemoizedCutRodAux(double[] p, int n, double[] r)
        {
            double q = 0;
            /*
            * r[] is the auxiliary array which stores the solutions to the subproblems
            * First check it to see if we have already solved this problem.
             * */

            if (r[n] >= 0)
                return r[n];
            if (n == 0)
            {    
                q = 0;
            }
            else 
            {
                q = double.MinValue;
                for (int i = 1; i <= n; i++)
                {
                    q = Math.Max(q, MemoizedCutRodAux(p, n - i, r));
                }
            }

            r[n] = q;
            return q;
        }
        //////////////////////////////////////////////////////////////////////////


    }
}
