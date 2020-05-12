using System;
using Xunit;
using LinkedLists;

namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestBasicListConstruction()
        {
            var ll = new LinkedList<int>();
            ll.Push(1).Push(2).Push(3).Push(4);

            Assert.Equal("1 -> 2 -> 3 -> 4 -> <null>", ll.ToString());
        }

        [Fact]
        public void TestNoDuplicateRemoval()
        {
            var ll = new LinkedList<int>();
            ll.Push(1).Push(2).Push(3).Push(4);
            
            var uniqueLl = RemoveDuplicates<int>.Go(ll);     

            Assert.Equal("1 -> 2 -> 3 -> 4 -> <null>", uniqueLl.ToString());
        }

        [Fact]
        public void TestBasicDuplicateRemoval()
        {
            var ll = new LinkedList<int>();
            ll.Push(1).Push(2).Push(2).Push(3).Push(4);

            var uniqueLl = RemoveDuplicates<int>.Go(ll);     

            Assert.Equal("1 -> 2 -> 3 -> 4 -> <null>", uniqueLl.ToString());
        }

        [Fact]
        public void TestDuplicateRemoval()
        {
            var ll = new LinkedList<int>();
            ll.Push(1).Push(1).Push(2).Push(2).Push(3).Push(3).Push(4).Push(4);

            var uniqueLl = RemoveDuplicates<int>.Go(ll);     

            Assert.Equal("1 -> 2 -> 3 -> 4 -> <null>", uniqueLl.ToString());
        }
    }
}
