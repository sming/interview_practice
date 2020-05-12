using System;
using Xunit;
//using BinaryGap;
using SoldierRanks;
using PlanetTemperatures;

namespace UnitTests
{
    public class PlanetTests
    {
        [Fact]
        public void SoldierTest()
        {
            var s = new SoldierRanks.Solution();
            int[] ranks = new int[] { 3, 4, 3, 0, 2, 2, 3, 0, 0 };

            Assert.Equal(5, s.solution(ranks));

            ranks = new int[] { 4, 4, 3, 3, 1, 0 };
            Assert.Equal(3, s.solution(ranks));

        }

        [Fact]
        public void TestPlanetTemps()
        {
            var s = new PlanetTemperatures.Solution();
            var temps = new int[] { -3, -14, -5, 7, 8, 42, 8, 3 };
            string season = s.solution(temps);
            Assert.Equal("SUMMER", season);
            Console.WriteLine("Season: " + season);
        }
        [Fact]
        public void TestPlanetTemps2()
        {
            var s = new PlanetTemperatures.Solution();
            var temps = new int[] { 2, -3, 3, 1, 10, 8, 2, 5, 13, -5, 3, -18 };
            string season = s.solution(temps);
            Assert.Equal("AUTUMN", season);
            Console.WriteLine("Season: " + season);
        }
    }
}
