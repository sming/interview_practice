using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    class SinglyLinkedListNode
    {
        public int data;
        public SinglyLinkedListNode next;

        public SinglyLinkedListNode(int nodeData)
        {
            this.data = nodeData;
            this.next = null;
        }
    }

    class SinglyLinkedList
    {
        public SinglyLinkedListNode head;
        public SinglyLinkedListNode tail;

        public SinglyLinkedList()
        {
            this.head = null;
            this.tail = null;
        }

        public void InsertNode(int nodeData)
        {
            SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

            if (this.head == null)
            {
                this.head = node;
            }
            else
            {
                this.tail.next = node;
            }

            this.tail = node;
        }
    }

    static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep, TextWriter textWriter)
    {
        while (node != null)
        {
            textWriter.Write(node.data);

            node = node.next;

            if (node != null)
            {
                textWriter.Write(sep);
            }
        }
    }

    // Complete the hasCycle function below.

    /*
     *
 * A linked list is said to contain a cycle if any node is visited more than once while traversing the   *list.
 * 
 * Complete the function provided for you in your editor.It has one parameter: a pointer to a Node object   *named  that points to the head of a linked list.Your function must return a boolean denoting whether   *or not there is a cycle in the list. If there is a cycle, return true; otherwise, return false.
 * 
 * Note: If the list is empty, head will be null.
 * 
 * Input Format
 * 
 * Our hidden code checker passes the appropriate argument to your function.You are not responsible for   *reading any input from stdin.
 * 
 * Constraints
 * 
 * Output Format
 * 
 * If the list contains a cycle, your function must return true. If the list does not contain a cycle, it must return false. The binary integer corresponding to the boolean value returned by your function is printed to stdout by our hidden code checker.
     * For your reference:
     *
     * SinglyLinkedListNode {
     *     int data;
     *     SinglyLinkedListNode next;
     * }
     *
     */
    static bool hasCycle(SinglyLinkedListNode head)
    {
        if (head == null || head.next == null)
            return false;

        var nodeSet = new HashSet<SinglyLinkedListNode>();
        var current = head;
        while (current != null)
        {
            if (nodeSet.Contains(current))
                return true;

            nodeSet.Add(current);

            current = current.next;
        }

        return false;
    }
}