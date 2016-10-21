using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos.Amazon
{
    public class Member
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        public string Email { get; set; }
        List<Member> Friends { get; set; }

        public Member(string name, string email, List<Member> friends)
        {
            Name = name;
            Email = email;
            Friends = friends;
        }

        public Member(string name)
        {
            Name = name;
            Friends = new List<Member>();
        }

        public void AddFriend(Member friend)
        {
            Friends.Add(friend);
        }

        public double GetMonthlyAmazonDollars()
        {
            return new Random().NextDouble() * 10000;
        }

        public ICollection<Member> GetRecruitedMembers()
        {
            return new List<Member>(new Random().Next(5));
        }


        public static void PrintSocialGraph(Member m)
        {
            Queue<Member> friendQueue = new Queue<Member>();
            friendQueue.Enqueue(m);

            while (friendQueue.Count > 0)
            {
                Member member = friendQueue.Dequeue();
                if (member == null)
                    continue;

                foreach (Member friend in member.Friends)
                {
                    friendQueue.Enqueue(friend);
                }

                Console.WriteLine(member.Name);
            }
        }

        public static double CalculatePayout(Member member)
        {

            double memberPayout = 0;



            Queue<Member> recruits = new Queue<Member>();
            recruits.Enqueue(member);

            while (recruits.Count > 0)
            {
                Member m = recruits.Dequeue();

                if (m == member)
                {
                    double payOut = m.GetMonthlyAmazonDollars() * 0.10;
                    memberPayout = memberPayout + payOut;
                }
                else
                {
                    double payOut = m.GetMonthlyAmazonDollars() * 0.04;
                    memberPayout = memberPayout + payOut;
                }

                foreach (Member recruit in m.GetRecruitedMembers())
                {
                    recruits.Enqueue(recruit);
                }
            }

            return memberPayout;

        }


        public static void MainSNF()
        {
            Member Ken = new Member("Ken");

            Member John = new Member("John");
            Member Jack = new Member("Jack");
            Member Jason = new Member("Jason");

            Member Lucy = new Member("Lucy");
            Member Lily = new Member("Lily");
            Member Lola = new Member("Lola");

            Member Daniel = new Member("Daniel");
            Member David = new Member("David");
            Member Donald = new Member("Donald");


            Ken.AddFriend(John);
            Ken.AddFriend(Jack);
            Ken.AddFriend(Jason);

            John.AddFriend(Lucy);
            John.AddFriend(Lily);
            Jason.AddFriend(Lola);

            Lucy.AddFriend(Daniel);
            Lucy.AddFriend(David);
            Lola.AddFriend(Donald);


            Member.PrintSocialGraph(Ken);

            Console.Read();

        }

    }
}
