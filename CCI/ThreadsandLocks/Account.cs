using System;
using System.Threading;
using System.Threading.Tasks;

namespace Algos
{
    public class Account
    {
        private object thisLock = new object();
        int balance;
        Random r = new Random();

        public Account(int bal)
        {
            balance = bal;
        }

        private int Withdraw(int amount)
        {
            // This condition never is true unless the lock statement 
            // is commented out. 
            if (balance < 0)
            {
                throw new Exception("Negative Balance");
            }

            // Comment out the next line to see the effect of leaving out  
            // the lock keyword. 
            //lock (thisLock)
            {
                if (balance >= amount)
                {
                    Console.WriteLine("Balance before withdrawal :  " + balance);
                    Console.WriteLine("Amount to withdraw        : -" + amount);
                    balance = balance - amount;
                    Console.WriteLine("Balance after withdrawal   : " + balance);
                    return amount;
                }
                else
                {
                    return 0; //transaction rejected
                }
            }
        }

        public void DoTransaction()
        {
            for (int i = 0; i < 100; i++)
            {
                Withdraw(r.Next(1, 100));
            }
        }
    }

    class AccountTest
    {
        static void MainAccountTest()
        {
            Thread[] threads = new Thread[10];
            Account acc = new Account(1000);

            for (int i = 0; i < 10; i++)
            {
                Thread t = new Thread(new ThreadStart(acc.DoTransaction));
                threads[i] = t;
            }

            for (int i = 0; i < 10; i++)
            {
                threads[i].Start();
            }

            Console.Read();
        }
    }
}
