using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    //CCI 3.2
    //How would you design a stack which, in addition to push and pop, also has a
    //function min which returns the minimum element? Push, pop and min should all
    //operate in 0(1) time.
    
    /// <summary>
    /// 
    /// </summary>
    public class StackWithMin:Stack<int>
    {
        Stack<int> s2;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public void Push(int val)
        {
            if (val <= GetMin())
            {
                s2.Push(val);
            }
            base.Push(val);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Pop()
        {
            int val = base.Pop();

            if (val == GetMin())
            {
                s2.Pop();
            }
            return val;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetMin()
        {
            if (this.Count == 0)
            {
                return Int32.MaxValue; //Error value
            }
            else
            {
                return s2.Peek();
            }
        }
    }
}
