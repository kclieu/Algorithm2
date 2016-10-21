using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos.Amazon
{
    public class Course
    {
        public string Id { get; set; }
        public DateTime OfferTime { get; set; }

        public Course(string id, DateTime offerTime)
        {
            this.Id = id;
            this.OfferTime = offerTime;
        }
    }

    public class User
    {
        public string Id { get; set; }
        public List<User> Friends = new List<User>();
        public List<Course> Courses = new List<Course>();

        public User(string id)
        {
            this.Id = id;
        }

        public void EnrollCourse(Course course)
        {
            if (!Courses.Contains(course))
                Courses.Add(course);
        }

        public void EnrollCourses(List<Course> courses)
        {
            foreach (Course course in courses)
            {
                EnrollCourse(course);
            }
        }

        public void AddFriend(User user)
        {
            if (!Friends.Contains(user))
                Friends.Add(user);
        }

        public void AddFriends(List<User> friends)
        {
            foreach (User user in friends)
                AddFriend(user);
        }



        public List<string> getDirectFriendsForUser()
        {
            Dictionary<string, string> directFriends = new Dictionary<string, string>();

            foreach (User friend in Friends)
            {
                directFriends.Add(friend.Id, friend.Id);
            }

            foreach (User friend in Friends)
            {
                List<User> friendsFriends = friend.Friends;

                foreach (User user in friendsFriends)
                {
                    if (user.Id.Equals(Id))
                        continue;

                    if (!directFriends.ContainsKey(user.Id))
                    {
                        directFriends.Add(user.Id, user.Id);
                    }
                }
            }

            return directFriends.Keys.ToList();
        }


        public List<string> getDirectFriendsForUser1()  //this is wrong
        {
            Dictionary<string, string> directFriends = new Dictionary<string, string>();
            List<string> directFriendList = new List<string>();

            foreach (User friend in Friends)
            {
                List<User> friendsFriends = friend.Friends;

                foreach (User user in friendsFriends)
                {
                    if (user.Id.Equals(Id))
                        continue;

                    if (!directFriends.ContainsKey(user.Id))
                    {
                        directFriends.Add(user.Id, user.Id);
                    }
                }
            }

            return directFriends.Keys.ToList();
        }


        public List<string> getAttendedCoursesForUser()
        {
            return Courses.OrderBy(c => c.OfferTime).Select(c => c.Id).ToList();
        }



        public class CourseEnrollment
        {
            Dictionary<string, Tuple<User, List<Course>>> Enrollment = new Dictionary<string, Tuple<User, List<Course>>>();


            public CourseEnrollment()
            { }


            public CourseEnrollment(User user, List<Course> courses)
            {
                Tuple<User, List<Course>> tup = new Tuple<User, List<Course>>(user, courses);
                Enrollment.Add(user.Id, tup);
            }

            public void AddStudent(User user)
            {
                Enrollment.Add(user.Id, new Tuple<User, List<Course>>(user, user.Courses));
            }

            public List<string> getRankedCourses(string userId)
            {

                Dictionary<string, int> rankedCourses = new Dictionary<string, int>();

                Tuple<User, List<Course>> tuple = Enrollment[userId];
                Dictionary<string, string> userAttendedCourses = new Dictionary<string, string>();

                User user = null;
                if (tuple != null)
                {
                    user = tuple.Item1;
                    List<Course> courses = tuple.Item2;

                    foreach (Course course in courses)
                    {
                        userAttendedCourses.Add(course.Id, course.Id);
                    }
                }

                if (user != null)
                {
                    List<string> friends = user.getDirectFriendsForUser();

                    foreach (string friend in friends)
                    {
                        Tuple<User, List<Course>> friendTuple = Enrollment[friend];

                        List<Course> friendCourses = friendTuple.Item2;

                        foreach (Course course in friendCourses)
                        {
                            if (!userAttendedCourses.ContainsKey(course.Id))
                            {
                                if (!rankedCourses.ContainsKey(course.Id))
                                    rankedCourses.Add(course.Id, 1);
                                else
                                {
                                    int num = rankedCourses[course.Id];
                                    num++;
                                    rankedCourses[course.Id] = num;

                                }
                            }
                        }
                    }
                }

                return rankedCourses.OrderByDescending(c => c.Value).Select(c => c.Key).ToList();
            }
        }

        public static void MainAmazon()
        {


            Course English = new Course("ENG", new DateTime(2016, 1, 5));
            Course History = new Course("HIST", new DateTime(2016, 1, 5));
            Course Geography = new Course("GEO", new DateTime(2016, 3, 5));
            Course French = new Course("FREN", new DateTime(2016, 2, 5));
            Course Math = new Course("MATH", new DateTime(2014, 1, 5));
            Course Physics = new Course("PHYS", new DateTime(2012, 1, 5));
            Course Chemistry = new Course("CHEM", new DateTime(2013, 1, 5));
            Course Biology = new Course("BIO", new DateTime(2013, 11, 5));
            Course PE = new Course("PE", new DateTime(2013, 4, 5));
            Course BioChem = new Course("BioChem", new DateTime(2013, 4, 5));
            Course Arts = new Course("Arts", new DateTime(2013, 5, 5));

            CourseEnrollment courseEnrollment = new CourseEnrollment();

            //-----------Courses

            User Joe = new User("Joe");
            Joe.EnrollCourse(Physics);
            Joe.EnrollCourse(French);


            User Sue = new User("Sue");
            Sue.EnrollCourse(Physics);
            Sue.EnrollCourse(Math);
            Sue.EnrollCourse(PE);


            User Amy = new User("Amy");
            Amy.EnrollCourse(Chemistry);
            Amy.EnrollCourse(Biology);
            Amy.EnrollCourse(Math);

            User Sammy = new User("Sammy");
            Sammy.EnrollCourse(PE);
            Sammy.EnrollCourse(BioChem);

            User Anne = new User("Anne");
            Anne.EnrollCourse(Biology);
            Anne.EnrollCourse(Math);

            User Arnold = new User("Arnold");
            Arnold.EnrollCourse(Math);
            Arnold.EnrollCourse(Biology);
            //Arnold.EnrollCourse(BioChem);

            User John = new User("John");
            John.EnrollCourse(Math);
            John.EnrollCourse(Biology);
            John.EnrollCourse(BioChem);
            John.EnrollCourse(BioChem);
            John.EnrollCourse(BioChem);
            John.EnrollCourse(BioChem);
            John.EnrollCourse(BioChem);
            John.EnrollCourse(BioChem);

            User Tom = new User("Tom");
            Tom.EnrollCourse(Arts);

            //----------------Friends------------------
            Joe.AddFriend(Sue);
            Joe.AddFriend(Amy);
            Joe.AddFriend(Tom);

            Sue.AddFriend(Joe);
            Sue.AddFriend(Amy);
            Sue.AddFriend(Sammy);

            Amy.AddFriend(Joe);
            Amy.AddFriend(Sue);
            Amy.AddFriend(Arnold);
            Amy.AddFriend(Anne);

            Sammy.AddFriend(Sue);
            Sammy.AddFriend(Anne);
            Sammy.AddFriend(John);

            Anne.AddFriend(Sammy);
            Anne.AddFriend(Amy);
            Anne.AddFriend(John);

            John.AddFriend(Sammy);
            John.AddFriend(Anne);

            Arnold.AddFriend(Amy);

            /////////////////////////
            courseEnrollment.AddStudent(Joe);
            courseEnrollment.AddStudent(Sue);
            courseEnrollment.AddStudent(Amy);
            courseEnrollment.AddStudent(Sammy);
            courseEnrollment.AddStudent(Anne);
            courseEnrollment.AddStudent(Arnold);
            courseEnrollment.AddStudent(John);
            courseEnrollment.AddStudent(Tom);

            List<string> rankedCourses = courseEnrollment.getRankedCourses("Joe");

            foreach (string course in rankedCourses)
            {
                Console.WriteLine(course);
            }


            Console.Write("End");
            Console.Read();
        }

    }


}
