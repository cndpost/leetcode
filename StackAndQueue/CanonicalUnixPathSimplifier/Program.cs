using System;

class Program
{
    static void Main(string[] args)
    {
        string[] tests =
        {
            "/home/",
            "/../",
            "/home//foo/",
            "/a/./b/../../c/",
            "/a//b////c/d//././/.."
        };

        Console.WriteLine("=== Unix Path Simplifier Test ===");

        foreach (var t in tests)
        {
            string result = SimplifyPath(t);
            Console.WriteLine($"Input:  {t}");
            Console.WriteLine($"Output: {result}");
            Console.WriteLine();
        }
    }

    public static string SimplifyPath(string path)
    {
        string[] parts = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
        Stack<string> stack = new Stack<string>();

        foreach (var p in parts)
        {
            if (p == ".")
            {
                continue;
            }
            else if (p == "..")
            {
                if (stack.Count > 0)
                    stack.Pop();
            }
            else
            {
                stack.Push(p);
            }
        }

        return "/" + string.Join("/", stack.Reverse());
    }
}
