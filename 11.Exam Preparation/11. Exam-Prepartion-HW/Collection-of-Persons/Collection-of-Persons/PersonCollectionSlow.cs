using System;
using System.Collections.Generic;
using System.Linq;

public class PersonCollectionSlow : IPersonCollection
{
    private readonly List<Person> persons;

    public PersonCollectionSlow()
    {
        this.persons = new List<Person>();
    }

    public bool AddPerson(string email, string name, int age, string town)
    {
        var newPerson = new Person(email, name, age, town);
        var person = this.persons.FirstOrDefault(p => p.Email == email);
        if (person != null)
        {
            return false;
        }

        this.persons.Add(newPerson);
        return true;
    }

    public int Count
    {
        get { return this.persons.Count; }
    }

    public Person FindPerson(string email)
    {
        return this.persons.FirstOrDefault(p => p.Email == email);
    }

    public bool DeletePerson(string email)
    {
        var personForDelete = this.persons.FirstOrDefault(p => p.Email == email);
        if (personForDelete == null)
        {
            return false;
        }

        this.persons.Remove(personForDelete);
        return true;
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        return this.persons
            .FindAll(p => p.Email.Substring(p.Email.IndexOf("@") + 1) == emailDomain)
            .OrderBy(p => p.Email);
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        return this.persons
            .FindAll(p => p.Name == name && p.Town == town)
            .OrderBy(p => p.Email);
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        return this.persons
            .FindAll(p => p.Age >= startAge && p.Age <= endAge)
            .OrderBy(p => p.Age)
            .ThenBy(p => p.Email);
    }

    public IEnumerable<Person> FindPersons(
        int startAge, int endAge, string town)
    {
        return this.persons
         .FindAll(p => p.Age >= startAge && p.Age <= endAge && p.Town == town)
         .OrderBy(p => p.Age)
         .ThenBy(p => p.Email);
    }
}
