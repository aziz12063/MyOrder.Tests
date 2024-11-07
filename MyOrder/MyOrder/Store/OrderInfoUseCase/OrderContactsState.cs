using Fluxor;
using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.OrderInfoUseCase;

[FeatureState]
public class OrderContactsState : StateBase, IContactsState
{
    public List<ContactDto?>? Contacts { get; }
    public List<ContactDto?>? FilteredContacts { get; }

    public OrderContactsState() : base(true) { }

    public OrderContactsState(List<ContactDto?>? contactList, bool isFiltered) : base(false)
    {
        if (isFiltered)
            FilteredContacts = contactList;
        else
            Contacts = contactList;
    }
}
