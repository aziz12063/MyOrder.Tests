using Fluxor;
using MyOrder.Store.GeneralInfoUseCase;
using System.Globalization;

namespace MyOrder.Services;

public class CurrencyService : ICurrencyService, IDisposable
{
    private readonly IState<GeneralInfoState> _generalInfoState;

    public string? Currency { get; private set; }
    public CultureInfo? CultureInfo { get; private set; }

    public CurrencyService(IState<GeneralInfoState> generalInfoState)
    {
        _generalInfoState = generalInfoState ?? throw new ArgumentNullException(nameof(generalInfoState));
        _generalInfoState.StateChanged += _generalInfoState_StateChanged;
    }

    private void _generalInfoState_StateChanged(object? sender, EventArgs e)
    {
        SetCurrency(_generalInfoState.Value.GeneralInfo.Company?.Locale ?? "fr-FR");
    }

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

    public void Dispose()
    {
        _generalInfoState.StateChanged -= _generalInfoState_StateChanged;
    }
}
