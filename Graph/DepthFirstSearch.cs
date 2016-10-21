using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    //http://algs4.cs.princeton.edu/41undirected/DepthFirstSearch.java.html

    public class DepthFirstSearch
    {
        private bool[] Marked;
        private int Count;

        public DepthFirstSearch(Graph G, int source)
        {
            Marked = new bool[G.GetVertices()];
            DFS(G, source);
        }

        /// <summary>
        /// The recursive method marks the given vertex and calls itself for any unmarked vertices
        /// on it's adjacency list.  If the graph is connnected, every adjacency-list entry is checked.
        /// </summary>
        /// <param name="G"></param>
        /// <param name="v"></param>
        private void DFS(Graph G, int s)
        {
            Marked[s] = true;
            Count++;

            foreach(int w in G.GetAdjacents(s))
            {
                if(!Marked[w])
                    DFS(G,w);
            }
        }

        //http://algs4.cs.princeton.edu/41undirected/NonrecursiveDFS.java.html

        /**
         *  The <tt>NonrecursiveDFS</tt> class represents a data type for finding
         *  the vertices connected to a source vertex <em>s</em> in the undirected
         *  graph.
         *  <p>
         *  This implementation uses a nonrecursive version of depth-first search
         *  with an explicit stack.
         *  The constructor takes time proportional to <em>V</em> + <em>E</em>,
         *  where <em>V</em> is the number of vertices and <em>E</em> is the number of edges.
         *  It uses extra space (not including the graph) proportional to <em>V</em>.
         *  <p>
         *  For additional documentation, see <a href="/algs4/41graph">Section 4.1</a> of
         *  <i>Algorithms, 4th Edition</i> by Robert Sedgewick and Kevin Wayne.
         *
         *  @author Robert Sedgewick
         *  @author Kevin Wayne
         */
        private void NonRecursiveDFS(Graph G, int s)
        {
            //To be able to iterate over each adjacency list, keeping track of
            //which vertex in each adjency list needs to be explored next
            List<int>[] adjacents = (List<int>[])new List<int>[G.GetVertices()];

            for (int v = 0; v < G.GetVertices(); v++)
            {
                adjacents[v] = G.GetAdjacents(v);
            }

            //depth-first search using an explicit stack
            Marked[s] = true;
            Stack<int> stack = new Stack<int>();
            stack.Push(s);

            while (stack.Count > 0)
            {
                int v = stack.Peek();

                //IEnumerator<int> t = adjacents[v].GetEnumerator();
                IEnumerator<int> ie = adjacents[v].GetEnumerator();
                bool moveNext = ie.MoveNext();
                if (moveNext)
                {
                    int w = ie.Current;
                    if (!Marked[w])
                    {
                        //discovered vertex w for the first time
                        Marked[w] = true;
                        stack.Push(w);
                    }
                }
                else
                {
                    //v's adjacency list is exhausted
                    stack.Pop();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="w"></param>
        /// <returns></returns>
        public bool IsMarked(int w)
        {
            return Marked[w];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            return Count;
        }

        public static void MainDFS(string[] args)
        {
            Graph G = new Graph(100);
            DepthFirstSearch dfs = new DepthFirstSearch(G, 10);

            for (int v = 0; v < G.GetVertices(); v++)
            {
                if (dfs.IsMarked(v))
                    Console.Write(v + " ");
            }

            Console.WriteLine();

            if (dfs.GetCount() != G.GetVertices())
                Console.WriteLine("NOT connected");
            else Console.WriteLine("connected");


            //How to find number of self-loops && degree of a vertex
            //http://algs4.cs.princeton.edu/41undirected/GraphClient.java.html


            //Find if graph is bipartite
            //Find if graph has cycles
            
        }
    }
}
