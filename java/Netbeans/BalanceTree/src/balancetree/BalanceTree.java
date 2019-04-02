/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package balancetree;

import java.util.ArrayList;
import java.util.Collections;
import java.util.HashSet;

/**
 * Implement a function to check if a tree is balanced. 
 * For the purposes of this question, a balanced tree is defined to be a tree 
 * such that no two leaf nodes differ in distance from the root by more than one.
 */
public class BalanceTree {
    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
    }
    static final int MAX_DISTANCE = 1;
    static HashSet<Integer> nodeDistances = new HashSet<Integer>();
   
    public boolean isTreeBalanced(Node n)
    {
        if (n == null)
            return true;
        
        HashSet<Integer> allDistances = new HashSet<Integer>();
        getAllNodeDistances(n, 0, allDistances);
        
        ArrayList<Integer> sortedDistances = new ArrayList<Integer>(allDistances);
        Collections.sort(sortedDistances);
        
        if (sortedDistances.size() < 2)
            return true;
        
        return sortedDistances.get(0) - sortedDistances.get(sortedDistances.size() - 1) <= MAX_DISTANCE;
    }

    /**
     * 
     * @param root
     * @param currentDistance
     * @param allDistances 
     */
    private void getAllNodeDistances(Node root, Integer currentDistance, HashSet<Integer> allDistances) {
        if (root == null) {
            return;
        }
         
        allDistances.add(++currentDistance);
        
        if (root.left != null)
        {
            getAllNodeDistances(root.left, currentDistance, allDistances);
        }

        if (root.right != null)
        {
            getAllNodeDistances(root.right, currentDistance, allDistances);
        }
    }
}
