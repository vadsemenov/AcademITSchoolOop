using System;
using System.Collections.Generic;

namespace TreeTask
{
    public class BinarySearchTree<T>
    {
        private readonly Node<T> _root;
        private readonly IComparer<T> _comparer;

        public int Count => WalkSubTreeInDepth(_root);

        public BinarySearchTree(T rootValue)
        {
            _root = new Node<T>(rootValue);
        }

        public BinarySearchTree(T rootValue, Comparer<T> comparer)
        {
            _root = new Node<T>(rootValue);
            _comparer = comparer;
        }

        private int Compare(T value1, T value2)
        {
            if (_comparer != null)
            {
                return _comparer.Compare(value1, value2);
            }
            else
            {
                if (value1 == null && value2 != null)
                {
                    return -1;
                }

                if (value1 != null && value2 == null)
                {
                    return 1;
                }

                if (value1 == null)
                {
                    return 0;
                }

                if (value1 is IComparable<T> comparableValue1)
                {
                    return comparableValue1.CompareTo(value2);
                }
                else
                {
                    throw new ArgumentException($"Тип {typeof(T).Name} не реализует IComparable!", typeof(T).Name);
                }
            }
        }

        public void Insert(T value)
        {
            InsertNode(value, _root);
        }

        private Node<T> InsertNode(T value, Node<T> parentNode)
        {
            var newNode = new Node<T>(value);
            var currentTempNode = parentNode;

            while (true)
            {
                if (Compare(currentTempNode.Value, value) > 0)
                {
                    if (currentTempNode.Left == null)
                    {
                        currentTempNode.Left = newNode;
                        return newNode;
                    }

                    currentTempNode = currentTempNode.Left;

                    continue;
                }

                if (Compare(currentTempNode.Value, value) <= 0)
                {
                    if (currentTempNode.Right == null)
                    {
                        currentTempNode.Right = newNode;
                        return newNode;
                    }

                    currentTempNode = currentTempNode.Right;
                }
            }
        }

        private Node<T> InsertNodeRecursive(T value, Node<T> parentNode)
        {
            if (Compare(parentNode.Value, value) > 0)
            {
                if (parentNode.Left == null)
                {
                    parentNode.Left = new Node<T>(value);
                    return parentNode.Left;
                }

                return InsertNodeRecursive(value, parentNode.Left);
            }

            if (Compare(parentNode.Value, value) <= 0)
            {
                if (parentNode.Right == null)
                {
                    parentNode.Right = new Node<T>(value);
                    return parentNode.Right;
                }

                return InsertNodeRecursive(value, parentNode.Right);
            }

            return parentNode;
        }

        public bool Search(T value)
        {
            return SearchNode(value, null, _root).currentNode != null;
        }

        private (Node<T> parentNode, Node<T> currentNode) SearchNode(T value, Node<T> parentNode, Node<T> node)
        {
            var parentTempNode = parentNode;
            var currentTempNode = node;

            while (true)
            {
                if (Compare(currentTempNode.Value, value) == 0)
                {
                    return (parentTempNode, currentTempNode);
                }

                if (Compare(currentTempNode.Value, value) > 0)
                {
                    if (currentTempNode.Left == null)
                    {
                        return (currentTempNode, null);
                    }

                    parentTempNode = currentTempNode;
                    currentTempNode = currentTempNode.Left;

                    continue;
                }

                if (Compare(currentTempNode.Value, value) < 0)
                {
                    if (currentTempNode.Right == null)
                    {
                        return (currentTempNode, null);
                    }

                    parentTempNode = currentTempNode;
                    currentTempNode = currentTempNode.Right;
                }
            }
        }

        public void WalkInDepthRecursive()
        {
            WalkSubTreeInDepthRecursive(_root);
        }

        private void WalkSubTreeInDepthRecursive(Node<T> node)
        {
            Console.Write(node.Value + " ");

            if (node.Left == null && node.Right == null)
            {
                return;
            }

            if (node.Left != null)
            {
                WalkSubTreeInDepthRecursive(node.Left);
            }

            if (node.Right != null)
            {
                WalkSubTreeInDepthRecursive(node.Right);
            }
        }

