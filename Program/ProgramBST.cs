using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgosBST;

namespace Algos
{
    class ProgramBST
    {
        static void MainBST(string[] args)
        {
           

            Console.WriteLine("Binary Search Tree Test\n");
            BST bst = new BST();
            char ch;
            //if (isValid)
            {
                do
                {
                    Console.WriteLine("\nBinary Search Tree Operations\n");
                    Console.WriteLine("1. insert ");
                    Console.WriteLine("2. delete");
                    Console.WriteLine("3. search");
                    Console.WriteLine("4. count nodes");
                    Console.WriteLine("5. check empty");

                    int choice;
                    bool isValid = int.TryParse(Console.ReadLine(), out choice);

                               // int choice = scan.nextInt();            
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter integer element to insert");
                    int.TryParse(Console.ReadLine(), out choice);
                    bst.Insert(choice);
                    break;
                case 2:
                    Console.WriteLine("Enter integer element to delete");
                    int.TryParse(Console.ReadLine(), out choice);
                    bst.Delete(choice);
                    break;
                case 3:
                    Console.WriteLine("Enter integer element to search");
                    int.TryParse(Console.ReadLine(), out choice);
                    Console.WriteLine("Search result : " + bst.Search(choice));
                    break;
                case 4:
                    Console.WriteLine("Nodes = " + bst.CountNodes());
                    break;
                case 5:
                    Console.WriteLine("Empty status = " + bst.IsEmpty());
                    break;
                default:
                    Console.WriteLine("Wrong Entry \n ");
                    break;   
            }
            /*  Display tree  */ 
            Console.WriteLine("\nPost order : ");
            bst.PostorderTraveral();
            Console.WriteLine("\nPre order : ");
            bst.PreorderTraversal();
            Console.WriteLine("\nIn order : ");
            bst.InorderTraveral();

            Console.WriteLine("\nIs it a BST : " + bst.IsValidBST());

            int k = 7;
            AlgosBST.Node n = bst.FindFirstLargerKWithKExist(k);
            if(n != null)
                Console.WriteLine("\nfindFirstLarger " + k +": "+ n.getValue());



                    Console.WriteLine("\nDo you want to continue (Type y or n)");
                    char.TryParse(Console.ReadLine(),out  ch);
                } while (ch != 'N' || ch != 'n');
            }

        }
    }
}
