using System;
using Xunit;
using RecursionPractice;
using System.Collections.Generic;

namespace UnitTest
{
    public class UnitTest
    {
        [Fact]
        public void NullTest()
        {
            string s = null;
            var sp = new StringPermutations();
            var result = sp.GetAllPermutations(s);
            Assert.Equal(new HashSet<String>(), result);
        }
    }
}
