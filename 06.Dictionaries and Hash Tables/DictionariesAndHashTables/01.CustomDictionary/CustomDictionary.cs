namespace CustomDictionary
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Net.Http.Headers;

    public class CustomDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private Hashtable repo;

        public CustomDictionary()
        {
            this.repo = new Hashtable();
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Add(TKey key, TValue value)
        {
            if (this.repo.Contains(key))
            {
                throw new ArgumentException("The key already exists:" + key);
            }

            this.repo.Add(key, value);
            this.Count++;
        }

        public TValue GetValue(TKey key)
        {
            if (!this.repo.Contains(key))
            {
                throw new KeyNotFoundException("Key not found:" + key);
            }

            return (TValue)this.repo[key];
        }

        public bool AddOrRepleace(TKey key, TValue value)
        {
            if (!this.repo.Contains(key))
            {
                this.repo.Add(key, value);
                this.Count++;
                return true;
            }
            else
            {
                this.repo[key] = value;
                return false;
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (!this.repo.Contains(key))
            {
                value = default(TValue);
                return false;
            }

            value = (TValue)this.repo[key];
            return true;
        }

        public KeyValuePair<TKey, TValue> Find(TKey key)
        {
            if (this.repo.Contains(key))
            {
                return new KeyValuePair<TKey, TValue>(key, (TValue)this.repo[key]);
            }

            return default(KeyValuePair<TKey, TValue>);
        }

        public bool ConstainsKey(TKey key)
        {
            if (this.repo.Contains(key))
            {
                return true;
            }

            return false;
        }

        public bool Remove(TKey key)
        {
            if (this.repo.Contains(key))
            {
                this.repo.Remove(key);
                this.Count--;
                return true;
            }

            return false;
        }

        public void Clear()
        {
            this.repo.Clear();
            this.Count = 0;
        }

        public TValue this[TKey key]
        {
            get
            {
                return this.GetValue(key);
            }
            set
            {
                this.AddOrRepleace(key, value);
            }
        }

        public ICollection Keys
        {
            get
            {
                return this.repo.Keys;
            }
        }

        public ICollection Values
        {
            get
            {
                return this.repo.Values;
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (KeyValuePair<TKey, TValue> pair in this.repo)
            {
                yield return pair;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
