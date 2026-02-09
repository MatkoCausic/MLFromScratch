using System;
using System.Diagnostics;
using System.IO;

static int Run(string file, string args, string workingDir)
{
    var psi = new ProcessStartInfo(file, args)
    {
        WorkingDirectory = workingDir,
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        UseShellExecute = false
    };

    using var p = Process.Start(psi)!;
    p.OutputDataReceived += (_, e) =>
    {
        if (e.Data != null)
            Console.WriteLine(e.Data);
    };
    p.ErrorDataReceived += (_, e) =>
    {
        if (e.Data != null)
            Console.Error.WriteLine(e.Data);
    };
    p.BeginOutputReadLine();
    p.BeginErrorReadLine();
    p.WaitForExit();
    return p.ExitCode;
}

var repoRoot = Directory.GetCurrentDirectory();

var csproj = Path.Combine(repoRoot, "MachineLearning", "Machine Learning.csproj");

var outDir = Path.Combine(
    Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
    "Builds", "Win"
);

Directory.CreateDirectory(outDir);

var args =
    $"publish \"{csproj}\" -c Release -r win-x64 --self-contained true " +
    $"-o \"{outDir}\" " +
    "/p:PublishSingleFile=true " +
    "/p:IncludeNativeLibrariesForSelfExtract=true";

Console.WriteLine($"Publishing to: {outDir}");
return Run("dotnet", args, repoRoot);