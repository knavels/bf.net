using System.Diagnostics;

namespace bf;

public static class SystemHelper
{
    public static string GetLibraryPath(string lib)
    {
        //cmd command
        var command = $"which {lib}";

        // '/c' tells cmd that we want it to execute the command that follows, and then exit.
        var procStartInfo = new ProcessStartInfo("cmd", "/c " + command)
        {
            // The following commands are needed to redirect the standard output. 
            //This means that it will be redirected to the Process.StandardOutput StreamReader.
            RedirectStandardOutput = true,
            UseShellExecute = false,
            // Do not create the black window.
            CreateNoWindow = true
        };

        // Now we create a process, assign its ProcessStartInfo and start it
        var proc = new Process();
        proc.StartInfo = procStartInfo;
        proc.Start();

        // Get the output into a string
        return proc.StandardOutput.ReadToEnd().Trim();
    }
}