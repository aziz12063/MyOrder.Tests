namespace MyOrder.Services;
public class BasketService
{
    public event Action<string> BasketIdChanged;

    private string _basketId;
    public string BasketId
    {
        get => _basketId;
        set
        {
            if (_basketId == value) return;
            _basketId = value;
            BasketIdChanged?.Invoke(_basketId);
        }
    }
}

