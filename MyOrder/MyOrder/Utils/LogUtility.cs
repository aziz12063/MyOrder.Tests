using System.Diagnostics;

namespace MyOrder.Utils;

public static class LogUtility
{
    public static string GetStackTrace()
    {
        var frames = new StackTrace(skipFrames: 1, fNeedFileInfo: true).GetFrames();

        if (frames.Length > 5)
        {
            frames = frames.Take(5).ToArray();
        }

        return new StackTrace(frames).ToString();
    }
}

