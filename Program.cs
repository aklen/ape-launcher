using System.Runtime.Versioning;
using Ape.Core;

namespace Ape.Launcher;

/// <summary>
/// Thin process entry: runs <see cref="ApeSystem"/> with the runtime JSON and whatever module DLLs
/// sit next to this executable (copied by the workspace build).
/// Network <c>host</c> (scene server / participant) is a Core role, not this executable.
/// </summary>
class Program
{
    [SupportedOSPlatform("linux")]
    [SupportedOSPlatform("macos")]
    [SupportedOSPlatform("windows")]
    static void Main(string[] args)
    {
        var configPath = args.FirstOrDefault(arg => !arg.StartsWith("--"));
        ApeSystem.Start(configPath, blocking: true);
    }
}
