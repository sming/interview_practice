using System;
using System.Text;

namespace LinkedLists
{
    public class LinkedList<T>
    {
        public Link<T> Head { get; set; }
        public Link<T> Tail { get; set; }
        public LinkedList<T> Push(T val)
        {
            var newHead = new Link<T>(val)
            {
                Previous = Head
            };

            if (Head != null)
                Head.Next = newHead;

            Head = newHead;

            if (Tail == null)
                Tail = Head;

            return this;
        }

        public LinkedList<T> Pop()
        {
            if (Head == null)
                return null;

            if (Head.Previous != null)
                Head.Previous.Next = null;

            Head = Head.Previous;
            return this;
        }

        public LinkedList<T> PushTail(T val)
        {
            var newTail = new Link<T>(val)
            {
                Next = Tail
            };

            if (Tail != null)
                Tail.Previous = newTail;

            Tail = newTail;

            return this;
        }


        public LinkedList<T> PopTail()
        {
            if (Tail == null)
                return null;

            if (Tail.Next != null)
                Tail.Next.Previous = null;

            Tail = Tail.Next;

            return this;
        }

        public override string ToString()
        {
            if (Tail == null)
                return "<null>";

            var curr = Tail;
            var sb = new StringBuilder();
            do
            {
                sb.Append(curr).Append(" -> ");
                curr = curr.Next;
            }
            while (curr.Next != null);
            sb.Append(curr).Append(" -> ").Append("<null>");

            return sb.ToString();
        }
    }
}
