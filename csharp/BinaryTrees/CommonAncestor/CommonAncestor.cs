using System;
using System.Collections.Generic;
using BinaryTrees;
using System.Linq;

namespace CommonAncestor
{
    /*
    QUESTION
    Design an algorithm and write code to find the first common ancestor of two nodes in a binary tree. Avoid storing additional nodes in a data structure. NOTE: This is not necessarily a binary search tree.

    MY ANSWER
    Build a "path" for each node which would be a List<T> where you push each Node you try and Pop each time you backtrack. This is not storing additional Nodes.
     */
    public class FindCommonAncestor<T>
    {
        private class Comparer : IEqualityComparer<TreeNode<T>>
        {
            public bool Equals(TreeNode<T> x, TreeNode<T> y)
            {
                return x.Value.Equals(y.Value);
            }

            public int GetHashCode(TreeNode<T> obj)
            {
                return 27 + obj.Value.GetHashCode();
            }
        }
        public static TreeNode<T> FindFirstCommonAncestor(TreeNode<T> root, TreeNode<T> n1, TreeNode<T> n2)
        {
            if (root == null)
                return null;

            var n1Ancestors = FindAllAncestors(root, n1);
            var n2Ancestors = FindAllAncestors(root, n2);

            // OK so now we have two in-order, descending from "last" ancestor to "first" ancestor. Hence we want to find 
            // any common elements and then pick the last of those, if there are any.
            var commonElements = n1Ancestors.Intersect(n2Ancestors, new Comparer()).ToList();
            if (commonElements == null || commonElements.Count() == 0)
                return null;

            return commonElements[0];
        }

        
        private static List<TreeNode<T>> FindAllAncestors(TreeNode<T> startNode, TreeNode<T> target)
        {
            var ancestors = new List<TreeNode<T>>();
            if (!FindAncestors(startNode, target, ancestors))
                ancestors = new List<TreeNode<T>>();

            return ancestors;
        }

        private static bool FindAncestors(TreeNode<T> startNode, TreeNode<T> target, List<TreeNode<T>> ancestors)
        {
            if (startNode.Value.Equals(target.Value))  // we've found the target
                return true;

            var stackOfAncestors = new Stack<TreeNode<T>>();
            stackOfAncestors.Push(startNode);

            var q = new Queue<TreeNode<T>>();
            q.Enqueue(startNode);
            while (q.Count > 0)
            {
                var currentNode = q.Dequeue();

                if (currentNode.Left != null)
                    q.Enqueue(currentNode.Left);
                
                if (currentNode.Right != null)
                    q.Enqueue(currentNode.Right);

                // Assume that current node is an ancestor
                stackOfAncestors.Push(currentNode);

                // if we don't recurse with the ancestors stack, we'll have to 'find' the target
                // over and over.

                // perform DFS until we find the target
                bool foundLeft = false, foundRight = false;
                if (startNode.Left != null)
                    foundLeft = FindAncestors(currentNode.Left, target, ancestors);

                if (startNode.Right != null)
                    foundRight = FindAncestors(currentNode.Right, target, ancestors);

                if (!(foundLeft || foundRight))
                    stackOfAncestors.Pop();
            }

            return false;
        }

    }
}
