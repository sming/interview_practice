/* Given a directed graph, design an algorithm to find out whether there is a route between two nodes.

a → b → c	a to c? Yes
a → b → c	c to a? No

o → p → q	m to q? Yes
a → b → o	b to m? No
m → n → a

a → b → c	c to a? No

a → b → d →
*/

using System;
using System.Linq;
using System.Collections;

namespace GraphTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var e1 = CreateEdge(5, 10);
            var e2 = CreateEdge(10, 15);

            var g = new Graph<int>();
            g._edges = new HashSet<Edge<int>>(e1, e2);

            var gt = new GraphTraverser<int>();
            gt._graph = g;

            bool res = gt.isRouteBetween(5, 15);
            Console.WriteLine($"Route between 5 and 15? {res}.");
        }

        private static Edge<int> CreateEdge(int headVal, int tailVal)
        {
            var n = new Node<int>();
            n._value = headVal;
            var o = new Node<int>();
            o._value = tailVal;

            var e = new Edge<int>();
            e._head = n;
            e._tail = o;

            return e;
        }
    }

    class Node<T>
    {
        T _value;
    }

    class Edge<T>
    {
        Node<T> _head;
        Node<T> _tail;
    }

    class Graph<T>
    {
        HashSet<Edge<T>> _edges;
        // Set<Node<T>> _nodes;

        List<Edge<T>> getEdgesWithHead(T val)
        {
            return _edges.Where(x => x._head._value == val).ToList();
        }
    }

    class GraphTraverser<T>
    {
        Graph<T> _graph;
        bool _found;

        bool isRouteBetween(T start, T end)
        {
            var edges = _graph.getEdgesWithHead(start);
            exploreEdgesForVal(edges, end);

            return _found;
        }

        void exploreEdgesForVal(List<Edge<T>> edges, T end)
        {
            if (edges == null || edges.Empty())
                return;

            foreach (var edge in edges)
            {
                if (edge._tail._value == end) {
                    _found = True;
                    return;
                }

                var newEdges = _graph.getEdgesWithHead(edge._tail);
                exploreEdgesForVal(newEdges, end);
            }
        }
    }
}
