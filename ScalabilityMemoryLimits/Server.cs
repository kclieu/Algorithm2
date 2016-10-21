using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    //CCI 10.2 How would you design a data structures for a very 
    //large social network like Facebook or LinkedIn?  Describe how
    //you would design an algorithm to show the connections
    //or path between 2 people eg.  Me -> Bob -> Susan -> Jason

    //Construct a graph by treating each person as a node and letting
    //an edge between 2 nodes indicate that 2 users are friends.
    //To find the connection between 2 people, start with one person
    //and do a breadth-first-search.  
    //A depth first search would not work too well because it would
    //be very inefficient.  2 users might be only one degree of separation
    //apart but I could be searching millions of nodes in there "subtrees"
    //before finding this relative immediate connection.

    //Optimization 1: Reduce machine jumps
    //Jumping from one machine to another is expensive.  Instead of randomly
    //jumping from machine to machine with each friend, try to batch these
    //jumps - eg. if 5 of my friends live on one machine I should look them up 
    // all at once

    //Optimazation 2: Smart division of People and Machines
    //People are much more likely to be friends with people who live in 
    //the same country as they do.  Rather than randomly dividing people up
    //across machines, try to divide them up by country, city, state and so on.
    //This will reduce the number of jumps

    //Optimization 3:  Breadth First Search usually requires "marking" a node
    //as visited.  How do you do that in this case?
    //Usually in BFS, we maark a node as visited by setting a flag visited
    //in its node class.  Here, we don't want to do that.  There could be
    //multiple searches going on at the same time, so it's bad to just
    //edit our data.  Instead, we could mimic the marking of nodes with as hashtable
    //to look up a node id and whether or not it's been visited.

    /// <summary>
    /// class Server holds a list of all machines, and
    /// a class Machine which represents a single machine
    /// Both classes hava hash tables to efficiently look
    /// up data
    /// </summary>
    public class Server
    {
        Dictionary<int, Machine> machines = new Dictionary<int, Machine>();
        Dictionary<int, int> personToMachineMap = new Dictionary<int, int>();

        public Machine GetMachineWithId(int machineId)
        {
            return machines[machineId];
        }

        public int GetMachineIDForUser(int personId)
        {
            int machineId = personToMachineMap[personId];
            return machineId == null ? -1 : machineId;
        }

        public Person GetPersonWithID(int personId)
        {
            int machineId = GetMachineIDForUser(personId);

            if (machineId == null) return null;

            Machine machine = machines[machineId];
            if (machine == null) return null;

            return machine.GetPersonWithId(personId);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Person
    {
        //Note List<T> is equivant of Java ArrayList
        //Dictionary is equivalent of Java HashMap

        private List<int> friends;
        private int personID;

        public Person(int id)
        {
            this.personID = id;

        }

        public int GetId (){ return personID; }

        public void AddFriends(int id) { friends.Add(id); }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Machine 
    {
        public Dictionary<int, Person> persons = new Dictionary<int, Person>();
        public int machineID;

        public Person GetPersonWithId(int personID)
        {
            return persons[personID];
        }
    }

    //CCI 10.4
    /// <summary>
    /// 
    /// </summary>
    /*
    public static class Baby// CCI10_4
    { 
        private long numberOfInts = ((long) Int32.MaxValue)+1;
        //int n = (int)(numberOfInts / 8);
        byte[] bitfield = new byte[(int)(2222222 / 8)]; //byte[] bitfield = new byte[(int)(numberOfInts / 8)];

        
        public void FindOpenNumber()
        { 
            StreamReader reader = File.OpenText("file.txt");
           
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                int n = int.Parse(line);
                bitfield[n / 8] |= 1 << (n % 8);
            }

            for (int i = 0; i < bitfield.Length; i++)
            {
                for (int j = 0; j < 8; j++)
                { 
                    if((bitfield[i]) & (i << j)) == 0)
                    {
                        Console.WriteLine(i*8 + j);
                        return;
                    }
                }
            }
        }
    }*/
}
