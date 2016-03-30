namespace _01.StudentsAndCourses
{
    using System;
    using System.Collections.Generic;

    public class MainClass
    {
        public static void Main(string[] args)
        {
            var students = new SortedDictionary<string, SortedSet<Person>>();

            string input = Console.ReadLine();
            while (!string.IsNullOrEmpty(input))
            {
                string[] parameters = input.Split('|');
                string firstName = parameters[0].Trim();
                string lastName = parameters[1].Trim();
                string course = parameters[2].Trim();

                if (!students.ContainsKey(course))
                {
                    students[course] = new SortedSet<Person>();
                }

                students[course].Add(new Person(firstName, lastName));

                input = Console.ReadLine();
            }

            foreach (var course in students)
            {
                Console.WriteLine("{0}: {1}", course.Key, string.Join(", ",course.Value));
            }
        }
    }
}
