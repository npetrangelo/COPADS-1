// See https://aka.ms/new-console-template for more information
namespace COPADS_1;

class Program {
    private static string mode, path;
    
    static void Main(string[] args) {
        try {
            ParseArgs(args);
        } catch (InvalidInputException e) {
            Console.WriteLine(e.Message);
        }
    }

    internal static void ParseArgs(string[] args) {
        mode = args[0];
        path = args[1];

        switch (mode) {
            default:
                throw new InvalidInputException();
            case "-s":
                break;
            case "-d":
                break;
            case "-b":
                break;
        }
    }
}
