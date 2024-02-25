using FibonacciGenerator;
using NUnit.Framework;

namespace FibonacciGeneratorTests;

public class FibonacciTest
{
    [TestCase(-1)]
    [TestCase(-5)]
    [TestCase(-100)]
    public void Generate_ShallThrowException_IfNIsSmallerThanZero(
        int n)
    {
        Assert.Throws<ArgumentException>(
            () => Fibonacci.Generate(n));
    }

    [TestCase(47)]
    [TestCase(100)]
    [TestCase(1000)]
    public void Generate_ShallThrowException_IfNIsLargerThan46(
        int n)
    {
        Assert.Throws<ArgumentException>(
            () => Fibonacci.Generate(n));
    }

    [Test]
    public void Generate_ShallReturnEmptySequence_ForNEqualToZero()
    {
        var result = Fibonacci.Generate(0);
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Generate_ShallProduceSequenceWith_0_ForNEqualTo1()
    {
        var result = Fibonacci.Generate(1);
        Assert.That(result, Is.EqualTo(new int[] { 0 }));
    }

    [Test]
    public void Generate_ShallProduceSequenceWith_0_1_ForNEqualTo2()
    {
        var result = Fibonacci.Generate(2);
        Assert.That(result, Is.EqualTo(new int[] { 0, 1 }));

    }

    [TestCase(3, new int[] { 0, 1, 1 })]
    [TestCase(5, new int[] { 0, 1, 1, 2, 3 })]
    [TestCase(10, new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 })]
    public void Generate_ShallProduceValidFibonacciSequence(
        int n,
        int[] expected)
    {
        var result = Fibonacci.Generate(n);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Generate_ShallProduceSequenceWithLastNumber_1134903170_ForNEqualTo46()
    {
        var result = Fibonacci.Generate(46);
        Assert.That(result.Last(), Is.EqualTo(1134903170));
    }
}

