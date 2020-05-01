package org.psk.interview_practice.fibonnacidp;

import java.util.HashMap;
import java.util.Map;
/* 1 2 3 4 5 6 7 8
 * 0 1 1 2 3 5 8 13
 * 0+1 = 1
 * 1+1 = 2
 * 2+1 = 3
 * 3+2 = 5
 * 5+3 = 8
 */
public class FibonacciDp {
	
	public static void main(String[] args) {
		var fibber = new FibonacciDp();
		runFibber(fibber, 4);
		runFibber(fibber, 2);
		runFibber(fibber, 6);
		runFibber(fibber, 15);
	}

	private static void runFibber(FibonacciDp fibber, int i) {
		int fibNum = fibber.getKthFibonacciNumber(i);
		System.out.println("The " + (i+1) + "th Fib number is " + fibNum);
	}
	
	// if we're getting Kth number, we need to do from k - 1 because we go down to zero?
	public int getKthFibonacciNumber(int k) {
		// check k for dumb inputs here
		
		var precomputedFibMap = new HashMap<Integer,Integer>();
		return getKthFibNumberRecursive(precomputedFibMap, k);
	}

	private int getKthFibNumberRecursive(Map<Integer,Integer> precomputedFibMap, int i) {
		if (i == 1 || i == 2)
			return 1;
		
		int precomputed = precomputedFibMap.getOrDefault(i, -1);
		if (precomputed != -1) {
			System.out.println("Saved recomputing " + i + "th fib num.");
			return precomputed;
		}
		
		int result = getKthFibNumberRecursive(precomputedFibMap, i - 2) + getKthFibNumberRecursive(precomputedFibMap, i - 1);
		precomputedFibMap.put(i, result);
		
		return result;
	}
}