        public void WalkInBreadth()
        {
            WalkSubTreeInBreadth(_root);
        }

        private int WalkSubTreeInBreadth(Node<T> node)
        {
            var count = 0;

            var visited = new Queue<Node<T>>();
            visited.Enqueue(node);

            while (visited.Count > 0)
            {
                var currentNode = visited.Dequeue();
                count++;

                Console.Write(currentNode.Value + " ");

                if (currentNode.Left != null)
                {
                    visited.Enqueue(currentNode.Left);
                }

                if (currentNode.Right != null)
                {
                    visited.Enqueue(currentNode.Right);
                }
            }

            return count;
        }

        public void WalkInDepth()
        {
            WalkSubTreeInDepth(_root);
        }

        public int WalkSubTreeInDepth(Node<T> node)
        {
            var count = 0;

            var visited = new Stack<Node<T>>();
            visited.Push(node);

            while (visited.Count > 0)
            {
                var currentNode = visited.Pop();
                count++;

                Console.Write(currentNode.Value + " ");

                if (currentNode.Right != null)
                {
                    visited.Push(currentNode.Right);
                }

                if (currentNode.Left != null)
                {
                    visited.Push(currentNode.Left);
                }
            }

            return count;
        }

        public bool Remove(T value)
        {
            var parentAndCurrentNodesPair = SearchNode(value, null, _root);

            if (parentAndCurrentNodesPair.currentNode == null)
            {
                return false;
            }

            return RemoveNode(parentAndCurrentNodesPair.parentNode, parentAndCurrentNodesPair.currentNode);
        }

        private bool RemoveNode(Node<T> parentNode, Node<T> currentNode)
        {
            //If leaf
            if (currentNode.Right == null && currentNode.Left == null)
            {
                if (parentNode.Left == currentNode)
                {
                    parentNode.Left = null;
                }

                if (parentNode.Right == currentNode)
                {
                    parentNode.Right = null;
                }

                return true;
            }

            //If 1 child
            if (currentNode.Right == null)
            {
                if (parentNode.Left == currentNode)
                {
                    parentNode.Left = currentNode.Left;
                }

                if (parentNode.Right == currentNode)
                {
                    parentNode.Right = currentNode.Left;
                }

                return true;
            }

            //If 1 child
            if (currentNode.Left == null)
            {
                if (parentNode.Left == currentNode)
                {
                    parentNode.Left = currentNode.Right;
                }

                if (parentNode.Right == currentNode)
                {
                    parentNode.Right = currentNode.Right;
                }

                return true;
            }

            // if all child nodes is not null
            var minNodeOfSubtree = FindSubTreeMinNode(currentNode, currentNode.Right);

            return ReplaceNode(parentNode, currentNode, minNodeOfSubtree);
        }

        private Node<T> FindSubTreeMinNode(Node<T> parentNode, Node<T> rootNode)
        {
            var parentTempNode = parentNode;
            var minNode = rootNode;

            while (minNode.Left != null)
            {
                parentTempNode = minNode;
                minNode = minNode.Left;
            }

            if (minNode.Right != null)
            {
                if (parentTempNode.Right == minNode)
                {
                    parentTempNode.Right = minNode.Right;
                }

                if (parentTempNode.Left == minNode)
                {
                    parentTempNode.Left = minNode.Right;
                }
            }

            minNode.Right = null;

            return minNode;
        }

        private bool ReplaceNode(Node<T> parentNode, Node<T> replaceableNode, Node<T> replacementNode)
        {
            replacementNode.Left = replaceableNode.Left;
            replacementNode.Right = replaceableNode.Right;

            if (parentNode.Right == replaceableNode)
            {
                parentNode.Right = replacementNode;
            }

            if (parentNode.Left == replaceableNode)
            {
                parentNode.Left = replacementNode;
            }

            return true;
        }
    }
}