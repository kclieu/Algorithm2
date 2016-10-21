using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    public class Pair<A, B>//:IComparable
    {
        private A first;
        private B second;

        public Pair(A first, B second)
        {
            this.first = first;
            this.second = second;
        }

        public A GetFirst()
        {
            return first;
        }

        public void SetFirst(A first)
        {
            this.first = first;
        }

        public B GetSecond()
        {
            return second;
        }

        public void SetSecond(B second)
        {
            this.second = second;
        }

        public string ToString()
        {
            return first + " " + second;
        }

        //public int CompareTo(Pair<A,B> )
        //{
        //    //if (obj == null) return 1;

        //    //A other = object as A;
        //    return 1;
        //}


    }
}
