using System;

public class CircularQueue<T>
{
    private const int InitialCapacity = 16;
    private int capacity;
    private T[] arr;
    private int startIndex = 0;
    private int endIndex = 0;

    public int Count { get; private set; }

    public CircularQueue()
        :this (InitialCapacity)
    {
        
    }

    public CircularQueue(int capacity)
    {
        this.capacity = capacity;
        this.arr = new T[capacity];
    }

    public void Enqueue(T element)
    {
        if (this.Count >= this.arr.Length)
        {
            this.Grow();
        }
        this.arr[this.endIndex] = element;
        this.endIndex = (this.endIndex + 1) % this.arr.Length;
        this.Count++;
    }

    private void Grow()
    {
        var newCapacity = 2 * this.arr.Length;
        T[] newArr = new T[newCapacity];
        this.CopyAllElementsTo(newArr);
        this.arr = newArr;
        this.startIndex = 0;
        this.endIndex = this.Count;
    }

    private void CopyAllElementsTo(T[] newArr)
    {
        int souceIndex = this.startIndex;
        int destinationIndex = 0;
        for (int i = 0; i < this.Count; i++)
        {
            newArr[destinationIndex] = this.arr[souceIndex];
            souceIndex = (souceIndex + 1) % this.arr.Length;
            destinationIndex++;
        }
    }

    public T Dequeue()
    {
        if (this.Count == 0)
        {
             throw new InvalidOperationException("The queue is empty.");
        }
        var element = this.arr[this.startIndex];
        this.startIndex = (this.startIndex + 1) % this.arr.Length;
        this.Count--;

        return element;
    }

    public T[] ToArray()
    {
        T[] newArray = new T[this.Count];
        this.CopyAllElementsTo(newArray);
        return newArray;
    }
}


class Example
{
    static void Main()
    {
        var queue = new CircularQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);
        queue.Enqueue(6);

        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        var first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-7);
        queue.Enqueue(-8);
        queue.Enqueue(-9);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-10);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");
    }
}
