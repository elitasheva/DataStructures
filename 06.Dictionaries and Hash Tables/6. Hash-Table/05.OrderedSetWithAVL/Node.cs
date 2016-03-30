namespace OrderedSetWithAVL
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Node<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private Node<T> leftChild;
        private Node<T> rightChild;
            
        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public Node<T> LeftChild
        {
            get { return this.leftChild; }
            set
            {
                if (value != null)
                {
                    value.Parent = this;
                }

                this.leftChild = value;
            }
        }

        public Node<T> RightChild
        {
            get { return this.rightChild; }
            set
            {
                if (value != null)
                {
                    value.Parent = this;
                }

                this.rightChild = value;
            }
        }

        public Node<T> Parent { get; set; }

        public bool IsRightChild
        {
            get
            {
                if (this.Parent != null)
                {
                    return this.Parent.RightChild == this;
                }
                return false;
            }

        }

        public bool IsLeftChild
        {
            get
            {
                if (this.Parent != null)
                {
                    return this.Parent.LeftChild == this;
                }
                return false;
            }
        }

        public int BalanceFactor { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            if (this.LeftChild != null)
            {
                foreach (var child in this.LeftChild)
                {
                    yield return child;
                }
            }

            yield return this.Value;

            if (this.RightChild != null)
            {
                foreach (var child in this.RightChild)
                {
                    yield return child;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
