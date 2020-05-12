using System;
using System.Collections.Generic;
using System.Linq;

// This is a demo task.
// 
// Write a function:
// that, given an array A of N integers, returns the *smallest positive integer*(greater than 0) that does not occur in A.
// 
// For example, given A = [1, 3, 6, 4, 1, 2], the function should return 5.
// 
// Given A = [1, 2, 3], the function should return 4.
// 
// Given A = [−1, −3], the function should return 1.
// 
// Write an efficient algorithm for the following assumptions:
// 
// N is an integer within the range[1..100, 000];
// each element of array A is an integer within the range[−1, 000, 000..1, 000, 000].
public class SmallestPositiveMissingInteger
{
    public int solution(int[] A)
    {
        var aList = new List<int>(A);
        aList.Sort();
        var positives = aList.Where(x => x > 0).Distinct().ToList();
        if (positives.Count == 0)
            return 1;

        for (int i = 0; i < positives.Count; i++)
        {
            if (i + 1 != positives[i])
                return i + 1;
        }

        return positives.Last() + 1;
    }
}
