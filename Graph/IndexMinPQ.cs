using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    /**
 *  The <tt>IndexMinPQ</tt> class represents an indexed priority queue of generic keys.
 *  It supports the usual <em>insert</em> and <em>delete-the-minimum</em>
 *  operations, along with <em>delete</em> and <em>change-the-key</em> 
 *  methods. In order to let the client refer to keys on the priority queue,
 *  an integer between 0 and NMAX-1 is associated with each key&mdash;the client
 *  uses this integer to specify which key to delete or change.
 *  It also supports methods for peeking at the minimum key,
 *  testing if the priority queue is empty, and iterating through
 *  the keys.
 *  <p>
 *  This implementation uses a binary heap along with an array to associate
 *  keys with integers in the given range.
 *  The <em>insert</em>, <em>delete-the-minimum</em>, <em>delete</em>,
 *  <em>change-key</em>, <em>decrease-key</em>, and <em>increase-key</em>
 *  operations take logarithmic time.
 *  The <em>is-empty</em>, <em>size</em>, <em>min-index</em>, <em>min-key</em>, and <em>key-of</em>
 *  operations take constant time.
 *  Construction takes time proportional to the specified capacity.
 *  <p>
 *  For additional documentation, see <a href="http://algs4.cs.princeton.edu/24pq">Section 2.4</a> of
 *  <i>Algorithms, 4th Edition</i> by Robert Sedgewick and Kevin Wayne.
 *
 *  @author Robert Sedgewick
 *  @author Kevin Wayne
 */
    /// <summary>
    /// 
    /// </summary>
    //public class IndexMinPQ<T> : IEnumerable<T>
    public class IndexMinPQ<T> 
    {
        private int NMAX; //max number of elements on the PQ
        private int N; //number of elements on PQ
        public int[] pq;    //biary heap using 1-based indexing
        private int[] qp;   //inverse of pq -qp[pq[i]] = pq[q[[i]] = i
        //private T[] keys;   //keys[i] = priority of i
        private double[] keys;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NMAX"></param>
        public IndexMinPQ(int NMAX)
        {
            if (NMAX < 0) throw new Exception("IllegalArgumentException");
            this.NMAX = NMAX;
            //keys = (T[])new Comparer<T>[NMAX + 1];
            keys = new double[NMAX + 1];
            pq = new int[NMAX + 1];
            qp = new int[NMAX + 1];

            for (int i = 0; i <= NMAX; i++) 
                qp[i] = -1;
        }

        /// <summary>
        /// Is the priority queue empty?
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return N == 0;
        }

        /// <summary>
        //  Is i an index on the priority queue?
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public bool Contains(int i)
        {
            if (i < 0 || i >= NMAX) throw new IndexOutOfRangeException();
            return qp[i] != -1;
        }

        /// <summary>
        ///  Returns the number of keys on the priority queue.
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return N;
        }

        /// <summary>
        /// ssociates key with index i.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="key"></param>
        public void Insert(int i, double key)
        {
            if (i < 0 || i >= NMAX) throw new IndexOutOfRangeException();
            if (Contains(i)) throw new ArgumentException("index is already in the priority queue");
            qp[i] = N;
            pq[N] = i;
            keys[i] = key;
            Swim(N);
        }

        /// <summary>
        /// Returns an index associated with a minimum key.
        /// </summary>
        /// <returns></returns>
        public int MinIndex()
        {
            if (N == 0) throw new Exception("Priority queue underflow");
            return pq[1];
        }

        /// <summary>
        /// Returns a minimum key.
        /// </summary>
        /// <returns></returns>
        public double MinKey()
        {
            if (N == 0) throw new Exception("Priority queue underflow");
            return keys[pq[1]];
        }

        /// <summary>
        /// Removes a minimum key and returns its associated index.
        /// </summary>
        /// <returns></returns>
        public int DelMin()
        {
            if(N == 0) throw new Exception("Priority queue underflow");
            int min = pq[1];
            Exchange(1, N--);
            Sink(1);
            qp[min] = -1; //Delete
            keys[pq[N + 1]] = -1; //to help with garbage collection
            pq[N + 1] = -1;
            return min;
       }

        /// <summary>
        /// Returns the key associated with index i.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public double KeyOf(int i)
        {
            if (i < 0 || i >= NMAX) throw new IndexOutOfRangeException();
            if (!Contains(i)) throw new Exception("index is not in the priority queue");
            else return keys[i];
        }

        /// <summary>
        /// Decrease the key associated with index i to the specified value.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="key"></param>
        public void DecreaseKey(int i, double key)
        {
            if (i < 0 || i >= NMAX) throw new IndexOutOfRangeException();
            if (!Contains(i)) throw new Exception("index is not in the priority queue");
            //if (keys[i] <= 0) throw new Exception("Calling decreaseKey() with given argument would not strictly decrease the key");
            if (keys[i] <= key) throw new Exception("Calling decreaseKey() with given argument would not strictly decrease the key");
            keys[i] = key;
            Swim(qp[i]);
        }

        /// <summary>
        /// Decrease the key associated with index i to the specified value.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="key"></param>
        public void IncreaseKey(int i, double key)
        {
            if (i < 0 || i >= NMAX) throw new IndexOutOfRangeException();
            if (!Contains(i)) throw new Exception("index is not in the priority queue");
            if (keys[i] >= key) throw new Exception("Calling decreaseKey() with given argument would not strictly decrease the key");
            keys[i] = key;
            Sink(qp[i]);
        }

        /// <summary>
        /// Remove the key associated with index i.
        /// </summary>
        /// <param name="i"></param>
        public void Delete(int i)
        {
            if (i < 0 || i >= NMAX) throw new IndexOutOfRangeException();
            if (!Contains(i)) throw new Exception("index is not in the priority queue");
            int index = qp[i];
            Exchange(index, N--);
            Swim(index);
            Sink(index);
            keys[i] = -1;
            qp[i] = -1;
        }

        /**************************************************************
        * General helper functions
        **************************************************************/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        private bool Greater(int i, int j)
        {
            return keys[pq[i]] > keys[pq[j]];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private void Exchange(int i, int j)
        {
            int swap = pq[i]; pq[i] = pq[j]; pq[j] = swap;
            qp[pq[i]] = i; qp[pq[j]] = j;
        }

        /**************************************************************
        * Heap helper functions
        **************************************************************/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="k"></param>
        private void Swim(int k)
        {
            while (k > 1 && Greater(k / 2, k))
            {
                Exchange(k, k / 2);
                k = k / 2;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="k"></param>
        private void Sink(int k)
        {
            while (2 * k <= N)
            {
                int j = 2 * k;
                if (j < N && Greater(j, j + 1)) j++;
                if (!Greater(k, j)) break;
                Exchange(k, j);
                k = j;
            }
        }
    }
}
