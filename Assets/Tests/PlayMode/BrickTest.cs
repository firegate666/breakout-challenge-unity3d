using NUnit.Framework;

public class BrickTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void BrickTestSimplePasses()
    {
        Assert.AreEqual(true, true);
    }
}