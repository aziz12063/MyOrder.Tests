using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace MyOrder.Tests.MarkupRegression;

public static class ModuleInitializer
{
    [ModuleInitializer]
    public static void Init()
    {
        // Install Playwright browsers automatically in CI/local
        VerifyPlaywright.Initialize(installPlaywright: true);
        
        VerifierSettings.AddScrubber(sb =>
        {
            var s = sb.ToString();

            s = Regex.Replace(
                s,
                @"\s_bl_[^\s=]+=""[^""]*""",
                string.Empty,
                RegexOptions.IgnoreCase
                );
            s = Regex.Replace(
                s,
                @"(@keyframes\s+)([A-Za-z0-9_-]{6,})",
                "$1kf",
                RegexOptions.IgnoreCase);
           

            s = Regex.Replace(
                s,
                @"\sid=""[^""]*""",
                string.Empty,
                RegexOptions.IgnoreCase
                );

            s = Regex.Replace(
               s,
               @"\sfor=""[^""]*""",
               string.Empty,
               RegexOptions.IgnoreCase
               );



            // Example: ids like id="radix-1234", aria-* referencing those ids

            s = Regex.Replace(s, @"\baria-(labelledby|controls)=""(radix|mud|popup)-\d+""",
                                  @"aria-$1=""$2-<id>""");


            // GUIDs
            s = Regex.Replace(s, @"\b[0-9a-fA-F]{8}\-[0-9a-fA-F\-]{27,}\b", "<guid>");

            // ISO timestamps
            s = Regex.Replace(s, @"\b\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}(\.\d+)?Z?\b", "<iso-datetime>");

            sb.Clear().Append(s);
        });

        // Scrub common noise
        VerifierSettings.ScrubLinesContaining("nonce=", "integrity=", "RequestVerificationToken");

        //VerifierSettings.AddScrubber(sb =>
        //{
        //    var s = sb.ToString();
        //    s = HtmlSanitizer.Sanitize(s);
        //    sb.Clear();
        //    sb.Append(s);
        //});
        //// Keep snapshots tidy
        //VerifierSettings.DerivePathInfo((_, __, ___, ____) => new PathInfo("Snapshots-E2E"));





    }
}
