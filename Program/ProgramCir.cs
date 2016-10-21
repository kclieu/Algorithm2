using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algos.CircularLinkedList;

namespace Algos
{
    class ProgramCir
    {
        static void MainCir(string[] args)
        {
            CircularLinkedList<int> list = new CircularLinkedList<int>();

            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            list.AddLast(5);
            list.AddLast(6);
            Console.WriteLine("List count = {0}", list.Count);
            Console.WriteLine("Head  = {0}", list.Head.Value);
            Console.WriteLine("Tail  = {0}", list.Tail.Value);
            Console.WriteLine("Head's Previous  = {0}", list.Head.Previous.Value);
            Console.WriteLine("Tail's Next  = {0}", list.Tail.Next.Value);
            //Console.WriteLine("Is Circulear {0}", list.IsCircular());
            Console.WriteLine("************List Items***********");


            //foreach (int i in list)
            //    Console.WriteLine(i);

            //Console.WriteLine("************List Items in reverse***********");
            //for (IEnumerator<int> r = list.GetReverseEnumerator(); r.MoveNext(); )
            //    Console.WriteLine(r.Current);

            //Console.WriteLine("************Adding a new item at first***********");
            //list.AddFirst(0);
            //foreach (int i in list)
            //    Console.WriteLine(i);

            //Console.WriteLine("************Adding item before***********");
            //list.AddBefore(2, 11);
            //foreach (int i in list)
            //    Console.WriteLine(i);

            //Console.WriteLine("************Adding item after***********");
            //list.AddAfter(3, 4);
            //foreach (int i in list)
            //    Console.WriteLine(i);


            Console.WriteLine("Fibonacci {0} ", MyMath.Fibonacci1(0));
            Console.WriteLine("Fibonacci {0} ", MyMath.Fibonacci1(1));
            Console.WriteLine("Fibonacci {0} ", MyMath.Fibonacci1(2));
            Console.WriteLine("Fibonacci {0} ", MyMath.Fibonacci1(3));
            Console.WriteLine("Fibonacci {0} ", MyMath.Fibonacci1(4));
            Console.WriteLine("Fibonacci {0} ", MyMath.Fibonacci1(5));
            Console.WriteLine("Fibonacci {0} ", MyMath.Fibonacci1(6));

            Console.WriteLine("Fibonacci {0} ", MyMath.Fibonacci2(0));
            Console.WriteLine("Fibonacci {0} ", MyMath.Fibonacci2(1));
            Console.WriteLine("Fibonacci {0} ", MyMath.Fibonacci2(2));
            Console.WriteLine("Fibonacci {0} ", MyMath.Fibonacci2(3));
            Console.WriteLine("Fibonacci {0} ", MyMath.Fibonacci2(4));
            Console.WriteLine("Fibonacci {0} ", MyMath.Fibonacci2(5));
            Console.WriteLine("Fibonacci {0} ", MyMath.Fibonacci2(6));

            MyMath.PrintOddUpToN(99);

            Console.WriteLine();
            MultiplicationTable tb = new MultiplicationTable(12);
            tb.DoMultiplication();


            int[] arr = {1, 0, -2, 5, 3, 11, 24, 44,32 };
            Console.WriteLine(MyMath.FindLargestNumber(arr));


            int[] arr1 = { 14, 23, 23, 4, 2, 10, 16 };
            int[] arrRet = MyMath.Find2LargestNumbers(arr1);
            Console.WriteLine(string.Format("First and send largest numbers are {0} {1}", arrRet[0], arrRet[1]));

            int fact = 6;
            Console.WriteLine("Factorial of " + fact + " is " + MyMath.Factorial(fact));
            Console.ReadKey();
        }
    }
}
