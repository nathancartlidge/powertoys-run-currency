using System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Community.PowerToys.Run.Plugin.CurrencyConverter.Tests;

[TestClass]
[TestSubject(typeof(Api))]
public class ExactLookupTest
{
    [TestMethod]
    public void TestSimpleQuery()
    {
        // basic API test
        var task = Api.GetJsonResponseAsync("https://tt.nthn.uk/ping");
        task.Wait();

        var now = DateTime.Now;
        task.Result.GetProperty("current_time").TryGetDateTime(out var dt);
        var delta = dt - now;

        Assert.IsTrue(delta.Minutes < 1);
    }

    [TestMethod]
    public void FullTest()
    {
        // basic test - assumes 1 USD > 1 HKD
        var response = Api.GetCurrency(100, "USD", "HKD");
        Assert.IsTrue(response > 100);
    }
}