using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    //http://algs4.cs.princeton.edu/41undirected/BreadthFirstPaths.java.html
    //Breadth-first search to find paths in a graph
    //This Graph client uses breadth-first search to find paths in a
    //undirected graph with the fewest number of edgesfrom the source s given 
    //in the constructor. The bfs() method marks all vertices connected to s, so
    //clients can use hasPathTo() to determine whether a given vertex v is 
    //connected to s and pathTo() to get a path from s to v with the property 
    //that no other such path from s to v has fewer edges.

    //Note for DiGraph -> Exactly the same, just use Digraph instead
    
    /*The constructor takes time proportional to <em>V</em> + <em>E</em>,
     *  where <em>V</em> is the number of vertices and <em>E</em> is the number of edges.
     *  It uses extra space (not including the graph) proportional to <em>V</em>.
     *  For additional documentation, see <a href="/algs4/41graph">Section 4.1</a> of
     *  <i>Algorithms, 4th Edition</i> by Robert Sedgewick and Kevin Wayne.*/

    public class BreadthFirstPaths
    {
        private bool[] Marked; //Is a shortest path to this vertex known?
        private int[] EdgeTo;   //EdgeTo[v] = Previous edge on shortest s-v path
        private int[] DistanceTo; //DistanceTo[v] = number of edge i.e shortest s-v path

        //Note for DiGraph -> Exactly the same, just use Digraph instead
        //http://algs4.cs.princeton.edu/42directed/BreadthFirstDirectedPaths.java.html

        /// <summary>
        /// 
        /// </summary>
        /// <param name="G"></param>
        /// <param name="s"></param>
        public BreadthFirstPaths(Graph G, int s)
        {
            Marked = new bool[G.GetVertices()];
            EdgeTo = new int[G.GetVertices()];
            DistanceTo = new int[G.GetVertices()];
            //Source = s;
            BFS(G, s);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="G"></param>
        /// <param name="s"></param>
        private void BFS(Graph G, int s)
        {
            Queue<int> queue = new Queue<int>();
            Marked[s] = true;   //Mark the source
            queue.Enqueue(s);   //and put it on the queue

            while (queue.Count != 0)
            {
                int v = queue.Dequeue();    //Remove next vertex from the queue

                foreach (int w in G.GetAdjacents(v))
                {
                    if (!Marked[w])     //For every unmarked adjacent vertex
                    {
                        EdgeTo[w] = v;  //Save last edge on a shortest path
                        DistanceTo[w] = DistanceTo[v] + 1;
                        Marked[w] = true;   //Mark it because path is known
                        queue.Enqueue(w);   //and add it to the queue
                    }
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
        public int GetDistanceTo(int v)
        {
            return DistanceTo[v];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public IEnumerable<int> PathTo(int v)
        {
            if (!HasPathTo(v))
                return null;

            Stack<int> path = new Stack<int>();

            int x;
            for (x = v; DistanceTo[x] != 0 ; x = EdgeTo[x])
            {
                path.Push(x);
            }
            path.Push(x);

            return path;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void MainBreadthFirstPaths(string[] args)
        {
            Graph G = new Graph(10);

            int s = 10;
            BreadthFirstPaths bfs = new BreadthFirstPaths(G, s);

            for (int v = 0; v < G.GetVertices(); v++)
            {
                if (bfs.HasPathTo(v))
                {
                    Console.Write(string.Format("{0} to {1}:  ", s, v));

                    foreach (int x in bfs.PathTo(v))
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
