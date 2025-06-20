using MyOrder.Shared.Dtos.SharedComponents;
using System.Collections.Immutable;

namespace MyOrder.Shared.Dtos.Delivery;
public record DeliveryAccountDraft(
    // ====================================================================
    string? AccountSectionLabel,

    Field<string?>? AccountId,
    Field<string?>? AccountType,
    Field<string?>? Name,
    Field<string?>? Recipient,

    // ====================================================================
    string? AddressSectionLabel,

    Field<string?>? Building,
    Field<string?>? Street,
    Field<string?>? Locality,
    Field<string?>? Zipcode,
    Field<string?>? City,
    Field<BasketValueDto?>? Country,

    // ====================================================================
    // Instruction de livraison

    Field<bool?>? Lift,
    Field<string?>? Floor,
    Field<string?>? DigiCode,
    Field<BasketValueDto?>? CarrierType,
    Field<bool?>? AppointmentRequired,
    Field<string?>? AppointmentEmail,
    Field<string?>? AppointmentEmailDefaultValue,
    Field<string?>? AppointmentDirectPhone,
    Field<string?>? AppointmentDirectPhoneDefaultValue,
    Field<string?>? DeliveryNote,

    // ====================================================================
    // Calendrier de livraison
    ImmutableList<WeekDay?>? WeekDays,

    // ====================================================================
    // Menus
    Field<string?>? StatusMessage,
    DeliveryAccountDraftActions? Actions,

    // ====================================================================
    // Lookup part
    ImmutableList<Address?>? AddressLookupResults
    );