using System;
using BinaryTrees;
namespace CreateShortestBinaryTree
{
    /**
    4.3 Given a sorted (increasing order) array, write an algorithm to create a binary tree with minimal height.

    So we need 0 2 4 6 8 10 12 14 16 => (length = 9)

                        8
                   4        12
                 2   6    10   14
               0                 16
            
     */
    public class CreateShortestBinaryTree<T>
    {
        public static TreeNode<T> Go(T[] sortedArray)
        {
            if (sortedArray == null || sortedArray.Length == 0)
                return null;

            // var rootNode = new TreeNode<T>(sortedArray[sortedArray.Length / 2]);
            TreeNode<T> rootNode = null;
            Go(ref rootNode, sortedArray, 0, sortedArray.Length -1);

            return rootNode;
        }

        private static void Go(ref TreeNode<T> n, T[] sortedArray, int startIdx, int endIdx)
        {
            // Need to do LHS and RHS recusively
            int midpointIdx = startIdx + ((endIdx - startIdx) / 2);
            
            // Are we done?
            if (endIdx < startIdx) // || endIdx == midpointIdx)
                return;

            T val = sortedArray[midpointIdx];
            n = new TreeNode<T>(val);

            System.Console.WriteLine($"Go(): val: {val} startIdx: {startIdx}, endIdx: {endIdx}, midpointIdx: {midpointIdx}.");

            Go(ref n.left, sortedArray, startIdx, midpointIdx-1);
            Go(ref n.right, sortedArray, midpointIdx+1, endIdx);
        }
    }
}
