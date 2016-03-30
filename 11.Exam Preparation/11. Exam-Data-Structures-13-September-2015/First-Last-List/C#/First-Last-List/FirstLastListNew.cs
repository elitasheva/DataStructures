namespace First_Last_List
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class FirstLastListNew<T> : IFirstLastList<T>
        where T : IComparable<T>
    {
        private readonly BigList<T> list;
        private readonly OrderedDictionary<T, List<int>> listByIndex;
        private int index;

        public FirstLastListNew()
        {
            this.list = new BigList<T>();
            this.listByIndex = new OrderedDictionary<T, List<int>>();
        } 

        public void Add(T element)
        {
            this.list.Add(element);

            if (!this.listByIndex.ContainsKey(element))
            {
                this.listByIndex[element] = new List<int>();
            }
            this.listByIndex[element].Add(this.index);
            this.index++;
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
            return this.list
                .Skip(this.Count - count)
                .Take(count)
                .Reverse();
        }

        public IEnumerable<T> Min(int count)
        {
            this.ValicateCount(count);

            var elements = this.listByIndex
                .SelectMany(a => a.Value)
                .Select(i => this.list[i])
                .Take(count);
            return elements;
        }

        public IEnumerable<T> Max(int count)
        {
            this.ValicateCount(count);

            var elements = this.listByIndex
                .Reverse()
                .SelectMany(a => a.Value)
                .Select(i => this.list[i])
                .Take(count);
            return elements;
        }

        public void Clear()
        {
            this.list.Clear();
            this.listByIndex.Clear();
            this.index = 0;
        }

        public int RemoveAll(T element)
        {
            if (!this.listByIndex.ContainsKey(element))
            {
                return 0;
            }

            var indeces = this.listByIndex[element];
            foreach (var index in indeces)
            {
               this.list.RemoveAt(index); 
            }
            this.listByIndex.Remove(element);
            return indeces.Count;
        }

        private void ValicateCount(int count)
        {
            if (this.Count < count)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
