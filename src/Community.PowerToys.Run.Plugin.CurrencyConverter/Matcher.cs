#nullable enable
using System.Runtime.CompilerServices;

namespace Community.PowerToys.Run.Plugin.CurrencyConverter;

public class Matcher
{
    public static (double?, string?, string?) Match(string query)
    {
        var parts = query.Split(" ");
        try
        {
            // todo: region-agnostic numbering
            var value = double.Parse(parts[0].Replace(",", ""));
            var currencyFrom = parts[1].ToUpper();
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

            return thirdWord.Length == 3 ? (value, currencyFrom, parts[2]) : (value, currencyFrom, null);
        }
        catch (FormatException)
        {
            return (null, null, null);
        }
    }
}