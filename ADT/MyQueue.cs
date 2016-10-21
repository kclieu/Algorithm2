using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    //CCI 3.5 Implement a MyQueue class which implements a queue using two stacks.
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyQueue<T>
    {
        Stack<T> stackNewest;
        Stack<T> stackOldest;

        /// <summary>
        /// 
        /// </summary>
        public MyQueue()
        {
            stackNewest = new Stack<T>();
            stackOldest = new Stack<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return stackNewest.Count + stackOldest.Count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        { 
            //Push onto stackNewest, which always has the newest elements on top
            stackNewest.Push(value);
        }

        //Move elements from stackNewest into stackOldest.  This is usually done so that we can do operations on stackOldest
        /// <summary>
        /// 
        /// </summary>
        private void ShiftStacks()
        {
            if (stackOldest.Count == 0)
            {
                while (stackNewest.Count != 0)
                {
                    stackOldest.Push(stackNewest.Pop());
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            ShiftStacks(); //Ensure stackOldest has current elements
            return stackOldest.Peek(); //Retrieve the oldest item 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public T Remove()
        {
            ShiftStacks(); //Ensure stackOldest has the current elements;
            return stackOldest.Pop();  //Pop the oldest item
        }
    }
}
