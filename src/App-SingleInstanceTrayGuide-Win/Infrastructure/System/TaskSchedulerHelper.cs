using System.Diagnostics;

namespace App_SingleInstanceTrayGuide_Win.Infrastructure.System;

public class TaskSchedulerHelper
{
    public static bool TriggerTask(string taskName)
    {
        using (var process = new Process())
        {
            process.StartInfo = new ProcessStartInfo
            {
                FileName = "schtasks",
                Arguments = $"/Run /TN \"{taskName}\"",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            process.Start();
            process.WaitForExit();

            return process.ExitCode == 0;
        }
    }
}