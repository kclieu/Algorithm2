using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Algos
{
    class MySemaphore
    {
        public Semaphore sem1, sem2, sem3;

        public MySemaphore()
        {
            sem1 = new Semaphore(1, 1);
            sem2 = new Semaphore(1, 1);
            sem3 = new Semaphore(1, 1);

            sem1.GetLifetimeService();
            sem2.GetLifetimeService();
            sem3.GetLifetimeService();
            //sem1.GetAccessControl();
            //sem2.GetAccessControl();
            //sem3.GetAccessControl();
        }

        public void First()
        {
            try
            {
                //sem1.GetAccessControl();
                Console.WriteLine("First");
                sem1.Release(1);
            }
            catch { };
        }

        public void Second()
        {
            try
            {
                sem1.GetLifetimeService();
                Console.WriteLine("Second");
                sem1.Release(1);

                sem2.Release(1);
            }
            catch { };
        }

        public void Third()
        {
            try
            {

                sem2.GetLifetimeService();
                Console.WriteLine("Third");
                sem2.Release(1);
            }
            catch { }
        }
    }

    class MySemaphoreTest
    {
        static void SemaphoreMain()
        {

            MySemaphore mySem = new MySemaphore();
            //for (int i = 0; i < 10; i++)
            {
                mySem.Third();
                mySem.Second();
                mySem.First();
            }
            Console.WriteLine("Done");
            Console.Read();
        }
    }
}
