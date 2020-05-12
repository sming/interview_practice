using System;
using System.Text;

namespace LinkedLists
{
    public class Node<T>
    {
        public T _val;
        public Node<T> _next;
        public Node(T val, Node<T> next = null)
        {
            this._val = val;
            this._next = next;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(this._val);
            var node = this;
            while (node._next != null)
            {
                node = node._next;
                sb.Append(node._val);
            }

            return sb.ToString();
        }
    }
}
