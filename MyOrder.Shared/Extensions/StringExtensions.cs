using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Shared.Extensions;

public static class StringExtensions
{
    public static List<string>? ParseTextToList(this string? str) =>
        str?.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)?
            .Where(line => !string.IsNullOrWhiteSpace(line))?.ToList();
}
