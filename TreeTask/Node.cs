using System;

namespace TreeTask
{
    public class Node<T> : ICloneable
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

        public object Clone()
        {
            var newNode = (Node<T>)this.MemberwiseClone();
            newNode.Value = this.Value;
            newNode.Left = this.Left;
            newNode.Right = this.Right;

            return newNode;
        }

        public Node<T> CloneNode()
        {
            var newNode = (Node<T>)this.MemberwiseClone();
            newNode.Value = this.Value;
            newNode.Left = this.Left;
            newNode.Right = this.Right;

            return newNode;
        }
    }
}