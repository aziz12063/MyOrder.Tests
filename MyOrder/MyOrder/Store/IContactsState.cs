using MyOrder.Shared.Dtos;

namespace MyOrder.Store;

public interface IContactsState
{
    public List<ContactDto?>? Contacts { get; }
    public List<ContactDto?>? FilteredContacts { get; }
    public bool IsLoading { get; }
}
