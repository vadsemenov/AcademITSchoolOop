namespace TreeTask
{
// #nullable disable annotations
// #nullable disable warnings
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
            else
            {
                throw new ArgumentException($"Тип {typeof(T).Name} не реализует IComparable!", typeof(T).Name);
            }
        }

        public void Insert(T value)
        {
            if (_root == null)
            {
                _root = new Node<T>(value);
                Count++;
                return;
            }

            InsertNode(value, _root);
        }

        private Node<T> InsertNode(T value, Node<T> parentNode)
        {
            var newNode = new Node<T>(value);
            var currentTempNode = parentNode;

            while (true)
            {
                var compareResult = Compare(currentTempNode.Value, value);

                if (compareResult > 0)
                {
                    if (currentTempNode.Left == null)
                    {
                        currentTempNode.Left = newNode;
                        Count++;
                        return newNode;
                    }

                    currentTempNode = currentTempNode.Left;

                    continue;
                }

                if (compareResult <= 0)
                {
                    if (currentTempNode.Right == null)
                    {
                        currentTempNode.Right = newNode;
                        Count++;
                        return newNode;
                    }

                    currentTempNode = currentTempNode.Right;
                }
            }
        }

        public bool Search(T value)
        {
            if (_root == null)
            {
                return false;
            }

            return SearchNode(value, null, _root).currentNode != null;
        }

        private (Node<T> parentNode, Node<T> currentNode) SearchNode(T value, Node<T> parentNode, Node<T> node)
        {
            var currentNodeParent = parentNode;
            var currentNode = node;

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

                    continue;
                }

                if (compareResult < 0)
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

            var nodes = SearchNode(value, null, _root);

            if (nodes.currentNode == null)
            {
                return false;
            }

            var deleteNode = nodes.currentNode;
            var parentNode = nodes.parentNode;

            //If leaf
            if (deleteNode.Right == null && deleteNode.Left == null)
            {
                if (parentNode == null)
                {
                    _root = null;
                }
                else if (parentNode.Left == deleteNode)
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

            //If 1 child
            if (deleteNode.Right == null)
            {
                if (parentNode == null)
                {
                    _root = deleteNode.Left;
                }
                else if (parentNode.Left == deleteNode)
                {
                    parentNode.Left = deleteNode.Left;
                }
                else
                {
                    parentNode.Right = deleteNode.Left;
                }

                Count--;

                return true;
            }

            //If 1 child
            if (deleteNode.Left == null)
            {
                if (parentNode == null)
                {
                    _root = deleteNode.Right;
                }
                else if (parentNode.Left == deleteNode)
                {
                    parentNode.Left = deleteNode.Right;
                }
                else
                {
                    parentNode.Right = deleteNode.Right;
                }

                Count--;

                return true;
            }

            // if all child nodes is not null
            var minNodeOfSubtree = SearchSubTreeMinNode(deleteNode, deleteNode.Right);

            return ReplaceNode(parentNode, deleteNode, minNodeOfSubtree);
        }

        private static Node<T> SearchSubTreeMinNode(Node<T> rootNodeParent, Node<T> rootNode)
        {
            var minNodeParent = rootNodeParent;
            var minNode = rootNode;

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

            minNode.Right = null;

            return minNode;
        }

        private bool ReplaceNode(Node<T> parentNode, Node<T> replaceableNode, Node<T> replacementNode)
        {
            if (replaceableNode == replacementNode)
            {
                return false;
            }

            replacementNode.Left = replaceableNode.Left;
            replacementNode.Right = replaceableNode.Right;

            if (parentNode == null)
            {
                _root = replacementNode;
            }
            else if (parentNode.Right == replaceableNode)
            {
                parentNode.Right = replacementNode;
            }
            else
            {
                parentNode.Left = replacementNode;
            }

            Count--;

            return true;
        }
    }
}