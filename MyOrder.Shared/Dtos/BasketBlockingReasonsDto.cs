using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos;

public class BasketBlockingReasonsDto
{
    public List<BasketBlockingReasonDto?>? BlockingReasons { get; set; }
}

public class BasketBlockingReasonDto
{
    public Field<string?>? ReasonId { get; set; }
    public Field<string?>? Description { get; set; }
    public Field<bool?>? IsActive { get; set; }
    public Field<string?>? Comment { get; set; }
}
