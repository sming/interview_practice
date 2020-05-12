using System;
using BinaryTrees;
namespace CreateShortestBinaryTree
{
    public class TreeDepth<T>
    {
        public static int Go(TreeNode<T> root)
        {
            int maxDepth = 0;
            if (root == null)
                return maxDepth;

            if (root.Left != null)
            {
                maxDepth = GoImpl(maxDepth, root.Left);
            }

            if (root.Right != null)
            {
                maxDepth = Math.Max(maxDepth, GoImpl(maxDepth, root.Right));
            }

            return maxDepth;
        }

        private static int GoImpl(int depth, TreeNode<T> n)
        {
            ++depth;
            
            int lDepth = depth;
            if (n.Left != null)
            {
                lDepth = GoImpl(depth, n.Left);
            }

            if (n.Right != null)
            {
                depth = Math.Max(lDepth, GoImpl(depth, n.Right));
            }

            return depth;
        }
    }
}
