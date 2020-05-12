// FIXME USING DICTIONARY BFS APPROACH
using System;
using System.Collections.Generic;
using System.Linq;
/**
 * Introduction
 * Correctly determine the fewest number of coins to be given to a
 * customer  such that the sum of the coins' value would equal the
 * correct amount  of change.
 *
 * For example
 * An input of 15 with [1, 5, 10, 25, 100] should return one nickel (5)
 * and  one dime (10) or [5, 10]
 *
 * An input of 40 with [1, 5, 10, 25, 100] should return one nickel (5)
 * and  one dime (10) and one quarter (25) or [5, 10, 25]
 *
 * Edge cases ————————————
 * Does your algorithm work for any given set of coins?
 * Can you ask for negative change?
 * Can you ask for a change value smaller than the smallest coin value?
*/
public static class Change
{
    public static int[] FindFewestCoins(int[] coins, int target)
    {
        if (coins == null || coins.Length == 0 || target == 0)
            return new int[0];

        var coinList = new List<int>(coins);

        if (target < 0)
            throw new ArgumentException("Target has to be positive");

        if (coinList.Any(x => x < 0))
            throw new ArgumentException("Coins have to have positive face value");

        if (!coinList.Any(x => target >= x))
            throw new ArgumentException("Has to be a coin small enough to make target");

        coinList.Reverse();
        var fewestCoins = new List<int>();
        var currentCoins = new List<int>();
        FindFewestCoinsRecursive(coinList, 0, target, fewestCoins, currentCoins);

        if (fewestCoins.Count() < 1)
            throw new ArgumentException("Target not possible with given coins");


        fewestCoins.Sort();
        return fewestCoins.ToArray();
    }

    private static void FindFewestCoinsRecursive(List<int> coins, int coinsIdx, int remainingAmount, List<int> fewestCoins, List<int> currentCoins)
    {
        if (remainingAmount == 0 && (currentCoins.Count < fewestCoins.Count || fewestCoins.Count == 0))
        {
            fewestCoins.Clear();
            fewestCoins.AddRange(currentCoins);
            return;
        }
        else if (coinsIdx >= coins.Count)
        {
            return;
        }
        else if ((currentCoins.Count > fewestCoins.Count) && fewestCoins.Count > 0)
        {
            return;
        }


        for (int i = coinsIdx; i < coins.Count; i++)
        {
            int currentDenom = coins[i];
            int numCurrentDenom = remainingAmount / currentDenom;

            for (int j = 0; j <= numCurrentDenom; j++)
            {
                for (int k = 0; k < j; k++)
                    currentCoins.Add(currentDenom);

                int remainder = remainingAmount - j * currentDenom;
                FindFewestCoinsRecursive(coins, coinsIdx + 1, remainder, fewestCoins, currentCoins);

                for (int k = 0; k < j; k++)
                    currentCoins.RemoveAt(currentCoins.Count - 1);
            }
        }
    }
}
