namespace K_DTree.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class K_DTree<T> : IEnumerable<T>
        where T : ICoordinatable
    {
        private Node<T> root;
        private int level;

        public K_DTree()
        {
            this.root = null;
        }

        public K_DTree(List<T> stars)
        {
            this.InsertionSort(stars);
            this.InsertBalanced(stars);
        }

        public int Count { get; private set; }

        public void Insert(T obj)
        {
            if (this.root == null)
            {
                this.root = new Node<T>(obj, obj.X, obj.Y);
            }
            else
            {
                this.InsertNode(this.root,obj, obj.X, obj.Y, this.level);
            }

            this.Count++;

        }

        private void InsertNode(Node<T> node, T obj, double x, double y, int level)
        {
            if (level % 2 == 0)         //po x
            {
                if (node.X > x)
                {
                    if (node.LeftChild == null)
                    {
                        node.LeftChild = new Node<T>(obj, x, y);
                    }
                    else
                    {
                        this.InsertNode(node.LeftChild, obj, x, y, level + 1);
                    }

                }
                else
                {
                    if (node.RightChild == null)
                    {
                        node.RightChild = new Node<T>(obj, x, y);
                    }
                    else
                    {
                        this.InsertNode(node.RightChild, obj, x, y, level + 1);
                    }

                }
            }
            else if (level % 2 != 0)                       // po y
            {
                if (node.Y > y)
                {
                    if (node.LeftChild == null)
                    {
                        node.LeftChild = new Node<T>(obj, x, y);
                    }
                    else
                    {
                        this.InsertNode(node.LeftChild, obj, x, y, level + 1);
                    }

                }
                else
                {
                    if (node.RightChild == null)
                    {
                        node.RightChild = new Node<T>(obj, x, y);
                    }
                    else
                    {
                        this.InsertNode(node.RightChild, obj, x, y, level + 1);
                    }

                }
            }
        }

        public IEnumerable Range(double centerX, double centerY, double radius)
        {
            if (radius <= 0)
            {
              throw  new InvalidOperationException("Invalid range");
            }

            var elements = new List<T>();

            FindElementsInRange(this.root, centerX, centerY, radius, elements, this.level);

            return elements;
        }

        private void FindElementsInRange(Node<T> node, double centerX, double centerY, double radius, List<T> elements, int level)
        {
            if (node == null)
            {
                 return;
            }

            if (level % 2 == 0)     //po x
            {
                if (node.X > centerX - radius)   //node.X > centerX-radius
                {
                    FindElementsInRange(node.LeftChild,centerX,centerY,radius,elements,level+1);
                }
                
                if (node.X < centerX + radius)
                {
                    FindElementsInRange(node.RightChild, centerX, centerY, radius, elements, level + 1);
                }

                if (((node.X - centerX)*(node.X - centerX))+((node.Y - centerY)*(node.Y - centerY))<=radius*radius)
                {
                     elements.Add(node.Value);
                }
            }
            else
            {
                if (node.Y > centerY - radius)   // node.Y > centerY-radius
                {
                    FindElementsInRange(node.LeftChild, centerX, centerY, radius, elements, level + 1);
                }
                
                if(node.Y < centerY + radius)
                {
                    FindElementsInRange(node.RightChild, centerX, centerY, radius, elements, level + 1);
                }

                if (((node.X - centerX) * (node.X - centerX)) + ((node.Y - centerY) * (node.Y - centerY)) <= radius * radius)
                {
                    elements.Add(node.Value);
                }
            }


        }

        private void InsertionSort(List<T> items)
        {
            for (int i = 1; i < items.Count; i++)
            {
                var currentObject = items[i];
                int j = i - 1;

                while (j >= 0 && items[j].X > currentObject.X)
                {
                    items[j + 1] = items[j];
                    j--;
                }

                items[j + 1] = currentObject;
            }
        }

        private void InsertBalanced(List<T> stars)
        {
            var medianIndex = stars.Count / 2;
            this.Insert(stars[medianIndex]);
            for (int i = 0; i < medianIndex; i++)
            {
                this.Insert(stars[i]);
            }

            for (int i = medianIndex + 1; i < stars.Count; i++)
            {
                this.Insert(stars[i]);
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
