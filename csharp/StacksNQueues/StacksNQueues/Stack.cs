using System;

namespace StacksNQueues
{
    public class Stack<T>
    {
        private Node<T> _head;

        public Stack(Node<T> head = null)
        {
            _head = head;
        }

        public void Push(Node<T> node)
        {
            if (_head == null)
            {
                _head = node;
            }
            else
            {
                node._next = _head;
                _head = node;
            }
        }

        public T Pop()
        {
            if (_head == null)
                return null;

            T val = _head._val;
            _head = _head._next;
            return val;
        }
    }

    /** 3.1 Describe how you could use a single array to implement three stacks. */
}
