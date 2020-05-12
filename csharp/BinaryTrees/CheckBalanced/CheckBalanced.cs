using System;
using System.Collections.Generic;
using System.Linq;
/**
Implement a function to check if a tree is balanced. For the purposes of this
question, a balanced tree is defined to be a tree such that no two leaf nodes
differ in distance from the root by more than one.
*/
namespace BinaryTrees
{
    class CheckBalanced<T>
    {
        public static bool IsBalanced(TreeNode<T> root)
        {
            var leafDepths = new SortedSet<int>();
            IsBalancedImpl(root, leafDepths, 0);

            return leafDepths.Last() - leafDepths.First() <= 1;
        }

        private static void IsBalancedImpl(TreeNode<T> node, SortedSet<int> leafDepths, int currentDepth)
        {
            currentDepth++;
            if (node.Left != null && node.Right != null)
            {
                leafDepths.Append(currentDepth);
            }

            if (node.Left != null)
            {
                IsBalancedImpl(node.Left, leafDepths, currentDepth);
            }
            else if (node.Right != null)
            {
                IsBalancedImpl(node.Right, leafDepths, currentDepth);
            }
        }
    }
}
