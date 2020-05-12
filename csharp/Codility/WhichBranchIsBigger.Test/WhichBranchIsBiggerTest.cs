using NUnit.Framework;

namespace WhichBranchIsBigger.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            //        1
            //    4      100
            //   5 -1   -1  14
            //            -1  17
            //
            // Left = 0, 1, 3
            // Right = 2
            Assert.AreEqual("Right", Challenge.Solution(new long[] { 1, 4, 100, 5, -1, -1, 14, -1, 17 }));
            Assert.Pass();
        }
        //          1
        //      7       -1
        //   6    -1
        // 1, 7, -1, 6, -1
        //
        //
        //          1
        //      -1     7
        //          -1   6
        // 1, -1, 7, -1, 6

        [Test]
        public void Test2()
        {
            //          1
            //      10      5
            //   1     0   6  20
            Assert.AreEqual("Right", Challenge.Solution(new long[] { 1, 10, 5, 1, 0, 6, 20 }));
            Assert.Pass();
        }

        [Test]
        public void Test3()
        {
            //          0
            //      1      2
            //    5  6   3   4
            Assert.AreEqual("Left", Challenge.Solution(new long[] { 0, 1, 2, 5, 6, 3, 4 }));
            Assert.Pass();
        }
    }
}