using System.Globalization;

namespace MyOrder.Services;

public interface ICurrencyService
{
    public string? Currency { get; }
    public CultureInfo? CultureInfo { get; }

    public void SetCurrency(string currency);

    public CultureInfo? GetCurrency();
    
}
