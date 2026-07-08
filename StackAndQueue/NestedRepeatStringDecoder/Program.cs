using System;
using System.Linq;

// the trick is to maintain two stack, one for count, one for inner strings

class Program
{
    static void Main(string[] args)
    {
        string[] tests =
        {
            "3[a]",
            "2[ab3[c]]",
            "10[x]",
            "3[a2[b]]",
            "2[abc]3[cd]ef",
            "3[z2[y3[x]]]"
        };

        Console.WriteLine("=== Nested Repeat String Decoder Test ===");

        foreach (var t in tests)
        {
            string result = DecodeString(t);
            Console.WriteLine($"Input:  {t}");
            Console.WriteLine($"Output: {result}");
            Console.WriteLine();
        }
    }

    public static string DecodeString(string s)
    {
        Stack<int> countStack = new Stack<int>();
        Stack<string> stringStack = new Stack<string>();
        string current = "";
        int k = 0;

        foreach (char c in s)
        {
            if (char.IsDigit(c))
            {
                k = k * 10 + (c - '0');
            }
            else if (c == '[')
            {
                countStack.Push(k);
                stringStack.Push(current);
                current = "";
                k = 0;
            }
            else if (c == ']')
            {
                int repeat = countStack.Pop();
                string prev = stringStack.Pop();
                current = prev + string.Concat(Enumerable.Repeat(current, repeat));
            }
            else
            {
                current += c;
            }
        }

        return current;
    }
}
