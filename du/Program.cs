// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;

namespace COPADS_1;

class Program {
    private static string mode, path;
    
    static void Main(string[] args) {
        try {
            ParseArgs(args);
        } catch (Exception e) {
            Console.WriteLine(e.Message);
            return;
        }
        
        switch (mode) {
            case "-s":
                break;
            case "-d":
                break;
            case "-b":
                break;
        }
    }

    internal static void ParseArgs(string[] args) {
        mode = args[0];
        path = args[1];

        if (!Regex.Match(mode, @"-[sdb]").Success) {
            throw new InvalidInputException();
        }

        if (!Path.Exists(path)) {
            throw new Exception("Path does not exist");
        }
    }
}
