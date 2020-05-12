using System;
using System.Linq;
using System.Text;

namespace LinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var linkNum1 = LinkedListNumberAdder<int>.StringNumberToLinkedList("315");

            Console.WriteLine($"First num: {linkNum1}.");
        }
    }

    /**
        You have two numbers represented by a linked list, where each node contains a single
        digit. The digits are stored in reverse order, such that the 1st digit is at the head of
        the list. Write a function that adds the two numbers and returns the sum as a linked
        list.
        EXAMPLE
        Input: (3 -> 1 -> 5) + (5 -> 9 -> 2)
        Output: 8 -> 0 -> 8
    */

    public class LinkedListNumberAdder<T>
    {
        public static int GetNumberFromLinkedList(Node<T> head)
        {
            var sb = new StringBuilder();
            sb.Append(head._val);
            var node = head;
            while (node._next != null)
            {
                node = node._next;
                sb.Insert(0, node._val);
            }

            return Convert.ToInt32(sb.ToString());
        }

        public static Node<int> StringNumberToLinkedList(string num)
        {
            var node = new Node<int>(Convert.ToInt32(num.Last()));

            for (int i = num.Length - 1; i == 1; i--)
            {
                node = new Node<int>(Convert.ToInt32(num[i - 1]), node);
            }

            return node;
        }
    }
}
