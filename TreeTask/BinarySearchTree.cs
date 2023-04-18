namespace TreeTask
{
#nullable disable

    internal class BinarySearchTree<T>
    {
        private Node<T> _root;
        private readonly IComparer<T> _comparer;

        public int Count { get; private set; }

        public BinarySearchTree()
        {
        }

        public BinarySearchTree(IComparer<T> comparer)
        {
            _comparer = comparer;
        }

        private int Compare(T value1, T value2)
        {
            if (_comparer != null)
            {
                return _comparer.Compare(value1, value2);
            }

            if (value1 == null && value2 == null)
            {
                return 0;
            }

            if (value1 == null)
            {
                return -1;
            }

            if (value2 == null)
            {
                return 1;
            }

            if (value1 is IComparable<T> comparableValue1)
            {
                return comparableValue1.CompareTo(value2);
            }

            throw new ArgumentException($"Тип {typeof(T).Name} не реализует IComparable!", typeof(T).Name);
        }

        public void Insert(T value)
        {
            if (_root == null)
            {
                _root = new Node<T>(value);
                Count++;
                return;
            }

            var newNode = new Node<T>(value);
            var currentNode = _root;

            while (true)
            {
                var compareResult = Compare(currentNode.Value, value);

                if (compareResult > 0)
                {
                    if (currentNode.Left == null)
                    {
                        currentNode.Left = newNode;
                        Count++;
                        return;
                    }

                    currentNode = currentNode.Left;
                }
                else
                {
                    if (currentNode.Right == null)
                    {
                        currentNode.Right = newNode;
                        Count++;
                        return;
                    }

                    currentNode = currentNode.Right;
                }
            }
        }

        public bool Search(T value)
        {
            if (_root == null)
            {
                return false;
            }

            return SearchNode(value).CurrentNode != null;
        }

        private (Node<T> ParentNode, Node<T> CurrentNode) SearchNode(T value)
        {
            Node<T> currentNodeParent = null;
            var currentNode = _root;

            while (true)
            {
                var compareResult = Compare(currentNode.Value, value);

                if (compareResult == 0)
                {
                    return (currentNodeParent, currentNode);
                }

                if (compareResult > 0)
                {
                    if (currentNode.Left == null)
                    {
                        return (currentNode, null);
                    }

                    currentNodeParent = currentNode;
                    currentNode = currentNode.Left;
                }
                else
                {
                    if (currentNode.Right == null)
                    {
                        return (currentNode, null);
                    }

                    currentNodeParent = currentNode;
                    currentNode = currentNode.Right;
                }
            }
        }

        public void WalkInDepthRecursive(Action<T> action)
        {
            if (_root == null)
            {
                return;
            }

            WalkSubTreeInDepthRecursive(_root, action);
        }

        private static void WalkSubTreeInDepthRecursive(Node<T> node, Action<T> action)
        {
            action.Invoke(node.Value);

            if (node.Left != null)
            {
                WalkSubTreeInDepthRecursive(node.Left, action);
            }

            if (node.Right != null)
            {
                WalkSubTreeInDepthRecursive(node.Right, action);
            }
        }

        public void WalkInBreadth(Action<T> action)
        {
            if (_root == null)
            {
                return;
            }

            var queue = new Queue<Node<T>>();
            queue.Enqueue(_root);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();

                action.Invoke(currentNode.Value);

                if (currentNode.Left != null)
                {
                    queue.Enqueue(currentNode.Left);
                }

                if (currentNode.Right != null)
                {
                    queue.Enqueue(currentNode.Right);
                }
            }
        }

        public void WalkInDepth(Action<T> action)
        {
            if (_root == null)
            {
                return;
            }

            var stack = new Stack<Node<T>>();
            stack.Push(_root);

            while (stack.Count > 0)
            {
                var currentNode = stack.Pop();

                action.Invoke(currentNode.Value);

                if (currentNode.Right != null)
                {
                    stack.Push(currentNode.Right);
                }

                if (currentNode.Left != null)
                {
                    stack.Push(currentNode.Left);
                }
            }
        }

        public bool Remove(T value)
        {
            if (_root == null)
            {
                return false;
            }

            var nodes = SearchNode(value);

            if (nodes.CurrentNode == null)
            {
                return false;
            }

            var deletedNode = nodes.CurrentNode;
            var parentNode = nodes.ParentNode;

            // If leaf
            if (deletedNode.Right == null && deletedNode.Left == null)
            {
                if (parentNode == null)
                {
                    _root = null;
                }
                else if (parentNode.Left == deletedNode)
                {
                    parentNode.Left = null;
                }
                else
                {
                    parentNode.Right = null;
                }

                Count--;

                return true;
            }

            // If 1 child
            if (deletedNode.Right == null)
            {
                if (parentNode == null)
                {
                    _root = deletedNode.Left;
                }
                else if (parentNode.Left == deletedNode)
                {
                    parentNode.Left = deletedNode.Left;
                }
                else
                {
                    parentNode.Right = deletedNode.Left;
                }

                Count--;

                return true;
            }

            // If 1 child
            if (deletedNode.Left == null)
            {
                if (parentNode == null)
                {
                    _root = deletedNode.Right;
                }
                else if (parentNode.Left == deletedNode)
                {
                    parentNode.Left = deletedNode.Right;
                }
                else
                {
                    parentNode.Right = deletedNode.Right;
                }

                Count--;

                return true;
            }

            return RemoveNode(parentNode, deletedNode);
        }

        private bool RemoveNode(Node<T> parentNode, Node<T> replaceableNode)
        {
            var minNodeParent = replaceableNode;
            var minNode = replaceableNode.Right;

            while (minNode.Left != null)
            {
                minNodeParent = minNode;
                minNode = minNode.Left;
            }

            if (minNode.Right != null)
            {
                if (minNodeParent.Right == minNode)
                {
                    minNodeParent.Right = minNode.Right;
                }

                if (minNodeParent.Left == minNode)
                {
                    minNodeParent.Left = minNode.Right;
                }
            }
            else
            {
                minNodeParent.Left = null;
            }

            minNode.Right = null;

            if (replaceableNode == minNode)
            {
                return false;
            }

            minNode.Left = replaceableNode.Left;
            minNode.Right = replaceableNode.Right;

            if (parentNode == null)
            {
                _root = minNode;
            }
            else if (parentNode.Right == replaceableNode)
            {
                parentNode.Right = minNode;
            }
            else
            {
                parentNode.Left = minNode;
            }

            Count--;

            return true;
        }
    }
}