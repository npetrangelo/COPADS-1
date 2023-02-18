// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace COPADS_1;

class Program {
    private static string mode, path;
    internal static int numFolders = 0, numFiles = 0;
    internal static long numBytes = 0;
    internal static double spanSeconds = 0.0;
    static void Main(string[] args) {
        try {
            ParseArgs(args);
        } catch (Exception e) {
            Console.WriteLine(e.Message);
            return;
        }
        
        switch (mode) {
            case "-s":
                Do(Sequential, path);
                break;
            case "-d":
                Do(Distributed, path);
                break;
            case "-b":
                Do(Distributed, path);
                Console.WriteLine();
                Do(Sequential, path);
                break;
        }
    }

    internal static void ParseArgs(string[] args) {
        mode = args[0];
        path = Path.GetFullPath(args[1]);

        if (!Regex.Match(mode, @"-[sdb]").Success) {
            throw new InvalidInputException();
        }

        if (!Path.Exists(path)) {
            throw new Exception("Path does not exist");
        }
    }

    internal static void Do(Action<string> Method, string path) {
        numFolders = 0;
        numFiles = 0;
        numBytes = 0;
        var start = DateTime.Now;
        Method(path);
        var end = DateTime.Now;
        var span = end - start;
        spanSeconds = span.TotalSeconds;
        Console.WriteLine($"{Method.Method.Name} Calculated in: {spanSeconds}s");
        Console.WriteLine($"{numFolders} folders, {numFiles} files, {numBytes} bytes");
    }
    
    internal static void Sequential(string path) {
        if (!Directory.Exists(path)) {
            return;
        }
        
        foreach (var file in Directory.EnumerateFiles(path)) {
            numFiles++;
            numBytes += new FileInfo(file).Length;
        }
        
        foreach (var dir in Directory.EnumerateDirectories(path)) {
            numFolders++;
            try {
                Sequential(Path.GetFullPath(dir));
            } catch (UnauthorizedAccessException) {
                Console.WriteLine($"Unable to access {dir}");
            }
        }
    }

    internal static void Distributed(string path) {
        if (!Directory.Exists(path)) {
            return;
        }

        foreach (var file in Directory.EnumerateFiles(path)) {
            Interlocked.Increment(ref numFiles);
            Interlocked.Add(ref numBytes, new FileInfo(file).Length);
        }

        Parallel.ForEach(Directory.EnumerateDirectories(path), dir => {
            Interlocked.Increment(ref numFolders);
            try {
                Distributed(Path.GetFullPath(dir));
            } catch (UnauthorizedAccessException) {
                Console.WriteLine($"Unable to access {dir}");
            }
        });
    }
}
