namespace _01.StudentsAndCourses
{
    using System;
    public class Person : IComparable<Person>
    {
        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CompareTo(Person other)
        {
            return String.Compare(this.LastName, other.LastName, StringComparison.Ordinal);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.FirstName, this.LastName);
        }
    }
}
