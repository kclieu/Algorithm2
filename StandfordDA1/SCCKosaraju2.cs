using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    /*
     Programming Question #4
    https://class.coursera.org/algo-007/quiz/attempt?quiz_id=57
    Download the text file here. Zipped version here. (Right click and save link as)
    The file contains the edges of a directed graph. Vertices are labeled as positive integers from 1 to 875714. 
    Every row indicates an edge, the vertex label in first column is the tail and the vertex label in 
    second column is the head (recall the graph is directed, and the edges are directed from the first 
    column vertex to the second column vertex). So for example, the 11th row looks liks : "2 47646". 
    This just means that the vertex with label 2 has an outgoing edge to the vertex with label 47646

    Your task is to code up the algorithm from the video lectures for computing strongly 
    connected components (SCCs), and to run this algorithm on the given graph. 

    Output Format: You should output the sizes of the 5 largest SCCs in the given graph, in decreasing order of sizes, 
    separated by commas (avoid any spaces). So if your algorithm computes the sizes of the five largest SCCs 
    to be 500, 400, 300, 200 and 100, then your answer should be "500,400,300,200,100". If your algorithm finds less than 5 SCCs, then write 0 for the remaining terms. Thus, if your algorithm computes only 3 SCCs whose sizes are 400, 300, and 100, then your answer should be "400,300,100,0,0".

    WARNING: This is the most challenging programming assignment of the course. 
    Because of the size of the graph you may have to manage memory carefully. 
    The best way to do this depends on your programming language and environment, 
    and we strongly suggest that you exchange tips for doing this on the discussion forums.*/


    //BFS stores nodes in a queue(FIFO) while DFS uses a stack(LIFO)

    public class SCCKosaraju2
    {
        //Compute Strong connected components using Kosaraju's algorithm;
        public static List<List<int>> SCC(List<int>[] graph)
        {
            int len = graph.Length;
            bool[] used = new bool[len];
            List<int> order = new List<int>();

            for (int node = 1; node < len; node++)
            {
                if (!used[node])
                {
                    DFS(graph, used, order, node);
                }
            }


            //First step of algo: Reverse graph
            List<int>[] reverseGraph = new List<int>[len];
            for (int i = 1; i < len; i++)
            {
                reverseGraph[i] = new List<int>();
            }

            for (int i = 1; i < len; i++)
            {
                foreach (int j in graph[i])
                {
                    reverseGraph[j].Add(i);
                }

                //for (int j = 1; j < graph.Length; j++)
                //{
                //    reverseGraph[j].Add(i);
                //}
            }

            List<List<int>> components = new List<List<int>>();

            for (int i = 1; i < used.Length; i++)
                used[i] = false;

            order.Reverse();

            foreach (int u in order)
            {
                if (!used[u])
                {
                    List<int> component = new List<int>();
                    DFS(reverseGraph, used, component, u);
                    components.Add(component);
                }
            }

            return components;
        }


        //Perform depth first search
        //public static void DFS(List<int>[] graph, bool[] used, List<int> result, int node)
        //{
        //    used[node] = true;

        //    foreach (int n in graph[node])
        //    {
        //        if (!used[n])
        //            DFS(graph, used, result, n);
        //    }
        //    result.Add(node);
        //}

        public static void DFS(List<int>[] graph, bool[] used, List<int> result, int node)
        {
            Stack<int> stack = new Stack<int>();
            
            //used[node] = true;
            stack.Push(node);


            while (stack.Count > 0)
            {
                int v = stack.Peek();

                //int v = stack.Pop();

                if (node == v)
                {
                    stack.Pop();
                    used[node] = true;

                }
                else
                {

                    foreach (int n in graph[node])
                    {
                        if (!used[n])
                        {
                            //used[n] = true;
                            stack.Push(n);
                        }
                        //else
                        //stack.Pop();
                    }
                }

            }


            //foreach (int n in graph[node])
            //{
            //    if (!used[n])
            //        DFS(graph, used, result, n);
            //}
            result.Add(node);
        }

        //public static void DFS(List<int>[] graph, bool[] used, List<int> result, int node)
        //{
        //    Stack<int> stack = new Stack<int>();
        //    stack.Push(node);

        //    while (stack.Count > 0)
        //    {
        //        used[node] = true;

        //        foreach (int n in graph[node])
        //        {
        //            if (!used[n])
        //                stack.Push(n);
        //                //DFS(graph, used, result, n);
        //        }
        //        result.Add(node);
        //    }
        //}


        public static void MainSCCKosaraju2(String[] args)
        {
            string path = @"C:\Users\Ken\Documents\Visual Studio 2013\Algos\StandfordDA1\Data\Programming Q4\SCCTest1.txt";
            List<int>[] graph = ParseFile(path);
            List<List<int>> components = SCC(graph).OrderByDescending(a => a.Capacity).ToList();

        
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

                graph[node].Add(edge);
            }

            return graph;
        }
    }
}
