#nullable enable
using System.Runtime.CompilerServices;

namespace Community.PowerToys.Run.Plugin.CurrencyConverter;

public class Matcher
{
    public static (float?, string?, string?) Match(string query)
    {
        var parts = query.Split(" ");
        try
        {
            var value = float.Parse(parts[0]);
            var currencyFrom = parts[1];
            if (currencyFrom.Length != 3)
            {
                return (null, null, null);
            }
            
            if (parts.Length <= 2) return (value, currencyFrom, null);

            var thirdWord = parts[2].ToLower();
            if (thirdWord is "to" or "in" or "as" && parts.Length > 3 && parts[3].Length == 3)
            {
                return (value, currencyFrom, parts[3]);
            }

            if (thirdWord.Length == 3)
            {
                return (value, currencyFrom, parts[2]);
            }

            return (value, currencyFrom, null);
        }
        catch (FormatException)
        {
            return (null, null, null);
        }
    }
}