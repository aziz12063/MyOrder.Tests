using Fluxor;
using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.DeliveryInfoUseCase;

[FeatureState]
public class DeliveryContactsState : StateBase, IContactsState
{
    public List<ContactDto?>? Contacts { get; }
    public List<ContactDto?>? FilteredContacts { get; }

    public DeliveryContactsState() : base(true) { }

    public DeliveryContactsState(List<ContactDto?>? contactList, bool isFiltered) : base(false)
    {
        if (isFiltered)
            FilteredContacts = contactList;
        else
            Contacts = contactList;
    }
}
