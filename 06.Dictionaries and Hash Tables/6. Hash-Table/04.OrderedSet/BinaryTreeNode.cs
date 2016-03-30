namespace OrderedSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    public class BinaryTreeNode<T> : IEnumerable<T>
    {
        public BinaryTreeNode(T value, BinaryTreeNode<T> leftChild = null, BinaryTreeNode<T> rightChild = null)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public T Value { get; set; }

        public BinaryTreeNode<T> Parent { get; set; }

        public BinaryTreeNode<T> LeftChild { get; set; }

        public BinaryTreeNode<T> RightChild { get; set; }

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
