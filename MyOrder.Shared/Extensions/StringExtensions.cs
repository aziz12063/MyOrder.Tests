namespace MyOrder.Shared.Extensions;

public static class StringExtensions
{
    public static List<string>? ParseTextToList(this string? str) =>
        str?.Split(["\r\n", "\r", "\n"], StringSplitOptions.None)?
            .Where(line => !string.IsNullOrWhiteSpace(line))?.ToList();
}
