using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    //http://algs4.cs.princeton.edu/44sp/EdgeWeightedDigraph.java.html
    /**
    The <tt>EdgeWeightedDigraph</tt> class represents a edge-weighted
    digraph of vertices named 0 through V - 1, where each
    directed edge is of type {@link DirectedEdge} and has a real-valued weight.
    It supports the following two primary operations: add a directed edge
    to the digraph and iterate over all of edges incident from a given vertex.
    It also provides methods for returning the number of vertices <em>V</em> 
    and the number of edges E. Parallel edges and self-loops are permitted.
    This implementation uses an adjacency-lists representation, which 
    is a vertex-indexed array of @link{Bag} objects. All operations take 
    constant time (in the worst case) except iterating over the edges incident 
    from a given vertex, which takes time proportional to the number of such edges.
    For additional documentation, see <a href="http://algs4.cs.princeton.edu/44sp">
    Section 4.4 of Algorithms, 4th Edition</i> by Robert Sedgewick and Kevin Wayne.

    @author Robert Sedgewick
    @author Kevin Wayne
    */
    public class EdgeWeightedDiagraph
    {
        private int Vertices;
        private int Edges;
        private List<DirectedEdge>[] Adjacents;

        /// <summary>
        /// Initializes an empty edge-weighted digraph with <tt>V</tt> vertices and 0 edges.
        /// </summary>
        /// <param name="v">number of vertices</param>
        public EdgeWeightedDiagraph(int V)
        {
            if (V < 0) throw new Exception("Number of vertices in diagraph must be nonegative");
            Vertices = V;
            Edges = 0;
            //Adjacents = (List<DirectedEdge>[]) new List<DirectedEdge>[V];
            Adjacents = (List<DirectedEdge>[])new List<DirectedEdge>[V+1];
            //for (int v = 0; v < V; v++)
            for (int v = 0; v <= V; v++)
            {
                Adjacents[v] = new List<DirectedEdge>();
            }
        }

        /// <summary>
        /// Initializes a random edge-weighted digraph with <tt>V</tt> vertices and <em>E</em> edges.
        /// </summary>
        /// <param name="V">number of vertices</param>
        /// <param name="E">number of edges</param>
        public EdgeWeightedDiagraph(int V, int E)
        {
            Vertices = V;
            if (E < 0) throw new Exception("Number of edges in a Diagraph must be nonnegative");
            for(int i = 0; i < E; i++ )
            {
                
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="vertices"></param>
        /// <param name="edges"></param>
        public EdgeWeightedDiagraph(StreamReader reader, int vertices, int edges):this(vertices)
        {
            string line;
            Edges = edges;

            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int v = int.Parse(data[0]);
                int e = int.Parse(data[1]);
                double weight = double.Parse(data[2]);

                AddEdge(new DirectedEdge(v, e, weight));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="vertices"></param>
        public EdgeWeightedDiagraph(StreamReader reader, int vertices):this(vertices)
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                int v = int.Parse(data[0]);
                //Vertices++;

                string edgeData = data[1];
                string[] edgeStr = edgeData.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);



                int e = int.Parse(edgeStr[0]);
                double weight = double.Parse(edgeStr[1]);

                AddEdge(new DirectedEdge(v, e, weight));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetVertices()
        {
            return Vertices;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetEdges()
        {
            return Edges;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        private void ValidateVertex(int v)
        {
            //if (v < 0 || v >= Vertices)
            //    throw new IndexOutOfRangeException("Vertex " + v + " is not between 0 and " + (Vertices - 1));
            //if (v < 0 || v > Vertices)
                //throw new IndexOutOfRangeException("Vertex " + v + " is not between 0 and " + (Vertices));
        }

        /// <summary>
        /// Adds the directed edge e to the edge-weighted digraph.
        /// </summary>
        /// <param name="e"></param>
        public void AddEdge(DirectedEdge e)
        {
            int v = e.From();
            int w = e.To();
            ValidateVertex(v);
            ValidateVertex(w);
            Adjacents[v].Add(e);
            Edges++;
        }

        /// <summary>
        /// Returns the number of directed edges incident from vertex
        /// This is known as the <em>outdegree</em> of vertex
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public int OutDegree(int v)
        {
            ValidateVertex(v);
            return Adjacents[v].Count;
        }

        /// <summary>
        /// Returns the directed edges incident from vertex 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public IEnumerable<DirectedEdge> GetAdjacents(int v)
        {
            ValidateVertex(v);
            return Adjacents[v];
        }

        /// <summary>
        /// Returns all directed edges in the edge-weighted digraph.
        /// To iterate over the edges in the edge-weighted graph, use foreach notation:
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DirectedEdge> GetDirectedEdges()
        {
            List<DirectedEdge> list = new List<DirectedEdge>();
            for (int v = 0; v < Vertices; v++)
            {
                foreach (DirectedEdge e in Adjacents[v])
                    list.Add(e);

            }
            return list;
        }

        /// <summary>
        /// Returns a string representation of the edge-weighted digraph.
        /// This method takes time proportional to E + V
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string NEWLINE = "\n";
            StringBuilder sb = new StringBuilder();
            sb.Append(Vertices + " " + Edges + NEWLINE);

            for (int v = 0; v < Vertices; v++)
            {
                sb.Append(v + ": ");

                foreach (DirectedEdge e in Adjacents[v])
                {
                    sb.Append(e + " ");
                }
                sb.Append(NEWLINE);
            }

            return sb.ToString();
        }
    }
}
