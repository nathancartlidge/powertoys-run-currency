#nullable enable

namespace Community.PowerToys.Run.Plugin.CurrencyConverter;

using System.Net.Http;
using System.Text.Json;

public class Api
{
    private static readonly HttpClient HttpClient = new();

    public static double? GetCurrency(double currencyAmount, string currencyFrom, string currencyTo)
    {
        try
        {
            var task = GetJsonResponseAsync($"https://api.frankfurter.app/latest?from={currencyFrom}&to={currencyTo}&amount={currencyAmount}");
            task.Wait();

            var result = task.Result;
            if (result.TryGetProperty("rates", out var rates))
            {
                return rates.GetProperty(currencyTo).GetDouble();
            }

            return null;
        }
        catch (Exception)
        {
            return null;
        }

    }
    
    public static async Task<JsonElement> GetJsonResponseAsync(string url)
    {
        try
        {
            var response = await HttpClient.GetAsync(url);
            
            response.EnsureSuccessStatusCode();
            
            var body = await response.Content.ReadAsStringAsync();
            var doc = JsonDocument.Parse(body);
            return doc.RootElement;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request error: {e.Message}");
            throw;
        }
        catch (JsonException e)
        {
            Console.WriteLine($"JSON parse error: {e.Message}");
            throw;
        }
    }
}