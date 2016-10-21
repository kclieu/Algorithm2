using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    //CCI 3.6
    //Write a program to sort a stack in ascending order (with biggest items on top).
    //You may use at most one additional stack to hold items, but you may not copy the
    //elements into any other data structure (such as an array). The stack supports the
    //following operations: push, pop, peek, and isEmpty.
    public class SortedStack
    {
        Stack<int> stack = new Stack<int>();
        Stack<int> tempStack = new Stack<int>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public void Push(int val)
        { 
            while(stack.Peek() > val)
            {
                tempStack.Push(stack.Pop());
            }

            stack.Push(val);

            while (tempStack.Count > 0)
            {
                stack.Push(tempStack.Pop());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Pop()
        {
            return stack.Pop();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Peek()
        {
            return stack.Peek();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return stack.Count == 0;
        }
    }
}
