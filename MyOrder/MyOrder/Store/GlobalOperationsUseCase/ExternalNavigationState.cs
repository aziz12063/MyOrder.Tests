using Fluxor;

namespace MyOrder.Store.GlobalOperationsUseCase;

[FeatureState]
public record ExternalNavigationState(
    string Url,
    string Target)
{
    public ExternalNavigationState() : this(string.Empty, string.Empty) { }
}
