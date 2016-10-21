using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    //http://algs4.cs.princeton.edu/44sp/DijkstraSP.java.html
    /**
     *  The <tt>DijkstraSP</tt> class represents a data type for solving the
     *  single-source shortest paths problem in edge-weighted digraphs
     *  where the edge weights are nonnegative.
     *  <p>
     *  This implementation uses Dijkstra's algorithm with a binary heap.
    *  The constructor takes time proportional to <em>E</em> log <em>V</em>,
    *  where <em>V</em> is the number of vertices and <em>E</em> is the number of edges.
    *  Afterwards, the <tt>distTo()</tt> and <tt>hasPathTo()</tt> methods take
    *  constant time and the <tt>pathTo()</tt> method takes time proportional to the
    *  number of edges in the shortest path returned.
    *  <p>
    *  For additional documentation, see <a href="/algs4/44sp">Section 4.4</a> of
    *  <i>Algorithms, 4th Edition</i> by Robert Sedgewick and Kevin Wayne.
    *
    *  @author Robert Sedgewick
    *  @author Kevin Wayne
    */
    public class DijkstraSP
    {
        private double[] DistTo;
        private DirectedEdge[] EdgeTo;
        private IndexMinPQ<double> pq;

        public DijkstraSP(EdgeWeightedDiagraph G, int s)
        {
            foreach (DirectedEdge e in G.GetDirectedEdges())
            {
                if (e.Weight() < 0)
                    throw new ArgumentException("edge " + e + " has negative weight");
            }

            DistTo = new double[G.GetVertices()];
            EdgeTo = new DirectedEdge[G.GetVertices()];

            for (int v = 0; v < G.GetVertices(); v++)
            {
                DistTo[v] = Double.PositiveInfinity;
            }
            DistTo[s] = 0.0;

            //relax vertices in order of distance from s
            pq = new IndexMinPQ<double>(G.GetVertices());
            pq.Insert(s, DistTo[s]);

            while (!pq.IsEmpty())
            {
                int v = pq.DelMin();
                foreach (DirectedEdge e in G.GetAdjacents(v))
                    Relax(e);
            }

            System.Diagnostics.Debug.Assert(Check(G,s));
        }

        /// <summary>
        ///Relax edge e and update pq if changed 
        /// </summary>
        /// <param name="e"></param>
        private void Relax(DirectedEdge e)
        {
            int v = e.From();
            int w = e.To();

            if (DistTo[w] > DistTo[v] + e.Weight())
            {
                DistTo[w] = DistTo[v] + e.Weight();
                EdgeTo[w] = e;

                if (pq.Contains(w))
                    pq.DecreaseKey(w, DistTo[w]);
                else
                    pq.Insert(w, DistTo[w]);
            }
        }

        /// <summary>
        /// Returns the length of a shortest path from the source vertex s to vertex v
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public double GetDistTo(int v)
        {
            return DistTo[v];
        }

        /// <summary>
        /// Is there a path from the source vertex s to vertex t
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public bool HasPathTo(int v)
        {
            return DistTo[v] < Double.PositiveInfinity;
        }

        /// <summary>
        /// Returns a shortest path from the source vertex s to vertex v.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public IEnumerable<DirectedEdge> PathTo(int v)
        {
            if (!HasPathTo(v)) return null;
            Stack<DirectedEdge> path = new Stack<DirectedEdge>();

            for (DirectedEdge e = EdgeTo[v]; e != null; e = EdgeTo[e.From()])
            {
                path.Push(e);
            }
            return path;
        }

        private bool Check(EdgeWeightedDiagraph G, int s)
        {
            //Check that edge weights are nonnegative
            foreach (DirectedEdge e in G.GetDirectedEdges())
            {
                if (e.Weight() < 0)
                {
                    Console.Error.WriteLine("Negative edge weight detected");
                    return false;
                }
            }

            // check that distTo[v] and edgeTo[v] are consistent
            if (DistTo[s] != 0.0 || EdgeTo[s] != null)
            {
                Console.Error.WriteLine("DistTo[s] and EdgeTo[s] inconsistent");
                return false;
            }

            for(int v = 0; v < G.GetVertices(); v++)
            {
                if (s == v) continue;

                if (EdgeTo[v] == null && DistTo[v] != Double.PositiveInfinity)
                {
                    Console.Error.WriteLine("DistTo[] and EdgeTo[] inconsistent");
                    return false;
                }
            }

            // check that all edges e = v->w on SPT satisfy distTo[w] == distTo[v] + e.weight()
            for (int w = 0; w < G.GetVertices(); w++)
            {
                if (EdgeTo[w] == null) continue;
                DirectedEdge e = EdgeTo[w];
                int v = e.From();

                if (w != e.From()) return false;

                if (DistTo[v] + e.Weight() != DistTo[w])
                {
                    Console.Error.WriteLine("edge " + e + " on shortest path no tight");
                    return false;
                }
            }

            return true;
        }

        public static void MainDijstra(string[] args)
        {
            //string file = @"C:\Users\Ken\Documents\Visual Studio 2013\Algos\StandfordDA1\Data\Programming Q5\tinyEWD.txt";
            string file = @"C:\Users\Ken\Documents\Visual Studio 2013\Algos\StandfordDA1\Data\Programming Q5\dijkstraData.txt";
            //string file = @"C:\Users\Ken\Documents\Visual Studio 2013\Algos\StandfordDA1\Data\Programming Q5\mediumEWD.txt";
            StreamReader sr = File.OpenText(file);
            //EdgeWeightedDiagraph G = new EdgeWeightedDiagraph(sr, 8, 15);
            EdgeWeightedDiagraph G = new EdgeWeightedDiagraph(sr,200);
            //EdgeWeightedDiagraph G = new EdgeWeightedDiagraph(sr, 250, 2546);
            int s = 37;
            DijkstraSP sp = new DijkstraSP(G, s);

            for (int t = 0; t < G.GetVertices(); t++)
            { 
                if(sp.HasPathTo(t))
                {
                    Console.WriteLine(string.Format("{0} to {1} ({2})", s, t, sp.GetDistTo(t)));

                    foreach (DirectedEdge e in sp.PathTo(t))
                    {
                        Console.WriteLine(e + " ");
                    }
                }
            }

            Console.Read();
        }

        public static List<int>[] ParseFile(string path)
        {
            StreamReader reader = File.OpenText(path);
            string line;

            //int nodes = 875714;
            //int nodes = 875715;
            int nodes = 12;
            //int nodes = 21;

            //This one gives wrong answer since number of nodes is derived on counting number of lines in test file
            List<int>[] graph = new List<int>[nodes];



            for (int i = 1; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
            }

            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int node = int.Parse(data[0]);
                int edge = int.Parse(data[1]);
                double weight = double.Parse(data[2]);

                graph[node].Add(edge);
            }

            return graph;
        }
    }
}
