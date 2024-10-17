using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Shared.Utils;

/// <summary>
/// Provides utility methods for formatting data for clipboard operations.
/// </summary>
public static class DataFormatter
{
    /// <summary>
    /// Generates a tab-separated string from the provided data, including headers.
    /// </summary>
    /// <typeparam name="T">The type of data items.</typeparam>
    /// <param name="data">The data items to format.</param>
    /// <param name="headers">The headers corresponding to the data properties.</param>
    /// <param name="selector">A function to select the properties from the data items.</param>
    /// <returns>A tab-separated string representation of the data.</returns>
    public static string GenerateTabSeparatedData<T>(IEnumerable<T> data, IEnumerable<string> headers, Func<T, IEnumerable<string>> selector)
    {
        ArgumentNullException.ThrowIfNull(data);
        ArgumentNullException.ThrowIfNull(headers);
        ArgumentNullException.ThrowIfNull(selector);

        var sb = new StringBuilder();

        // Append headers
        sb.AppendLine(string.Join("\t", headers));

        // Append data rows
        foreach (var item in data)
        {
            var row = selector(item).Select(EscapeForExcel);
            sb.AppendLine(string.Join("\t", row));
        }

        return sb.ToString();
    }

    /// <summary>
    /// Generates a CSV-formatted string from the provided data, including headers.
    /// </summary>
    /// <typeparam name="T">The type of data items.</typeparam>
    /// <param name="data">The data items to format.</param>
    /// <param name="headers">The headers corresponding to the data properties.</param>
    /// <param name="selector">A function to select the properties from the data items.</param>
    /// <returns>A CSV-formatted string representation of the data.</returns>
    public static string GenerateCsvData<T>(IEnumerable<T> data, IEnumerable<string> headers, Func<T, IEnumerable<string>> selector)
    {
        ArgumentNullException.ThrowIfNull(data);
        ArgumentNullException.ThrowIfNull(headers);
        ArgumentNullException.ThrowIfNull(selector);

        var sb = new StringBuilder();

        // Append headers
        sb.AppendLine(string.Join(",", headers.Select(EscapeForCsv)));

        // Append data rows
        foreach (var item in data)
        {
            var row = selector(item).Select(EscapeForCsv);
            sb.AppendLine(string.Join(",", row));
        }

        return sb.ToString();
    }

    /// <summary>
    /// Escapes special characters for Excel by removing tabs and newlines.
    /// </summary>
    /// <param name="input">The input string to escape.</param>
    /// <returns>Escaped string.</returns>
    public static string EscapeForExcel(string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;

        return input.Replace("\t", " ").Replace("\n", " ").Replace("\r", " ");
    }

    /// <summary>
    /// Escapes special characters for CSV by enclosing in quotes and escaping inner quotes.
    /// </summary>
    /// <param name="input">The input string to escape.</param>
    /// <returns>Escaped string.</returns>
    public static string EscapeForCsv(string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;

        var escaped = input.Replace("\"", "\"\"");

        if (input.Contains(',') || input.Contains('\n') || input.Contains('"'))
        {
            escaped = $"\"{escaped}\"";
        }

        return escaped;
    }
}