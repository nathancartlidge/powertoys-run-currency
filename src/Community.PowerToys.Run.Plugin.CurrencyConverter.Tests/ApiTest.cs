using System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Community.PowerToys.Run.Plugin.CurrencyConverter.Tests;

[TestClass]
[TestSubject(typeof(Api))]
public class ExactLookupTest
{
    private readonly Api _api = new();
    
    [TestMethod]
    public void TestSimpleMatch()
    {
        
    }
}