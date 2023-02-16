namespace COPADS_1;

public class InvalidInputException : Exception {
    private static string _message = """
Usage: du [-s] [-d] [-b] <path>
Summarize disk usage of the set of FILES, recursively for directories.
You MUST specify one of the parameters, -s, -d, or -b
-s Run in single threaded mode
-d Run in parallel mode (uses all available processors)
-b Run in both parallel and single threaded mode.
Runs parallel followed by sequential mode
""";
    public InvalidInputException() : base(_message) { }
}