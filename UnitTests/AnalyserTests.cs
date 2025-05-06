using NUnit.Framework;
using FrequencyAnalysis;
using System.Collections.Generic;

[TestFixture]
public class AnalyserTests
{
    [Test]
    public void DirectorySolution_ReturnsCorrectFrequencies()
    {
        var analyser = new Analyser("hello world");
        var result = analyser.GetCharCount();

        var expected = new Dictionary<char, int>
        {
            { 'h', 1 }, { 'e', 1 }, { 'l', 3 }, { 'o', 2 }, { 'w', 1 }, { 'r', 1 }, { 'd', 1 }
        };

        CollectionAssert.AreEquivalent(expected, result);
        Assert.That(analyser.GetTotalCharCount(), Is.EqualTo(10));  // excludes space
    }

    [Test]
    public void LinqSolution_ReturnsCorrectFrequencies()
    {
        var analyser = new Analyser("hello world");
        var result = analyser.GetCharCountLinq();

        var expected = new Dictionary<char, int>
        {
            { 'h', 1 }, { 'e', 1 }, { 'l', 3 }, { 'o', 2 }, { 'w', 1 }, { 'r', 1 }, { 'd', 1 }
        };

        CollectionAssert.AreEquivalent(expected, result);
        Assert.That(analyser.getTotalCharCountLinq(), Is.EqualTo(10));  // excludes space
    }

    [Test]
    public void EmptyString_ReturnsEmptyResults()
    {
        var analyser = new Analyser("");
        var dictResult = analyser.GetCharCount();
        var linqResult = analyser.GetCharCountLinq();

        Assert.IsEmpty(dictResult);
        Assert.IsEmpty(linqResult);
        Assert.That(analyser.GetTotalCharCount(), Is.EqualTo(0));
        Assert.That(analyser.getTotalCharCountLinq(), Is.EqualTo(0));
    }

    [Test]
    public void OnlyWhitespace_ReturnsEmptyFrequencies()
    {
        var analyser = new Analyser(" \t\r\n");
        var dictResult = analyser.GetCharCount();
        var linqResult = analyser.GetCharCountLinq();

        Assert.IsEmpty(dictResult);
        Assert.IsEmpty(linqResult);
        Assert.That(analyser.GetTotalCharCount(), Is.EqualTo(0));
        Assert.That(analyser.getTotalCharCountLinq(), Is.EqualTo(0));
    }

    [Test]
    public void CheckIndividualCharacterCounts()
    {
        // Input string with known frequencies
        var input = "hello world";
        var analyzer = new Analyser(input);

        // Fetch frequency results using DirectorySolution or LinqSolution
        var dictResult = analyzer.GetCharCount();
        var linqResult = analyzer.GetCharCountLinq();

        // Dictionary-based solution
        Assert.That(dictResult['h'], Is.EqualTo(1));
        Assert.That(dictResult['e'], Is.EqualTo(1));
        Assert.That(dictResult['l'], Is.EqualTo(3));
        Assert.That(dictResult['o'], Is.EqualTo(2));
        Assert.That(dictResult['w'], Is.EqualTo(1));
        Assert.That(dictResult['r'], Is.EqualTo(1));
        Assert.That(dictResult['d'], Is.EqualTo(1));

        // LINQ-based solution
        Assert.That(linqResult['h'], Is.EqualTo(1));
        Assert.That(linqResult['e'], Is.EqualTo(1));
        Assert.That(linqResult['l'], Is.EqualTo(3));
        Assert.That(linqResult['o'], Is.EqualTo(2));
        Assert.That(linqResult['w'], Is.EqualTo(1));
        Assert.That(linqResult['r'], Is.EqualTo(1));
        Assert.That(linqResult['d'], Is.EqualTo(1));
    }
}