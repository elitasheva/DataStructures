namespace ImplementationOfLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedList<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private class ListNode<T>
        {
            public ListNode(T value)
            {
                this.Value = value;
            }

            public T Value { get; private set; }

            public ListNode<T> NextNode { get; set; }
        }

        private ListNode<T> head;
        private ListNode<T> tail;

        public void Add(T item)
        {
            var newNode = new ListNode<T>(item);
            if (this.Count == 0)
            {
                this.head = this.tail = newNode;
            }
            else
            {
                this.tail.NextNode = newNode;
                this.tail = newNode;
            }
            this.Count++;
        }

        public T Remove(int index)
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Empty list.");
            }
            if (index < 0 || index > this.Count - 1)
            {
               throw new ArgumentOutOfRangeException("Invalid index.");
            }
            T value = default(T);
            var currentNode = this.head;

            if (this.Count == 1)
            {
                value = currentNode.Value;
                this.head = null;
                this.tail = null;
            }
            else
            {
                if (index == 0)
                {
                    value = currentNode.Value;
                    this.head = this.head.NextNode;
                }
                else
                {
                    var count = 0;
                    while (currentNode != null)
                    {
                        if (index - 1 == count)
                        {
                            value = currentNode.NextNode.Value;
                            currentNode.NextNode = currentNode.NextNode.NextNode;
                            if (currentNode.NextNode == null)
                            {
                                this.tail = currentNode;
                                break;
                            }

                        }

                        currentNode = currentNode.NextNode;
                        count++;
                    }
                }
            }
            this.Count--;
            return value;
        }

        public int Count { get; private set; }

        public int FirstIndexOf(T item)
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Empty list.");
            }

            var currentNode = this.head;
            var index = 0;
            var currentIndex = -1;
            while (currentNode != null)
            {
                if (currentNode.Value.CompareTo(item) == 0)
                {
                    currentIndex = index;
                    break;
                }
                index++;
                currentNode = currentNode.NextNode;
            }
            return currentIndex;
        }

        public int LastIndexOf(T item)
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Empty list.");
            }

            var currentNode = this.head;
            var index = 0;
            var currentIndex = -1;
            while (currentNode != null)
            {
                if (currentNode.Value.CompareTo(item) == 0)
                {
                    currentIndex = index;
                }
                index++;
                currentNode = currentNode.NextNode;
            }

            return currentIndex;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
