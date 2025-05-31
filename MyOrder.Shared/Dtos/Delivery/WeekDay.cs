using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.Delivery;

public class WeekDay
{
    public string? WeekDayName { get; set; }
    public Field<bool?>? IsOpenedMorning { get; set; }
    public Field<TimeSpan?>? MorningOpeningTime { get; set; }
    public Field<TimeSpan?>? MorningClosingTime { get; set; }

    public Field<bool?>? IsOpenedAfternoon { get; set; }
    public Field<TimeSpan?>? AfternoonOpeningTime { get; set; }
    public Field<TimeSpan?>? AfternoonClosingTime { get; set; }
}
