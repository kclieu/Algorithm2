using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    //A directed graph
    //http://algs4.cs.princeton.edu/42directed/Digraph.java.html
    //A directed graph (or digraph) is a set of vertices and a collection of 
    //directed edges that each connects an ordered pair of vertices. 
    //We say that a directed edge points from the first vertex in the pair 
    //and points to the second vertex in the pair. 
    //We use the names 0 through V-1 for the vertices in a V-vertex graph.

    //BFS and DFS
    //http://algs4.cs.princeton.edu/42directed/

    public class Digraph
    {
        private int Vertices;
        private int Edges;
        private List<int>[] Adjacents;

        //initialiszes an empty digraph with v vertices
        public Digraph(int v)
        {
            this.Vertices = v;
            this.Edges = 0;
            //Adjacents[v] = new List<int>();
            Adjacents = new List<int>[v];

            for (int i = 0; i < v; i++)
            {
                Adjacents[i] = new List<int>();
            }
        }


        /// <summary>
        /// Returns the number of vertices in the diagraph
        /// </summary>
        /// <returns></returns>
        public int GetVertices()
        {
            return Vertices;
        }

        /// <summary>
        /// Returns the number of edges in the diagraph
        /// </summary>
        /// <returns></returns>
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
        public int OutDegree(int v)
        {
            ValidateVertex(v);
            return Adjacents[v].Capacity;
        }

        public Digraph Reverse()
        {
            Digraph R = new Digraph(Vertices);
            for (int v = 0; v < Vertices; v++)
            {
                foreach (int w in Adjacents[v])
                { 
                    R.AddEdge(w, v); 
                }
            }

            return R;
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
