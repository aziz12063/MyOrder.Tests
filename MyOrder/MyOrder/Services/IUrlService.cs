namespace MyOrder.Services;

public interface IUrlService
{
    string GetBasketUrl(string basketId);
    string GetErrorUrl();
    
}
