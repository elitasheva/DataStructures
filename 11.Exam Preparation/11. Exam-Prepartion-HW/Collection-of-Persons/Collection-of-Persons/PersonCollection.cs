using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class PersonCollection : IPersonCollection
{
    private readonly Dictionary<string, Person> personsByEmail;
    private readonly Dictionary<string, SortedSet<Person>> personsByDomain;
    private readonly Dictionary<string, SortedSet<Person>> personsByNameAndTown;
    private readonly OrderedDictionary<int, SortedSet<Person>> personsByAge;
    private readonly Dictionary<string, OrderedDictionary<int, SortedSet<Person>>> personsByTownAndAge;


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
        if (this.personsByEmail.ContainsKey(email))
        {
            return false;
        }

        var newPerson = new Person(email, name, age, town);
        this.personsByEmail[email] = newPerson;

        var domain = GetDomain(email);
        if (!this.personsByDomain.ContainsKey(domain))
        {
            this.personsByDomain[domain] = new SortedSet<Person>();
        }
        this.personsByDomain[domain].Add(newPerson);

        var keyNameTown = name + town;
        if (!this.personsByNameAndTown.ContainsKey(keyNameTown))
        {
            this.personsByNameAndTown[keyNameTown] = new SortedSet<Person>();
        }
        this.personsByNameAndTown[keyNameTown].Add(newPerson);

        if (!this.personsByAge.ContainsKey(age))
        {
            this.personsByAge[age] = new SortedSet<Person>();
        }
        this.personsByAge[age].Add(newPerson);

        if (!this.personsByTownAndAge.ContainsKey(town))
        {
            this.personsByTownAndAge[town] = new OrderedDictionary<int, SortedSet<Person>>();
        }

        if (!this.personsByTownAndAge[town].ContainsKey(age))
        {
            this.personsByTownAndAge[town][age] = new SortedSet<Person>();
        }
        this.personsByTownAndAge[town][age].Add(newPerson);

        return true;
    }

    private string GetDomain(string email)
    {
        return email.Substring(email.IndexOf("@") + 1);
    }

    public int Count
    {
        get { return this.personsByEmail.Count; }
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
        if (!this.personsByEmail.ContainsKey(email))
        {
            return false;
        }

        var personForDelete = this.personsByEmail[email];
        this.personsByEmail.Remove(email);

        var domain = GetDomain(personForDelete.Email);
        this.personsByDomain[domain].Remove(personForDelete);

        var keyNameAndTown = personForDelete.Name + personForDelete.Town;
        this.personsByNameAndTown[keyNameAndTown].Remove(personForDelete);

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
        var keyNameTown = name + town;
        if (!this.personsByNameAndTown.ContainsKey(keyNameTown))
        {
            return Enumerable.Empty<Person>();
        }
        return this.personsByNameAndTown[keyNameTown];
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        return this.personsByAge.Range(startAge, true, endAge, true).SelectMany(p => p.Value);
    }

    public IEnumerable<Person> FindPersons(
        int startAge, int endAge, string town)
    {
        if (!this.personsByTownAndAge.ContainsKey(town))
        {
            return Enumerable.Empty<Person>();
        }

        return this.personsByTownAndAge[town].Range(startAge, true, endAge, true).SelectMany(p => p.Value);
    }
}
