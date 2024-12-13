using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos;

public class Address
{
    public Field<int?>? IsSelected { get; set; }
    public string? Building { get; set; }
    public string? Street { get; set; }
    public string? Locality { get; set; }
    public string? ZipCode { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
}