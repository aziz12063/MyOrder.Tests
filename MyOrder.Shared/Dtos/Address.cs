using MyOrder.Generator;
using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos;

public record Address(
    [property: DisplayOnlyField]
    Field<int?>? IsSelected,
    string? Building,
    string? Street,
    string? Locality,
    string? ZipCode,
    string? City,
    string? Country);