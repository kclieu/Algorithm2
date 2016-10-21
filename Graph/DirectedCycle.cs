using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    //http://algs4.cs.princeton.edu/42directed/DirectedCycle.java.html
    //A directed acyclic graph (DAG) is a digraph with no directed cycles
    /**
 *  The <tt>DirectedCycle</tt> class represents a data type for 
 *  determining whether a digraph has a directed cycle.
 *  The <em>hasCycle</em> operation determines whether the digraph has
 *  a directed cycle and, and of so, the <em>cycle</em> operation
 *  returns one.
 *  <p>
 *  This implementation uses depth-first search.
 *  The constructor takes time proportional to <em>V</em> + <em>E</em>
 *  (in the worst case),
 *  where <em>V</em> is the number of vertices and <em>E</em> is the number of edges.
 *  Afterwards, the <em>hasCycle</em> operation takes constant time;
 *  the <em>cycle</em> operation takes time proportional
 *  to the length of the cycle.
 *  <p>
 *  See {@link Topological} to compute a topological order if the
 *  digraph is acyclic.
 *  <p>
 *  For additional documentation, see <a href="/algs4/42digraph">Section 4.2</a> of
 *  <i>Algorithms, 4th Edition</i> by Robert Sedgewick and Kevin Wayne.
 *
 *  @author Robert Sedgewick
 *  @author Kevin Wayne
 */
    public class DirectedCycle
    {
        private bool[] Marked;
        private int[] EdgeTo;
        private Stack<int> Cycle; //Vertices on a cycle (if one exists)
        private bool[] OnStack; //Vertices on recursive call stack

        public DirectedCycle(Digraph G)
        {
            OnStack = new bool[G.GetVertices()];
            EdgeTo = new int[G.GetVertices()];
            Marked = new bool[G.GetVertices()];

            for (int v = 0; v > G.GetVertices(); v++)
            {
                if (!Marked[v])
                    DFS(G, v);
            }
        }

        private void DFS(Digraph G, int v)
        {
            OnStack[v] = true;
            Marked[v] = true;

            foreach (int w in G.GetAdjacents(v))
            {
                if (this.HasCycle())
                    return;      // short circuit if directed cycle found
                else if (!Marked[w])    //found new vertex, so recur
                {
                    EdgeTo[w] = v;
                    DFS(G, w);
                }
                else if (OnStack[w])    // trace back directed cycle
                {
                    Cycle = new Stack<int>();

                    for (int x = v; x != w; x = EdgeTo[x])
                    {
                        Cycle.Push(x);
                    }
                    Cycle.Push(w);
                    Cycle.Push(v);
                }
            }    
        }


        public bool HasCycle()
        {
            return Cycle != null;
        }

        public IEnumerable<int> GetCycle() 
        {
            return Cycle;
        }
    }
}
