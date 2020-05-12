using System;
using BinaryTrees;

namespace BinaryTrees.InOrderTraversal
{
    public class InOrderTraversal<T>
    {
        public bool Contains(TreeNode<T> node, T value)
        {
            if (node == null)
            {
                return false;
            }

            if (node.Left != null) {
                if (Contains(node.Left, value))
                    return true;
            }

            if (node.Value.Equals(value)) {
                return true;
            }

            if (node.Right != null) {
                if (Contains(node.Right, value))
                    return true;
            }

            return false;
        }
    }
}
