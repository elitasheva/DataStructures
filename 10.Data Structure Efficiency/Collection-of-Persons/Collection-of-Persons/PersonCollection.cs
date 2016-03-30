using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class PersonCollection : IPersonCollection
{
    private Dictionary<string, Person> personsByEmail;
    private Dictionary<string, SortedSet<Person>> personsByDomain;
    private Dictionary<string, SortedSet<Person>> personsByNameAndTown;
    private OrderedDictionary<int, SortedSet<Person>> personsByAge;
    private Dictionary<string, OrderedDictionary<int, SortedSet<Person>>> personsByTownAndAge;

    public PersonCollection()
    {
        this.personsByEmail = new Dictionary<string, Person>();
        this.personsByDomain = new Dictionary<string, SortedSet<Person>>();
        this.personsByNameAndTown = new Dictionary<string, SortedSet<Person>>();
        this.personsByAge = new OrderedDictionary<int, SortedSet<Person>>();
        this.personsByTownAndAge = new Dictionary<string, OrderedDictionary<int, SortedSet<Person>>>();
    }

    public bool AddPerson(string email, string name, int age, string town)
    {
        var person = this.FindPerson(email);
        if (person != null)
        {
            return false;
        }

        person = new Person(email, name, age, town);
        this.personsByEmail.Add(email, person);
        var domain = GetEmailDomain(email);
        if (!this.personsByDomain.ContainsKey(domain))
        {
            this.personsByDomain[domain] = new SortedSet<Person>();

        }
        this.personsByDomain[domain].Add(person);

        var key = name + town;
        if (!this.personsByNameAndTown.ContainsKey(key))
        {
            this.personsByNameAndTown[key] = new SortedSet<Person>();
        }
        this.personsByNameAndTown[key].Add(person);

        if (!this.personsByAge.ContainsKey(age))
        {
            this.personsByAge[age] = new SortedSet<Person>();
        }
        this.personsByAge[age].Add(person);

        if (!this.personsByTownAndAge.ContainsKey(town))
        {
            this.personsByTownAndAge[town] = new OrderedDictionary<int, SortedSet<Person>>();

        }
        if (!this.personsByTownAndAge[town].ContainsKey(age))
        {
            this.personsByTownAndAge[town][age] = new SortedSet<Person>();
        }
        this.personsByTownAndAge[town][age].Add(person);

        return true;
    }

    private string GetEmailDomain(string email)
    {
        var domain = email.Substring(email.IndexOf("@") + 1);
        return domain;
    }

    public int Count
    {
        get
        {
            return this.personsByEmail.Count;
        }
    }

    public Person FindPerson(string email)
    {
        if (!this.personsByEmail.ContainsKey(email))
        {
            return null;
        }

        return this.personsByEmail[email];
    }

    public bool DeletePerson(string email)
    {
        var personForDelete = this.FindPerson(email);
        if (personForDelete == null)
        {
            return false;
        }

        this.personsByEmail.Remove(email);
        var domain = this.GetEmailDomain(email);
        this.personsByDomain[domain].Remove(personForDelete);
        var key = personForDelete.Name + personForDelete.Town;
        this.personsByNameAndTown[key].Remove(personForDelete);
        this.personsByAge[personForDelete.Age].Remove(personForDelete);
        this.personsByTownAndAge[personForDelete.Town][personForDelete.Age].Remove(personForDelete);
        return true;
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        if (!this.personsByDomain.ContainsKey(emailDomain))
        {
             return Enumerable.Empty<Person>();
        }

        return this.personsByDomain[emailDomain];

    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        var key = name + town;
        if (!this.personsByNameAndTown.ContainsKey(key))
        {
            return Enumerable.Empty<Person>();
        }

        return this.personsByNameAndTown[key];
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        var persons = this.personsByAge.Range(startAge, true, endAge, true);
        return persons.SelectMany(p => p.Value);
    }

    public IEnumerable<Person> FindPersons(
        int startAge, int endAge, string town)
    {
        if (!this.personsByTownAndAge.ContainsKey(town))
        {
            return Enumerable.Empty<Person>();
        }

        var persons = this.personsByTownAndAge[town].Range(startAge, true, endAge, true);
        return persons.SelectMany(p => p.Value);
    }
}
