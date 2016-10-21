using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    //http://algs4.cs.princeton.edu/41undirected/DepthFirstPaths.java.html
    /**
     *  The <tt>DepthFirstPaths</tt> class represents a data type for finding
     *  paths from a source vertex <em>s</em> to every other vertex
     *  in an undirected graph.
     *  <p>
     *  This implementation uses depth-first search.
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
    
    public class DepthFirstPaths
    {
        private bool[] Marked;
        private int[] EdgeTo; //Last vertex on known path to this vertex
        private int Source;  //Source



        //Note for DiGraph -> Exactly the same, Digraph instead of Graph
        //http://algs4.cs.princeton.edu/42directed/DepthFirstDirectedPaths.java.html

        /// <summary>
        /// 
        /// </summary>
        /// <param name="G"></param>
        /// <param name="s"></param>
        public DepthFirstPaths(Graph G, int s)
        {
            Marked = new bool[G.GetVertices()];
            EdgeTo = new int[G.GetVertices()];
            Source = s;
            DFS(G, s);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="G"></param>
        /// <param name="v"></param>
        private void DFS(Graph G, int v)
        {
            Marked[v] = true;

            foreach (int w in G.GetAdjacents(v))
            {
                if (!Marked[w])
                {
                    EdgeTo[w] = v;
                    DFS(G, w);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public bool HasPathTo(int v)
        {
            return Marked[v];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public IEnumerable<int>  PathTo(int v)
        {
            if (!HasPathTo(v))
                return null;

            Stack<int> path = new Stack<int>();
            
            for(int i = v; i != Source; i = EdgeTo[i])
            {
                path.Push(i);
            }
            path.Push(Source);

            return path;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void MainDepthFirstPaths(string[] args)
        {
            Graph G = new Graph(10);

            int s = 10;
            DepthFirstPaths dfs = new DepthFirstPaths(G, s);

            for (int v = 0; v < G.GetVertices(); v++)
            {
                if (dfs.HasPathTo(v))
                {
                    Console.Write(string.Format("{0} to {1}:  ", s, v));

                    foreach (int x in dfs.PathTo(v))
                    {
                        if (x == s) Console.Write(x);
                        else Console.Write("-" + x);
                    }

                    Console.WriteLine();
                }
                else
                { 
                   Console.Write(string.Format("{0} to {1}: not connected\n ", s, v));
                }
            }
        }
    }
}
