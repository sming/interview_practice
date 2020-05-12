using System;

namespace StacksNQueues
{
    public class Queue<T>
    {
        private Node<T> _head;
        private Node<T> _tail;

        public Queue(Node<T> head = null)
        {
            _head = _tail = head;
        }

        public void Enqueue(T node)
        {
            if (_head == null)
            {
                _head = _tail = new Node<T>(node);
            }
            else
            {
                node._next = _tail;
                _tail = node;
            }
        }

        public T Dequeue()
        {
            if (_head == null)
                return null;

            T val = _head._val;
            _head = _head._next;

            return val;
        }

    }
}
