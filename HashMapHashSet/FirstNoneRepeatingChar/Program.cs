using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Test 1: has a non-repeating char
        string s1 = "swiss";
        Console.WriteLine("=== Test 1 ===");
        Console.WriteLine("Input: " + s1);
        char result1 = FirstNonRepeatingChar(s1);
        PrintResult(result1);

        // Test 2: all repeating
        string s2 = "aabbcc";
        Console.WriteLine("\n=== Test 2 ===");
        Console.WriteLine("Input: " + s2);
        char result2 = FirstNonRepeatingChar(s2);
        PrintResult(result2);
    }

    public static char FirstNonRepeatingChar(string s)
    {
        Dictionary<char, int> freq = new Dictionary<char, int>();

        foreach (char c in s)
        {
            if (!freq.ContainsKey(c))
                freq[c] = 0;
            freq[c]++;
        }

        foreach (char c in s)
        {
            if (freq[c] == 1)
                return c;
        }

        return '\0';
    }

    public static void PrintResult(char c)
    {
        if (c == '\0')
            Console.WriteLine("No non-repeating character found.");
        else
            Console.WriteLine("First non-repeating character: " + c);
    }
}
