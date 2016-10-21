using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    //http://algs4.cs.princeton.edu/41undirected/Graph.java.html
    /**
     *  The <tt>Graph</tt> class represents an undirected graph of vertices
     *  named 0 through <em>V</em> - 1.
     *  It supports the following two primary operations: add an edge to the graph,
     *  iterate over all of the vertices adjacent to a vertex. It also provides
     *  methods for returning the number of vertices <em>V</em> and the number
     *  of edges <em>E</em>. Parallel edges and self-loops are permitted.
     *  <p>
     *  This implementation uses an adjacency-lists representation, which 
     *  is a vertex-indexed array of {@link Bag} objects.
     *  All operations take constant time (in the worst case) except
     *  iterating over the vertices adjacent to a given vertex, which takes
     *  time proportional to the number of such vertices.
     *  <p>
     *  For additional documentation, see <a href="http://algs4.cs.princeton.edu/41undirected">Section 4.1</a> of
     *  <i>Algorithms, 4th Edition</i> by Robert Sedgewick and Kevin Wayne.
     *
     *  @author Robert Sedgewick
     *  @author Kevin Wayne
     */
    public class Graph
    {
        //http://algs4.cs.princeton.edu/41undirected/BreadthFirstPaths.java.html  Non-recursive BFS

        private int Vertices;
        private int Edges;
        private List<int>[] Adjacents;

        public Graph(int v)
        {
            this.Vertices = v;
            this.Edges = 0;
            this.Adjacents = (List<int>[])new List<int>[v];

            for (int i = 0; i < v; i++)
            {
                Adjacents[i] = new List<int>();
            }
        }

        public int GetVertices()
        {
            return Vertices;
        }

        public int GetEdges()
        {
            return Edges;
        }

        private void ValidateVertex(int v)
        {
            if (v < 0 || v >= Vertices)
                throw new IndexOutOfRangeException("Vertex " + v + " is not between 0 and " + (Vertices - 1));
        }

        public void AddEdge(int v, int w)
        {
            ValidateVertex(v);
            ValidateVertex(w);

            Adjacents[v].Add(w);
            Adjacents[w].Add(v);
            Edges++;
        }

        /// <summary>
        /// When an edge connects 2 verices, we say that the vertices are adjacent to one another and
        /// that the edge is incident on both vertices
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public List<int> GetAdjacents(int v)
        {
            ValidateVertex(v);
            return Adjacents[v];
        }

        /// <summary>
        /// The degree of a vertex is the number of edges incident on it
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public int Degree(int v)
        {
            ValidateVertex(v);
            return Adjacents[v].Capacity;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string NEWLINE = "\n";

            sb.Append(Vertices + " vertices, " + Edges + " edges " + NEWLINE);

            for (int v = 0; v < Vertices; v++)
            {
                sb.Append(string.Format("{0}", v));

                foreach (int w in Adjacents[v])
                {
                    sb.Append(string.Format("{0}", w));
                }

                sb.Append(NEWLINE);
            }

            return sb.ToString();
        }


    }
}
