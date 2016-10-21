using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    //CCI 3.3
    /*Imagine a (literal) stack of plates. If the stack gets too high, it migh t topple. Therefore,
    in real life, we would likely start a new stack when the previous stack exceeds some
    threshold. Implement a data structure SetOfStacks that mimics this. SetOf-
    Stacks should be composed of several stacks and should create a new stack once
    the previous one exceeds capacity. SetOfStacks.push() and SetOfStacks.
    pop () should behave identically to a single stack (that is, pop () should return the
    same values as it would if there were just a single stack).

     FOLLOW UP
    Implement a function popAt(int index) which performs a pop operation on a
    specific sub-stack.*/
    
    /// <summary>
    /// 
    /// </summary>
    public class SetOfStacks
    {
        List<Stack<int>> stacks = new List<Stack<int>>();
        public int capacity;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="capacity"></param>
        public SetOfStacks(int capacity)
        {
            this.capacity = capacity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        public void Push(int v)
        {
            Stack<int> last = GetLastStack();

            if (last != null && last.Count != capacity)  //Size of stack set at 10 max
            {
                last.Push(v);
            }
            else //must create a new stack
            {
                Stack<int> stack = new Stack<int>(capacity);
                stack.Push(v);
                stacks.Add(stack);
            }
        }

        public int Pop()
        {
            Stack<int> last = GetLastStack();
            int v = last.Pop();

            if (last.Count == 0) stacks.RemoveAt(stacks.Count - 1);
            return v;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Stack<int> GetLastStack()
        {
            if(stacks.Capacity == 0)
                return null;

            return stacks[stacks.Capacity -1];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            Stack<int> last = GetLastStack();
            return last == null || last.Count == 0;
        }

        public int PopAt(int index)
        {
            return LeftShift(index, true);
        }

        public int LeftShift(int index, bool removeTop)
        {
            Stack<int> stack = stacks[index];

            int removed_item;

            if (removeTop)
                removed_item = stack.Pop();
            else
                removed_item = -1;
                //removed_item = stack.RemoveBottom();

            if (stack.Count == 0)
                stacks.RemoveAt(index);
            else if(stacks.Count > index + 1)
            {
                int v = LeftShift(index + 1, false);
                stack.Push(v);
            }

            return removed_item;
        }
    }
}
