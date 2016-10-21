using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    //http://algs4.cs.princeton.edu/44sp/DirectedEdge.java.html
    /**
    *  The <tt>DirectedEdge</tt> class represents a weighted edge in an 
    *  {@link EdgeWeightedDigraph}. Each edge consists of two integers
    *  (naming the two vertices) and a real-value weight. The data type
    *  provides methods for accessing the two endpoints of the directed edge and
    *  the weight.
    *  <p>
    *  For additional documentation, see <a href="http://algs4.cs.princeton.edu/44sp">Section 4.4</a> of
    *  <i>Algorithms, 4th Edition</i> by Robert Sedgewick and Kevin Wayne.
    *
    *  @author Robert Sedgewick
    *  @author Kevin Wayne
    */
    public class DirectedEdge
    {
        private int v;
        private int w;
        private double weight;

        /// <summary>
        ///Initializes a directed edge from vertex v to vertex w with
        ///the given weight
        /// </summary>
        /// <param name="v"></param>
        /// <param name="w"></param>
        /// <param name="weight"></param>
        public DirectedEdge(int v, int w, double weight)
        {
            if (v < 0) throw new Exception("Vertex names must be nonnegative integers");
            if (w < 0) throw new Exception("Vertex names must be nonnegative integers");
            if(double.IsNaN(weight)) throw new Exception("Weight is not a number");
            this.v = v;
            this.w = w;
            this.weight = weight;
        }

        /// <summary>
        /// Returns the tail vertex of the directed edge.
        /// </summary>
        /// <returns></returns>
        public int From()
        {
            return v;
        }

        /// <summary>
        /// Returns the head vertex of the directed edge.
        /// </summary>
        /// <returns></returns>
        public int To()
        {
            return w;
        }

        /// <summary>
        /// Returns the weight of the directed edge
        /// </summary>
        /// <returns></returns>
        public double Weight()
        {
            return weight;
        }

        public override string ToString()
        {
            return v + "->" + w + " " + String.Format("{0}", weight);
        }

        public static void MainDirectEdges(String[] args)
        {
            DirectedEdge e = new DirectedEdge(12, 23, 3.14);
            Console.WriteLine(e.ToString());
            Console.Read();
        }
    }
}
