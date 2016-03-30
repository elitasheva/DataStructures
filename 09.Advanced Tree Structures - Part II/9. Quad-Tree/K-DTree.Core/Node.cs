namespace K_DTree.Core
{
    using System.Collections;
    using System.Collections.Generic;

    public class Node<T> : IEnumerable<T>
    {
        private Node<T> leftChild;
        private Node<T> rightChild;

        public Node(T value,double x, double y)
        {
            this.Value = value;
            this.X = x;
            this.Y = y;
        }

        public T Value { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        public Node<T> LeftChild
        {
            get
            {
                return this.leftChild;
            }
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
