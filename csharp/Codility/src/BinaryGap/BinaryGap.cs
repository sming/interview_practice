using System;

namespace BinaryGap
{
    /*
    PROBLEM
A binary gap within a positive integer N is any maximal sequence of consecutive zeros that is surrounded by ones at both ends in the binary representation of N.

For example, number 9 has binary representation 1001 and contains a binary gap of length 2. The number 529 has binary representation 1000010001 and contains two binary gaps: one of length 4 and one of length 3. The number 20 has binary representation 10100 and contains one binary gap of length 1. The number 15 has binary representation 1111 and has no binary gaps. The number 32 has binary representation  100000 and has no binary gaps.

Write a function:

class Solution { public int solution(int N); }

that, given a positive integer N, returns the length of its longest binary gap. The function should return 0 if N doesn't contain a binary gap.

For example, given N = 1041 the function should return 5, because N has binary representation 10000010001 and so its longest binary gap is of length 5. Given N = 32 the function should return 0, because N has binary representation '100000' and thus no binary gaps.

Write an efficient algorithm for the following assumptions:

N is an integer within the range [1..2,147,483,647].
    
    SOLUTION
    - positive could mean ulong
    - a binary gap is the longest sequence of consequtive zeroes bounded by ones 
    - N is an integer within the range [1..2,147,483,647 (int.Max)].
     */
    public class BinaryGap
    {
        public static void Main()
        {
            var s = new BinaryGap();
            s.solution(1041);
        }
        /**
        that, given a positive integer N, returns the length of its longest binary gap. The function should return 0 if N doesn't contain a binary gap.
         */
        public int solution(int N)
        {
            string binary = Convert.ToString(N, 2);

            Console.WriteLine($"N: {N}, binary N: {binary}.");

            int longestBinaryGapLength = 0;
            int currentBinaryGapLength = 0;
            bool seenStartingOne = false;
            char lastSeenChar = 'a';
            foreach (var c in binary)
            {
                if (c == '1')
                {
                    if (lastSeenChar == '1')
                    {
                        continue;
                    }

                    if (!seenStartingOne)
                    {
                        seenStartingOne = true;
                    }
                    else
                    {
                        seenStartingOne = false;
                        if (currentBinaryGapLength > longestBinaryGapLength)
                        {
                            longestBinaryGapLength = currentBinaryGapLength;
                        }
                        currentBinaryGapLength = 0;
                    }
                }
                else    // it's a '0'
                {
                    if (seenStartingOne)
                    {
                        ++currentBinaryGapLength;
                    }
                }

                lastSeenChar = c;
            }

            return 0;
        }
    }
}
