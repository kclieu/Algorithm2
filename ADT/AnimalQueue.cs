using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    //CCI 3.7
    //An animal shelter holds only dogs and cats, and operates on a strictly "first in, first
    //out" basis. People must adopt either the "oldest" (based on arrival time) of all animals
    //at the shelter, or they can select whether they would prefer a dog or a cat (and will
    //receive the oldest animal of that type). They cannot select which specific animal they
    //would like. Create the data structures to maintain this system and implement operations
    //such as enqueue, dequeueAny, dequeueDog and dequeueCat. You may
    //use the built-in L inkedL ist data structure.

    /// <summary>
    /// 
    /// </summary>
    public abstract class Animal
    {
        private int Order;
        protected string Name;

        public Animal(string n)
        {
            this.Name = n;
        }

        public void SetOrder(int ord)
        {
            Order = ord;
        }

        public int GetOrder()
        { 
            return Order;
        }

        public bool IsOlderThan(Animal a)
        {
           return  this.Order < a.GetOrder();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Dog:Animal
    {
        public Dog(string n):base(n)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Cat : Animal
    {
        public Cat(string n)
            : base(n)
        { }
    }

    /// <summary>
    /// 
    /// </summary>
    public class AnimalQueue
    {
        LinkedList<Dog> dogs = new LinkedList<Dog>();
        LinkedList<Cat> cats = new LinkedList<Cat>();
        private int order = 0;

        public void Enqueue(Animal animal)
        {
            animal.SetOrder(order++);

            if (animal is Dog)
            {
               
                dogs.AddLast((Dog)animal);
            }
            else
            {
                cats.AddLast((Cat)animal);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dog DequeueDog()
        {
            if (dogs.Count > 0)
            {
                Dog dog = dogs.First();
                dogs.RemoveFirst();
                return dog;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Cat DequeueCat()
        {
            if (cats.Count > 0)
            {
                Cat cat = cats.First();
                cats.RemoveFirst();
                return cat;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Animal DequeueAny()
        {
            if (cats.Count == 0 && dogs.Count == 0)
                return null;
            else if (cats.Count == 0)
                return DequeueDog();
            else if (dogs.Count == 0)
                return DequeueDog();
            else
            {
                Cat cat = cats.First();
                Dog dog = dogs.First();
 
                if (cat.IsOlderThan(dog))
                    return DequeueCat();
                else
                    return DequeueDog();

            }       
        }
    }
}
