using System.Diagnostics;
using System.Reflection;

namespace MyOrder.Services;

public class VersionInfoService
{
    public string FileVersion { get; }
    public string InformationalVersion { get; }

    public VersionInfoService()
    {
        var assembly = Assembly.GetExecutingAssembly();

        var fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
        FileVersion = fvi.FileVersion ?? "Unknown";

        InformationalVersion = assembly
            .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
            .InformationalVersion ?? "Unknown";
    }
}
