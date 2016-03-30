using System;
using System.Collections.Generic;
using System.Linq;

public class PersonCollectionSlow : IPersonCollection
{
    private List<Person> persons;

    public PersonCollectionSlow()
    {
        this.persons = new List<Person>();
    }

    public bool AddPerson(string email, string name, int age, string town)
    {
        var newPerson = FindPerson(email);
        if (newPerson != null)
        {
            return false;
        }
        newPerson = new Person(email, name, age, town);
        this.persons.Add(newPerson);
        return true;
    }

    public int Count
    {
        get
        {
            return this.persons.Count;
        }
    }

    public Person FindPerson(string email)
    {
        var person = this.persons.FirstOrDefault(p => p.Email == email);
        return person;
    }

    public bool DeletePerson(string email)
    {
        var personForDelete = FindPerson(email);
        return this.persons.Remove(personForDelete);

    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        return this.persons
            .Where(p => p.Email.EndsWith("@" + emailDomain))
            .OrderBy(p => p.Email);
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        return this.persons
            .Where(p => p.Name == name && p.Town == town)
            .OrderBy(p => p.Email);
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        return this.persons
            .Where(p => p.Age >= startAge && p.Age <= endAge)
            .OrderBy(p => p.Age)
            .ThenBy(p => p.Email);
    }

    public IEnumerable<Person> FindPersons(
        int startAge, int endAge, string town)
    {
        return this.persons
          .Where(p => p.Town == town)
          .Where(p => p.Age >= startAge && p.Age <= endAge)
          .OrderBy(p => p.Age)
          .ThenBy(p => p.Email);
    }
}
