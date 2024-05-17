using System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Community.PowerToys.Run.Plugin.CurrencyConverter.Tests;

[TestClass]
[TestSubject(typeof(Matcher))]
public class MatcherTest
{
    [TestMethod]
    public void TestMatcher()
    {
        Console.WriteLine("Testing a basic match");
        var (v, f, t) = Matcher.Match("100 USD to GBP");
        Assert.AreEqual(v, 100.0);
        Assert.AreEqual(f, "USD");
        Assert.AreEqual(t, "GBP");
        
        Console.WriteLine("Testing an invalid match");
        (v, f, t) = Matcher.Match("This is not a currency query");
        Assert.AreEqual(v, null);
        Assert.AreEqual(f, null);
        Assert.AreEqual(t, null);
        
        Console.WriteLine("Testing a partially valid match");
        (v, f, t) = Matcher.Match("75.24 USD to");
        Assert.AreEqual(v, 75.24);
        Assert.AreEqual(f, "USD");
        Assert.AreEqual(t, null);
    }
}