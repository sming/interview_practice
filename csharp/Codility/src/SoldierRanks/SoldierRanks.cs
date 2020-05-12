using System;
using System.Collections.Generic;

namespace SoldierRanks
{
    public class Solution
    {
        // Soldiers may report to another solider exactly 1 rank higher than themselves. If no-one of that rank exists,
        // the soldier does not report to anyone. Return the number of soliders who report to another soldier.
        public int solution(int[] ranks) {
            // A Dictionary of Rank to number of Solders at that rank
            var rankCounts = new Dictionary<int, int>();
            
            foreach (int rank in ranks)
            {
                if (rankCounts.TryGetValue(rank, out int rankCount))
                {
                    rankCounts[rank] = ++rankCount;
                }
                else
                {
                    rankCounts[rank] = 1;
                }
            }

            int canReportToSuperiorCount = 0;
            foreach (var currentRank in rankCounts)
            {
                if (rankCounts.ContainsKey(currentRank.Key + 1))
                {
                    canReportToSuperiorCount += currentRank.Value;
                }
            }

            return canReportToSuperiorCount;
        }
    }
}
