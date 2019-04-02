using System;

namespace BinaryTrees
{
    public class TreeNode<T>
    {
        private T value = default(T);
        public TreeNode<T> left = null;
        public TreeNode<T> right = null;
        public TreeNode<T> Left { get => left; set => left = value; }
        public TreeNode<T> Right { get => right; set => right = value; }
        public T Value { get => value; set => this.value = value; }

        public TreeNode(T value = default(T), TreeNode<T> left = null, TreeNode<T> right = null)
        {
            Left = left;
            Right = right;
            Value = value;
        }

        public TreeNode<T> AddLeft(T left)
        {
            this.Left = new TreeNode<T>(left);
            return this.Left;
        }
        public TreeNode<T> AddRight(T right)
        {
            this.Right = new TreeNode<T>(right);
            return this.Right;
        }
    }
}
