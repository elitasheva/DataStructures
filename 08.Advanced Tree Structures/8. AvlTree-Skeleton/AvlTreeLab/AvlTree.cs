namespace AvlTreeLab
{
    using System;
    using System.Collections.Generic;

    public class AvlTree<T> where T : IComparable<T>
    {
        private Node<T> root;

        public int Count { get; private set; }

        public void Add(T item)
        {
            var inserted = true;
            if (this.root == null)
            {
                this.root = new Node<T>(item);
            }
            else
            {
                inserted = this.InsertInternal(this.root, item);
            }

            if (inserted)
            {
                this.Count++;
            }
        }

        private bool InsertInternal(Node<T> node, T item)
        {
            var currentNode = node;
            var newNode = new Node<T>(item);
            var shouldRetrace = false;
            while (true)
            {
                if (currentNode.Value.CompareTo(item) > 0)
                {
                    if (currentNode.LeftChild == null)
                    {
                        currentNode.LeftChild = newNode;
                        currentNode.BalanceFactor++;
                        shouldRetrace = currentNode.BalanceFactor != 0;
                        break;
                    }
                    currentNode = currentNode.LeftChild;
                }
                else if (currentNode.Value.CompareTo(item) < 0)
                {
                    if (currentNode.RightChild == null)
                    {
                        currentNode.RightChild = newNode;
                        currentNode.BalanceFactor--;
                        shouldRetrace = currentNode.BalanceFactor != 0;
                        break;
                    }
                    currentNode = currentNode.RightChild;
                }
                else
                {
                    return false;
                }

            }

            if (shouldRetrace)
            {
                this.RetraceInsert(currentNode);
            }

            if (newNode.IsLeftChild)
            {
                this.IncreasePredecessorCountNumbers(currentNode.LeftChild);
            }
            else
            {
                this.IncreasePredecessorCountNumbers(currentNode.RightChild);
            }

            return true;
        }

        private void IncreasePredecessorCountNumbers(Node<T> currentNode)
        {
            if (currentNode != null) 
            {
                var parent = currentNode.Parent;
                while (parent != null)
                {
                    int countLeft = parent.LeftChild != null ? parent.LeftChild.CountNumber : 0;
                    int countRight = parent.RightChild != null ? parent.RightChild.CountNumber : 0;
                    parent.CountNumber = countLeft + 1 + countRight;

                    parent = parent.Parent;
                }
            }
            
        }

        private void RetraceInsert(Node<T> currentNode)
        {
            var parent = currentNode.Parent;
            while (parent != null)
            {
                if (currentNode.IsLeftChild)
                {
                    if (parent.BalanceFactor == 1)
                    {
                        parent.BalanceFactor++;
                        if (currentNode.BalanceFactor == -1)
                        {
                            this.RotateLeft(currentNode);
                        }

                        this.RotateRight(parent);
                        break;
                    }
                    else if (parent.BalanceFactor == -1)
                    {
                        parent.BalanceFactor = 0;
                        break;
                    }
                    else
                    {
                        parent.BalanceFactor = 1;
                    }
                }
                else
                {
                    if (parent.BalanceFactor == -1)
                    {
                        parent.BalanceFactor--;
                        if (currentNode.BalanceFactor == 1)
                        {
                            this.RotateRight(currentNode);
                        }
                        this.RotateLeft(parent);
                        break;
                    }
                    else if (parent.BalanceFactor == 1)
                    {
                        parent.BalanceFactor = 0;
                        break;
                    }
                    else
                    {
                        parent.BalanceFactor = -1;
                    }
                }

                currentNode = parent;
                parent = currentNode.Parent;
            }

        }

        private void RotateRight(Node<T> currentNode)
        {
            var parent = currentNode.Parent;
            var child = currentNode.LeftChild;

            if (parent != null)
            {
                if (currentNode.IsLeftChild)
                {
                    parent.LeftChild = child;
                }
                else
                {
                    parent.RightChild = child;
                }
            }
            else
            {
                this.root = child;
                this.root.Parent = null;
            }
            currentNode.LeftChild = child.RightChild;
            child.RightChild = currentNode;

            currentNode.BalanceFactor += -1 - Math.Max(child.BalanceFactor, 0);
            child.BalanceFactor += -1 + Math.Min(currentNode.BalanceFactor, 0);

            int countLeft = currentNode.LeftChild != null ? currentNode.LeftChild.CountNumber : 0;
            int countRight = currentNode.RightChild != null ? currentNode.RightChild.CountNumber : 0;
            currentNode.CountNumber = countLeft + 1 + countRight;

        }

        private void RotateLeft(Node<T> currentNode)
        {
            var parent = currentNode.Parent;
            var child = currentNode.RightChild;

            if (parent != null)
            {
                if (currentNode.IsLeftChild)
                {
                    parent.LeftChild = child;
                }
                else
                {
                    parent.RightChild = child;
                }
            }
            else
            {
                this.root = child;
                this.root.Parent = null;
            }

            currentNode.RightChild = child.LeftChild;
            child.LeftChild = currentNode;

            currentNode.BalanceFactor += 1 - Math.Min(child.BalanceFactor, 0);
            child.BalanceFactor += 1 + Math.Max(currentNode.BalanceFactor, 0);

            int countLeft = currentNode.LeftChild != null ? currentNode.LeftChild.CountNumber : 0;
            int countRight = currentNode.RightChild != null ? currentNode.RightChild.CountNumber : 0;
            currentNode.CountNumber = countLeft + 1 + countRight;
        }

        public void ForeachDfs(Action<int, T> action)
        {
            if (this.Count == 0)
            {
                return;
            }
            this.InOrderDfs(this.root, 1, action);
        }

        private void InOrderDfs(Node<T> node, int depth, Action<int, T> action)
        {
            if (node.LeftChild != null)
            {
                this.InOrderDfs(node.LeftChild, depth + 1, action);
            }

            action(depth, node.Value);

            if (node.RightChild != null)
            {
                this.InOrderDfs(node.RightChild, depth + 1, action);
            }
        }

        public bool Contains(T item)
        {
            var currentNode = this.root;
            while (currentNode != null)
            {
                if (currentNode.Value.CompareTo(item) < 0)
                {
                    currentNode = currentNode.RightChild;
                }
                else if (currentNode.Value.CompareTo(item) > 0)
                {
                    currentNode = currentNode.LeftChild;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        public List<T> Range(T from, T to)
        {
            var elements = new List<T>();

            if (from.CompareTo(to) > 0)
            {
                throw new InvalidOperationException("Start of the interval must be lesser than the end.");
            }

            this.FindElementsInange(this.root, from, to, elements);

            return elements;
        }

        private void FindElementsInange(Node<T> node, T @from, T to, List<T> elements)
        {
            if (node == null)
            {
                return;
            }

            if (node.Value.CompareTo(from) > 0)
            {
                FindElementsInange(node.LeftChild, from, to, elements);
            }

            if (node.Value.CompareTo(from) >= 0 && node.Value.CompareTo(to) <= 0)
            {
                elements.Add(node.Value);
            }

            if (node.Value.CompareTo(to) < 0)
            {
                FindElementsInange(node.RightChild, from, to, elements);
            }

        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException();
                }
                var currentNode = this.root;
                int sizeOfLeftSubTree = 0;
                int count = index;
                while (currentNode != null)
                {
                    sizeOfLeftSubTree = currentNode.LeftChild != null ? currentNode.LeftChild.CountNumber : 0;
                    if (sizeOfLeftSubTree == count)
                    {
                        return currentNode.Value;
                       
                    }
                    else if (sizeOfLeftSubTree < count)
                    {
                        currentNode = currentNode.RightChild;
                        count -= sizeOfLeftSubTree + 1;
                    }
                    else
                    {
                        currentNode = currentNode.LeftChild;
                    }
                }

                throw new InvalidOperationException();
            }
        }
    }
}
