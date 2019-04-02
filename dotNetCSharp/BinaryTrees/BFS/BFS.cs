using System;
using System.Collections.Generic;
using BinaryTrees;

namespace BinaryTrees.BFS
{
    public class BFS<T>
    {
        public bool Contains(TreeNode<T> root, T value)
        {
            var q = new Queue<TreeNode<T>>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                var node = q.Dequeue();
                if (node == null)
                    continue;

                if (node.Value.Equals(value))
                    return true;
                
                if (node.Left != null)
                    q.Enqueue(node.Left);
                if (node.Right != null)
                    q.Enqueue(node.Right);
            }

            return false;
        }
    }
}