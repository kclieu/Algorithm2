using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos.BellmanFord
{
    class BellmanFord
    {
        static long MyMaxValue = 100000000000000000;
        //static long MyMaxValue = long.MaxValue;
        //shortest distance with negative cycles
        //public static void shortestDistance(List<int>[] verts, List<int>[] wts, int start, double[] dists, int[] reached, int[] shortest)
        public static void shortestDistance(List<int>[] verts, List<int>[] wts, int start, long[] dists, int[] reached, int[] shortest)
        {
            {
                dists[start] = 0;

                //for (int i = 0; i < 2*verts.Length; i++) //passed
                for (int i = 0; i < verts.Length; i++) //passed
                                                       //for (int i = 0; i < verts.Length-1; i++) //failed
                                                       //for (int i = 0; i < 1; i++)
                {
                    for (int k = 0; k < verts.Length; k++)
                    {
                        List<int> neighbors = verts[k];
                        List<int> weights = wts[k];

                        if (neighbors != null)
                        {
                            for (int j = 0; j < neighbors.Count; j++)
                            {
                                int neighbor = neighbors[j];
                                int edgeWt = weights[j];

                                if (dists[neighbor] > dists[k] + edgeWt)
                                {
                                    //dists[neighbor] = dists[k] + edgeWt;
                                    dists[neighbor] = dists[k] + edgeWt;
                                }
                                else if (dists[neighbor] < dists[k] + edgeWt)
                                {
                                    //dists[neighbor] = dists[k] + edgeWt;
                                    //reached[neighbor] = 0;
                                }
                            }
                        }
                    }
                }

                for (int i = 0; i < verts.Length; i++)
                {
                    if (dists[i] < 0)
                    {
                        reached[i] = 1;
                        shortest[i] = 0;
                    }
                    //else if (dists[i] == double.MaxValue)
                    //else if (dists[i] == long.MaxValue)
                    else if (dists[i] == MyMaxValue)
                    {
                        reached[i] = 0;

                    }
                    else
                    {
                        reached[i] = 1;
                    }
                }
            }
        }
        private static void Main_BellmanFord(string[] args)
        {
            List<int>[] verts = new List<int>[5];
            List<int>[] wts = new List<int>[5];
            verts[0] = new List<int> { 1 }; wts[0] = new List<int> { 1 };
            verts[3] = new List<int> { 0 }; wts[3] = new List<int> { 2 };
            verts[1] = new List<int> { 2 }; wts[1] = new List<int> { 2 };
            verts[2] = new List<int> { 0 }; wts[2] = new List<int> { -5 };

            int start = 3;

            int[] reached = new int[5];
            //double[] dists = new double[5];
            long[] dists = new long[5];
            int[] shortest = new int[5];
            for (int i = 0; i < reached.Length; i++)
            {
                reached[i] = 0;
                //dists[i] = double.MaxValue;
                //dists[i] = long.MaxValue;

                dists[i] = MyMaxValue;
                shortest[i] = 1;
            }


            shortestDistance(verts, wts, start, dists, reached, shortest);

            for (int i = 0; i < dists.Length; i++)
            {
                if (reached[i] == 0)
                {
                    Console.WriteLine("*");
                }
                else if (shortest[i] == 0)
                {
                    Console.WriteLine("-");
                }
                else
                {
                    Console.WriteLine(dists[i]);
                }
            }

            Console.Read();
            //5 4
            //1 2 1
            //4 1 2
            //2 3 2
            //3 1-5
            //4
        }
    }


}
