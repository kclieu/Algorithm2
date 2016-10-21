using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    //http://algs4.cs.princeton.edu/42directed/DepthFirstOrder.java.html

    /**
    The <tt>DepthFirstOrder</tt> class represents a data type for 
    determining depth-first search ordering of the vertices in a digraph
    or edge-weighted digraph, including preorder, postorder, and reverse postorder.
    This implementation uses depth-first search.  The constructor takes time 
    proportional to V + E (in the worst case), where V is the number of 
    vertices and E is the number of edges. Afterwards, the preorder ,postorder, 
    and reverse postorder operation takes take time proportional to V.
    For additional documentation, see <a href="/algs4/42digraph">Section 4.2 of
    Algorithms, 4th Edition</i> by Robert Sedgewick and Kevin Wayne.

    @author Robert Sedgewick
    @author Kevin Wayne
    */
    public class DepthFirstOrder
    {
        private bool[] Marked;  //Marked[v] = has v been marked in dfs
        private int[] Pre;      //prev[v] = preorder number of v
        private int[] Post;     //post[v] = postorder number of v
        private Queue<int> PreOrder;    //vertices in preorder
        private Queue<int> PostOrder;   //vertices in postorder
        private int PreCounter;     //counter for preorder numbering
        private int PostCounter;    //counter for postorder numbering

        public DepthFirstOrder(Digraph G)
        {
            Pre = new int[G.GetVertices()];
            Post = new int[G.GetVertices()];
            PostOrder = new Queue<int>();
            PreOrder = new Queue<int>();
            Marked = new bool[G.GetVertices()];

            for(int v = 0; v < G.GetVertices(); v++)
            {
                if (!Marked[v])
                    DFS(G, v);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="G"></param>
        /// <param name="v"></param>
        private void DFS(Digraph G, int v)
        {
            Marked[v] = true;
            Pre[v] = PreCounter++;
            PreOrder.Enqueue(v);

            foreach (int w in G.GetAdjacents(v))
            {
                if (!Marked[w])
                    DFS(G, w);
            }

            PostOrder.Enqueue(v);
            Post[v] = PostCounter++;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Stack<int> ReversePost()
        {
            Stack<int> reverse = new Stack<int>();

            foreach (int v in PostOrder)
                reverse.Push(v);
            return reverse;
        }
    }
}
