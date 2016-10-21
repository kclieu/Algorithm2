using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    //http://algs4.cs.princeton.edu/42directed/KosarajuSharirSCC.java.html
    public class KosarajuSharirSCC
    {
        private bool[] Marked;  // marked[v] = has vertex v been visited?
        private int[] Id;  //id[v] = id of strong component containing v
        private int Count;  // number of strongly-connected components

        public KosarajuSharirSCC(Digraph G)
        {
            DepthFirstOrder dfs = new DepthFirstOrder(G.Reverse());
            Marked = new bool[G.GetVertices()];
            Id = new int[G.GetVertices()];

            foreach (int v in dfs.ReversePost())
            { 
                if(!Marked[v])
                {
                    //DFS(G, v);
                    NonRecursiveDFS(G, v);
                    Count++;
                }
            }
        }

        private void DFS(Digraph G, int v)
        {
            Marked[v] = true;
            Id[v] = Count;

           foreach (int w in G.GetAdjacents(v))
                if (!Marked[w]) DFS(G, w);
        }

        private void NonRecursiveDFS(Digraph G, int v)
        {


            //List<int>[] adjacents = (List<int>[])new List<int>[G.GetVertices()];
            IEnumerator<int>[] adjacents = (IEnumerator<int>[])new IEnumerator<int>[G.GetVertices()];

            for (int i = 0; i < G.GetVertices(); i++)
            {
                adjacents[i] = G.GetAdjacents(i).GetEnumerator();
            }

            Stack<int> stack = new Stack<int>();
            Marked[v] = true;
            Id[v] = Count;
            stack.Push(v);

            while (stack.Count > 0)
            {
                int i = stack.Peek();

                //IEnumerator<int> ie = adjacents[i].GetEnumerator();
                //bool moveNext = ie.MoveNext();

                if (adjacents[i].MoveNext())
                {
                    int w = adjacents[i].Current;
            
                    if (!Marked[w])
                    {
                        Marked[w] = true;
                        stack.Push(w); ;
                    }
                }
                else
                {
                    stack.Pop();
                }
            }
        }

        public bool StronglyConntected(int v, int w)
        {
            return Id[v] == Id[w];
        }

        public int GetCount()
        {
            return Count;
        }

        public int GetId(int v)
        {
            return Id[v];
        }



        public static void MainKosa(String[] args)
        {
            
            //string path = @"C:\Users\Ken\Documents\Visual Studio 2013\Algos\StandfordDA1\Data\Programming Q4\SCC.txt";
            string path = @"C:\Users\Ken\Documents\Visual Studio 2013\Algos\StandfordDA1\Data\Programming Q4\SCCTest1.txt";
            //string path = @"C:\Users\Ken\Documents\Visual Studio 2013\Algos\StandfordDA1\Data\Programming Q4\SCCTest2.txt";
            //string path = @"C:\Users\Ken\Documents\Visual Studio 2013\Algos\StandfordDA1\Data\Programming Q4\SCCMedtest.txt";

            //List<int>[] graph = ParseFile(path);
            //List<List<int>> components = SCC(graph).OrderByDescending(a => a.Capacity).ToList();
            Digraph G = ParseFile(path);
            KosarajuSharirSCC scc = new KosarajuSharirSCC(G);
            int count = scc.GetCount();

            Console.WriteLine("Number of strongly componets is :" + count);

            //Compute list of vertices in each strong component
            Queue<int>[] components = (Queue<int>[])new Queue<int>[count];
            for (int i = 0; i < count; i++)
                components[i] = new Queue<int>();

            for (int v = 0; v < G.GetVertices(); v++)
                components[scc.GetId(v)].Enqueue(v);



            Queue<int>[] orderedComps = components.OrderBy(t => t.Count).ToArray();
            //Queue<int>[] orderedComps = components.OrderByDescending(t => t.Count).ToArray();

            for (int i = 0; i < count; i++)
            {
                int componentCount = orderedComps[i].Count;
                Console.Write(componentCount);

                //foreach (int v in orderedComps[i])
                //{
                //    Console.Write(v + " ");
                //}

                Console.WriteLine();
            }


            //Code below prints out the connected components
            //for(int i = 0; i < count; i++)
            //{
            //    //int componentCount = components[i].Count;

            //    foreach(int v in components[i])
            //    {
            //        Console.Write(v + " ");
            //    }

            //    Console.WriteLine();
            //}

            Console.Read();
        }

        public static Digraph ParseFile(string path)
        {
            StreamReader reader = File.OpenText(path);
            string line;

            //int nodes = 875714;
            //int nodes = 875715;
            int nodes = 10;
            //int nodes = 13;
            //int nodes = 10001;

            //This one gives wrong answer since number of nodes is derived on counting number of lines in test file
            //List<int>[] graph = new List<int>[nodes];
            Digraph g = new Digraph(nodes);



            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int node = int.Parse(data[0]);
                int edge = int.Parse(data[1]);

                g.AddEdge(node, edge);
            }

            return g;
        }
    }
}
