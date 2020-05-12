using System;
namespace LinkedLists
{
    public class Link<T>
    {
        public Link(T val)
        {
            Val = val;
        }

        public Link<T> Next { get; set; }
        public Link<T> Previous { get; set; }

        public T Val { get; }

        public override string ToString()
        {
            return Val.ToString();
        }
    }
}
