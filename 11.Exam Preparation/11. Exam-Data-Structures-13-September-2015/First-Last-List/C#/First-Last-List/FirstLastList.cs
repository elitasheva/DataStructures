using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class FirstLastList<T> : IFirstLastList<T>
    where T : IComparable<T>
{
    private readonly LinkedList<T> list;
    private readonly OrderedDictionary<T, List<LinkedListNode<T>>> listByNodes;

    public FirstLastList()
    {
        this.list = new LinkedList<T>();
        this.listByNodes = new OrderedDictionary<T, List<LinkedListNode<T>>>();
    }

    public void Add(T newElement)
    {
        var node = this.list.AddLast(newElement);
        if (!this.listByNodes.ContainsKey(newElement))
        {
            this.listByNodes[newElement] = new List<LinkedListNode<T>>();
        }
        this.listByNodes[newElement].Add(node);
    }

    public int Count
    {
        get { return this.list.Count; }
    }

    public IEnumerable<T> First(int count)
    {
        this.ValicateCount(count);
        return this.list.Take(count);
    }


    public IEnumerable<T> Last(int count)
    {
        this.ValicateCount(count);
        return this.list.Skip(this.Count - count).Take(count).Reverse();
    }

    public IEnumerable<T> Min(int count)
    {
        this.ValicateCount(count);
        return this.listByNodes
            .SelectMany(n => n.Value)
            .Select(n => n.Value)
            .Take(count);
    }

    public IEnumerable<T> Max(int count)
    {
        this.ValicateCount(count);
        return this.listByNodes
            .Reverse()
            .SelectMany(n => n.Value)
            .Select(n => n.Value)
            .Take(count);
    }

    public int RemoveAll(T element)
    {
        if (!this.listByNodes.ContainsKey(element))
        {
            return 0;
        }

        var elementsForDelete = this.listByNodes[element];
        foreach (var el in elementsForDelete)
        {
            this.list.Remove(el);
        }

        this.listByNodes.Remove(element);
        return elementsForDelete.Count;
    }

    public void Clear()
    {
        this.list.Clear();
        this.listByNodes.Clear();
    }

    private void ValicateCount(int count)
    {
        if (this.Count < count)
        {
            throw new ArgumentOutOfRangeException();
        }
    }
}
