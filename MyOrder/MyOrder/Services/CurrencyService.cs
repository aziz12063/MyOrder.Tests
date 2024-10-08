using System.Globalization;

namespace MyOrder.Services;

public class CurrencyService : ICurrencyService
{
    public string? Currency { get; private set; }
    public CultureInfo? CultureInfo { get; private set; }

    public void SetCurrency(string currency)
    {
        if (string.IsNullOrEmpty(Currency))
        {
            Currency = currency;
            try
            {
                CultureInfo = CultureInfo.CreateSpecificCulture(Currency);
            }
            catch(CultureNotFoundException)
            {
                CultureInfo = CultureInfo.InvariantCulture;
            }
        }
    }

    public CultureInfo? GetCurrency()
    {
        return CultureInfo;
    }
}
