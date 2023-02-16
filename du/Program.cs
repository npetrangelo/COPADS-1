// See https://aka.ms/new-console-template for more information

var help = """
Usage: du [-s] [-d] [-b] <path>
Summarize disk usage of the set of FILES, recursively for directories.
You MUST specify one of the parameters, -s, -d, or -b
-s Run in single threaded mode
-d Run in parallel mode (uses all available processors)
-b Run in both parallel and single threaded mode.
Runs parallel followed by sequential mode
""";

var mode = args[0];
var path = args[1];

Console.WriteLine($"mode: {mode}");
Console.WriteLine($"path: {path}");

switch (mode) {
    default:
        Console.WriteLine(help);
        break;
    case "-s":
        break;
    case "-d":
        break;
    case "-b":
        break;
}
