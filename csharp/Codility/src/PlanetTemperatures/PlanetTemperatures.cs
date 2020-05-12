using System;
// you can also use other imports, for example:
using System.Collections.Generic;
using System.Linq;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");
/*
So we need to:
1. chop the input into 4 - precisely according to specifications. If we're given 8 temps, the indices
would be [0,1],[2,3],[4,5],[6,7].
2. iterate the temps for each season, recording the highest and lowest and then subtract the 
lowest from the highest to get the amplitude. Subtracting -ve temps should work fine.
3. sort the results and return the first element.
 */
namespace PlanetTemperatures
{
    public class Solution
    {
        private enum Season
        {
            WINTER = 0,
            SPRING,
            SUMMER,
            AUTUMN
        }

        public string solution(int[] T)
        {
            var NUMBER_OF_SEASONS = Enum.GetNames(typeof(Season)).Length;   // caps since this is essentially a constant

            var amplitudes = new List<Tuple<int, Season>>(NUMBER_OF_SEASONS);

            int numberOfSeasonDays = T.Length / NUMBER_OF_SEASONS;
            for (int i = 0; i < NUMBER_OF_SEASONS; i++)
            {
                var seasonalTemps = new int[numberOfSeasonDays];
                Array.Copy(T, numberOfSeasonDays * i, seasonalTemps, 0, numberOfSeasonDays);
                int highest = int.MinValue;
                int lowest = int.MaxValue;

                foreach (int temp in seasonalTemps)
                {
                    if (temp > highest)
                        highest = temp;
                    if (temp < lowest)
                        lowest = temp;
                }

                int amplitude = Math.Abs(highest - lowest);
                amplitudes.Add(Tuple.Create(amplitude, (Season)i));
            }

            var highestAmplitudeSeason = amplitudes.OrderByDescending(x => x.Item1).First().Item2;
            return highestAmplitudeSeason.ToString();
        }
    }
}