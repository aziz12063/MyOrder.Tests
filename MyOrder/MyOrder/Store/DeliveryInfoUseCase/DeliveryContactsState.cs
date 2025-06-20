using Fluxor;
using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.DeliveryInfoUseCase;

[FeatureState]
public record DeliveryContactsState(
    List<ContactDto?> Contacts,
    List<ContactDto?> FilteredContacts) : StateBase, IContactsState
{
    public DeliveryContactsState() : this([], []) { }
}
