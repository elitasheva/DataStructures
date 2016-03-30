namespace OrderedSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class OrderedSet<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private BinaryTreeNode<T> root;

        public OrderedSet()
        {
            this.root = null;
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Add(T element)
        {
            if (this.Contains(element))
            {
                throw new ArgumentException("The element already exists:" + element);
            }
            if (this.Count == 0)
            {
                this.root = new BinaryTreeNode<T>(element);
            }
            else if (element.CompareTo(this.root.Value) < 0)
            {
                this.AddLeftChild(element, this.root);
            }
            else if (element.CompareTo(this.root.Value) > 0)
            {
                this.AddRightChild(element, this.root);
            }

            this.Count++;
        }

        private void AddRightChild(T element, BinaryTreeNode<T> currentNode)
        {
            if (currentNode.RightChild == null)
            {
                var newNode = new BinaryTreeNode<T>(element);
                currentNode.RightChild = newNode;
                newNode.Parent = currentNode;
            }
            else if (element.CompareTo(currentNode.RightChild.Value) < 0)
            {
                this.AddLeftChild(element, currentNode.RightChild);
            }
            else if (element.CompareTo(currentNode.RightChild.Value) > 0)
            {
                this.AddRightChild(element, currentNode.RightChild);
            }
        }

        private void AddLeftChild(T element, BinaryTreeNode<T> currentNode)
        {
            if (currentNode.LeftChild == null)
            {
                var newNode = new BinaryTreeNode<T>(element);
                currentNode.LeftChild = newNode;
                newNode.Parent = currentNode;
            }
            else if (element.CompareTo(currentNode.LeftChild.Value) < 0)
            {
                this.AddLeftChild(element, currentNode.LeftChild);
            }
            else
            {
                this.AddRightChild(element, currentNode.LeftChild);
            }
        }

        public bool Contains(T element)
        {
            var node = this.FindNode(element);
            return node != null;
        }

        private BinaryTreeNode<T> FindNode(T element)
        {
            var currentNode = this.root;
            while (currentNode != null)
            {
                if (element.CompareTo(currentNode.Value) < 0)
                {
                    currentNode = currentNode.LeftChild;
                }
                else if (element.CompareTo(currentNode.Value) > 0)
                {
                    currentNode = currentNode.RightChild;
                }
                else
                {
                    break;
                }
            }

            return currentNode;
        }

        public void Remove(T element)
        {
            var node = this.FindNode(element);
            if (node != null)
            {
                this.DeleteNode(node);
                this.Count--;
            }
        }

        private void DeleteNode(BinaryTreeNode<T> node)
        {
            if (node.LeftChild != null && node.RightChild != null)
            {
                var nodForRepleace = node.RightChild;
                while (nodForRepleace.LeftChild != null)
                {
                    nodForRepleace = nodForRepleace.LeftChild;
                }

                node.Value = nodForRepleace.Value;
                node = nodForRepleace;
            }

            BinaryTreeNode<T> childNode = node.LeftChild ?? node.RightChild;

            if (childNode != null)
            {
                childNode.Parent = node.Parent;
                if (node.Parent == null)
                {
                    this.root = childNode;
                }
                else
                {
                    if (node.Parent.LeftChild == node)
                    {
                        node.Parent.LeftChild = childNode;
                    }
                    if (node.Parent.RightChild == node)
                    {
                        node.Parent.RightChild = childNode;
                    }
                }
            }
            else
            {
                if (node.Parent == null)
                {
                    this.root = null;
                }
                else
                {
                    if (node.Parent.LeftChild == node)
                    {
                        node.Parent.LeftChild = null;
                    }
                    if (node.Parent.RightChild == node)
                    {
                        node.Parent.RightChild = null;
                    }
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (this.root == null)
            {
                return Enumerable.Empty<T>().GetEnumerator();
            }

            return this.root.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
