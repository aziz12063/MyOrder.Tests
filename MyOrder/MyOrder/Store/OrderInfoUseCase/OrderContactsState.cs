using Fluxor;
using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.OrderInfoUseCase;

[FeatureState]
public record OrderContactsState(
        List<ContactDto?> Contacts,
        List<ContactDto?> FilteredContacts) : StateBase, IContactsState
{
    public OrderContactsState() : this([], []) { }
}
