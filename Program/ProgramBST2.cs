using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgosBST;

namespace Algos
{
    class ProgramBST2
    {
        static void MainProgramBST2(string[] args)
        {
            BST bst = new BST();
            bst.Insert(16);
            bst.Insert(8);
            bst.Insert(20);
            bst.Insert(4);
            bst.Insert(22);
            bst.InorderTraveral();

            int k1 = 3;
            int k2 = 2;

           
            List<int> l1 = bst.FindKLargestInBST(k1);
            Console.WriteLine();
            Console.WriteLine(k1 + " th largest elements: ");
            foreach (int i in l1)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine("Build BST tree from a sorted linked list");

            Console.Read();

            
        }
    }
}
