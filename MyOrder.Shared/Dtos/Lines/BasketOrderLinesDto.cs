namespace MyOrder.Shared.Dtos.Lines;

public class BasketOrderLinesDto
{
#warning TODO: Refactor to use BasketLineDto only
    public List<BasketLineDto?>? lines { get; set; }
}
