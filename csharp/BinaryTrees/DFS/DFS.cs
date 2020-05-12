using System;
using BinaryTrees;

namespace BinaryTrees.DFS
{
    public class DFS<T>
    {
        public bool Contains(TreeNode<T> node, T value)
        {
            if (node == null)
                return false;

            if (node.Value.Equals(value))
                return true;
            
            if (Contains(node.Left, value))
                return true;

            if (Contains(node.Right, value))
                return true;

            return false;
        }
    }
}