using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    //CCI 3.4
    public class TowerOfHanoi
    {
        private Stack<int> disks;
        private int index;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        public TowerOfHanoi(int i)
        {
            disks = new Stack<int>();
            index = i;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Index()
        {
            return index;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        public void Add(int d)
        {
            if (disks.Count != 0 && disks.Peek() >= d)
            {
                Console.WriteLine("Error placing disk " + d);
            }
            else
                disks.Push(d);
        }

        public void MoveTopTo(TowerOfHanoi t)
        {
            int top = disks.Pop();
            t.Add(top);

            Console.WriteLine("Move disk " + top + " from " + Index() + " to " + t.Index());
        }

        public void MoveDisks(int n, TowerOfHanoi destination, TowerOfHanoi buffer)
        {
            if (n > 0)
            {
                MoveDisks(n - 1, buffer, destination);
                MoveTopTo(destination);
                buffer.MoveDisks(n - 1, destination, this);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class TowerOfHanoiClass
    {
        static void MainTOH(string[] args)
        {
            int n = 3;

            TowerOfHanoi[] towers = new TowerOfHanoi[n];

            for (int i = 0; i < 3; i++)
            {
                towers[i] = new TowerOfHanoi(i);
            }

            for (int i = n - 1; n >= 0; i--)
            {
                towers[0].Add(i);
            }

            towers[0].MoveDisks(n, towers[2], towers[1]);
        }
    }
}
