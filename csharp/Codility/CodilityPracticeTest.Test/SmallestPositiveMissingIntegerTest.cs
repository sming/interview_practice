using NUnit.Framework;

public class SmallestPositiveMissingIntegerTest
{
    [Test]
    public void Test1()
    {
        var s = new SmallestPositiveMissingInteger();
        Assert.AreEqual(5, s.solution(new int[] { 1, 3, 6, 4, 1, 2 }));
    }

    [Test]
    public void Test2()
    {
        var s = new SmallestPositiveMissingInteger();
        Assert.AreEqual(1, s.solution(new int[] { }));
    }

    [Test]
    public void Test3()
    {
        var s = new SmallestPositiveMissingInteger();
        Assert.AreEqual(1, s.solution(new int[] { -20, -1, 14, -10 }));
    }

    [Test]
    public void Test4()
    {
        var s = new SmallestPositiveMissingInteger();
        Assert.AreEqual(4, s.solution(new int[] { 2, -20, 3, -1, 1, -10 }));
    }

    [Test]
    public void Test5()
    {
        var s = new SmallestPositiveMissingInteger();
        Assert.AreEqual(4, s.solution(new int[] { 2, -20, 3, -1, 1, 1, 1, 1, 1, 1, 1, 1, 1, -10 }));
    }

    [Test]
    public void Test6()
    {
        var s = new SmallestPositiveMissingInteger();
        Assert.AreEqual(1, s.solution(new int[] { -50 }));
    }

}
