namespace OrderedSetWithAVL
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class OrderedSetWithAVL<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private Node<T> root;

        public OrderedSetWithAVL()
        {
            this.root = null;
            this.Count = 0;
        }

        public int Count { get; set; }

        public void Add(T element)
        {
            if (this.root == null)
            {
                this.root = new Node<T>(element);
                this.Count++;
            }
            else
            {
                var currentNode = this.root;
                var newNode = new Node<T>(element);
                bool needRebalancing = false;
                while (true)
                {
                    if (currentNode.Value.CompareTo(element) < 0)   //go to the right
                    {
                        if (currentNode.RightChild == null)
                        {
                            currentNode.RightChild = newNode;
                            currentNode.BalanceFactor--;
                            needRebalancing = currentNode.BalanceFactor != 0;
                            this.Count++;
                            break;
                        }
                        currentNode = currentNode.RightChild;
                    }
                    else if (currentNode.Value.CompareTo(element) > 0)    //go to the left
                    {
                        if (currentNode.LeftChild == null)
                        {
                            currentNode.LeftChild = newNode;
                            currentNode.BalanceFactor++;
                            needRebalancing = currentNode.BalanceFactor != 0;
                            this.Count++;
                            break;
                        }
                        currentNode = currentNode.LeftChild;
                    }
                    else
                    {
                        break;
                    }
                }
                if (needRebalancing)
                {
                    this.PerformRebalancingAfterInsertNode(currentNode);
                }
            }

        }

        private void PerformRebalancingAfterInsertNode(Node<T> currentNode)
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
                            this.PerformLeftRotation(currentNode);
                        }

                        this.PerformRightRotation(parent);
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
                            this.PerformRightRotation(currentNode);
                        }

                        this.PerformLeftRotation(parent);
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

        private void PerformRightRotation(Node<T> currentNode)
        {
            var parent = currentNode.Parent;
            var child = currentNode.LeftChild;
            if (parent != null)
            {
                if (currentNode.IsRightChild)
                {
                    parent.RightChild = child;
                }
                else
                {
                    parent.LeftChild = child;
                }
            }
            else
            {
                this.root = child;
                this.root.Parent = null;
            }

            currentNode.LeftChild = child.RightChild;
            child.RightChild = currentNode;

            //currentNode.BalanceFactor -= 1 - Math.Max(child.BalanceFactor, 0);
            //child.BalanceFactor -= 1 + Math.Min(currentNode.BalanceFactor, 0);

            currentNode.BalanceFactor += -1 - Math.Max(child.BalanceFactor, 0);
            child.BalanceFactor += -1 + Math.Min(currentNode.BalanceFactor, 0);
        }

        private void PerformLeftRotation(Node<T> currentNode)
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
        }

        public bool Contains(T element)
        {
            var currentNode = this.root;
            while (currentNode != null)
            {
                if (currentNode.Value.CompareTo(element) < 0)
                {
                    currentNode = currentNode.RightChild;
                }
                else if (currentNode.Value.CompareTo(element) > 0)
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

        public void Remove(T element)
        {
            var nodeForDelete = this.FindNode(element);
            if (nodeForDelete != null)
            {
                this.DeleteNode(nodeForDelete);
                this.Count--;
            }
        }

        private void DeleteNode(Node<T> nodeForDelete)
        {
            bool needRebalancing = false;
            if (nodeForDelete.LeftChild != null && nodeForDelete.RightChild != null)
            {
                //var nodeForRepleace = nodeForDelete.RightChild;
                //var nodeForRepleace = nodeForDelete.LeftChild;
                //while (nodeForRepleace.LeftChild != null)
                //{
                //    nodeForRepleace = nodeForRepleace.LeftChild;
                //}
                var nodeForRepleace = this.FindLargestNode(nodeForDelete);

                //if (nodeForDelete != this.root)
                //{
                //    if (nodeForDelete.IsLeftChild)
                //    {
                //        nodeForDelete.Parent.BalanceFactor++;
                //        needRebalancing = nodeForDelete.Parent.BalanceFactor > 1;
                //    }
                //    else
                //    {
                //        nodeForDelete.Parent.BalanceFactor--;
                //        needRebalancing = nodeForDelete.Parent.BalanceFactor > -1;
                //    }
                //}
                
                nodeForDelete.Value = nodeForRepleace.Value;
                nodeForDelete = nodeForRepleace;
            }

            Node<T> childNode = nodeForDelete.LeftChild ?? nodeForDelete.RightChild;

            if (childNode != null)
            {
                childNode.Parent = nodeForDelete.Parent;
                if (nodeForDelete.Parent == null)
                {
                    this.root = childNode;
                    this.root.BalanceFactor = 0;
                }
                else
                {
                    if (nodeForDelete.IsLeftChild)
                    {
                        nodeForDelete.Parent.LeftChild = childNode;
                        nodeForDelete.Parent.BalanceFactor--;
                        needRebalancing = nodeForDelete.Parent.BalanceFactor > 1;
                    }
                    else
                    {
                        nodeForDelete.Parent.RightChild = childNode;
                        nodeForDelete.Parent.BalanceFactor++;
                        needRebalancing = nodeForDelete.Parent.BalanceFactor > -1;
                    }
                }
            }
            else
            {
                if (nodeForDelete.Parent == null)
                {
                    this.root = null;
                }
                else
                {
                    if (nodeForDelete.IsLeftChild)
                    {
                        nodeForDelete.Parent.LeftChild = null;
                        nodeForDelete.Parent.BalanceFactor--;
                        needRebalancing = nodeForDelete.Parent.BalanceFactor > 1;
                    }

                    if (nodeForDelete.IsRightChild)
                    {
                        nodeForDelete.Parent.RightChild = null;
                        nodeForDelete.Parent.BalanceFactor++;
                        needRebalancing = nodeForDelete.Parent.BalanceFactor > -1;
                    }
                    
                }
            }

            if (needRebalancing)
            {
                this.PerformRebalancingAfterDeleteNode(nodeForDelete.Parent);
            }
        }

        private Node<T> FindLargestNode(Node<T> currentNode)
        {
            var node = currentNode.LeftChild;
            if (node != null)
            {
                while (node.RightChild != null)
                {
                    node = node.RightChild;
                }
            }
            return node;
        }

        private void PerformRebalancingAfterDeleteNode(Node<T> currentNode)
        {
            var parent = currentNode.Parent;
            while (parent != null)
            {
                if (currentNode.IsLeftChild)
                {
                    if (parent.BalanceFactor == 2)
                    {
                        if (currentNode.BalanceFactor == -1)
                        {
                            this.PerformLeftRotation(currentNode);
                        }

                        this.PerformRightRotation(parent);
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
                    if (parent.BalanceFactor == -2)
                    {  
                        if (currentNode.BalanceFactor == 1)
                        {
                            this.PerformRightRotation(currentNode);
                        }
                        this.PerformLeftRotation(parent);
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

        private Node<T> FindNode(T element)
        {
            var currentElement = this.root;
            Node<T> node = null;
            while (currentElement != null)
            {
                if (currentElement.Value.CompareTo(element) < 0)
                {
                    currentElement = currentElement.RightChild;
                }
                else if (currentElement.Value.CompareTo(element) > 0)
                {
                    currentElement = currentElement.LeftChild;
                }
                else
                {
                    node = currentElement;
                    break;
                }
            }

            return node;
        }
    }
}
