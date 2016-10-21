using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    public class MultiplicationTable
    {
        private int Target;

        public MultiplicationTable(int target)
        { 
            this.Target = target;
        }

        /// <summary>
        /// 
        /// </summary>
        public void DoMultiplication()
        {
            int[,] table = new int[Target+1, Target+1];

            for (int i = 1; i <= Target; i++)
            {
                for (int j = 1; j <= Target; j++)
                { 
                    table[i,j] = i*j;
                
                }
            }

            PrintTable(table);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        private void PrintTable(int[,] table)
        {
            for (int i = 1; i <= Target; i++)
            {
                for (int j = 1; j <= Target; j++)
                {
                    Console.Write(String.Format("  {0}", table[i, j]));
                }

                Console.WriteLine();
            }
        }
    }
}
