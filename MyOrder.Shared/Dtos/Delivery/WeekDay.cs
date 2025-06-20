using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.Delivery;

public record WeekDay(
    string? WeekDayName,
    Field<bool?>? IsOpenedMorning,
    Field<TimeSpan?>? MorningOpeningTime,
    Field<TimeSpan?>? MorningClosingTime,
    Field<bool?>? IsOpenedAfternoon,
    Field<TimeSpan?>? AfternoonOpeningTime,
    Field<TimeSpan?>? AfternoonClosingTime);