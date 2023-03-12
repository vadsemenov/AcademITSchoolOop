namespace TreeTask
{
    public class Node<T>
    {
        public T Value { get; set; }

        public Node<T> Left;
        public Node<T> Right;

        public Node(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }
}