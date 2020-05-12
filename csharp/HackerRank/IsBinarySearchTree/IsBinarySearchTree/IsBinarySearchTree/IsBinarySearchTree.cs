using System;


namespace IsBinarySearchTree
{
    public class Node
    {
        public int data;
        public Node left;
        public Node right;
    }

    public class IsBinarySearchTree
    {

        bool checkBST(Node root)
        {
            if (root == null)
                return true;

            // do in-order traversal
            return checkBSTRecursive(root);
        }

        private bool checkBSTRecursive(Node node)
        {
            if (node.left != null)
            {
                if (node.left.data > node.data)
                    return false;

                checkBSTRecursive(node.left);
            }

            // Nothing to do for current node

            if (node.right != null)
            {
                if (node.right.data < node.data)
                    return false;

                checkBSTRecursive(node.right);
            }

            return true;
        }
    }
}
