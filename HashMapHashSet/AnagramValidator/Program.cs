using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Test 1: anagram
        string s1 = "listen";
        string t1 = "silent";

        Console.WriteLine("=== Test 1 ===");
        Console.WriteLine($"s = {s1}, t = {t1}");
        Console.WriteLine("Are anagram: " + AreAnagram(s1, t1));

        // Test 2: not anagram
        string s2 = "hello";
        string t2 = "world";

        Console.WriteLine("\n=== Test 2 ===");
        Console.WriteLine($"s = {s2}, t = {t2}");
        Console.WriteLine("Are anagram: " + AreAnagram(s2, t2));
    }

    public static bool AreAnagram(string s, string t)
    {
        if (s.Length != t.Length)
            return false;

        Dictionary<char, int> freq = new Dictionary<char, int>();

        foreach (char c in s)
        {
            if (!freq.ContainsKey(c))
                freq[c] = 0;
            freq[c]++;
        }

        foreach (char c in t)
        {
            if (!freq.ContainsKey(c))
                return false;

            freq[c]--;
            if (freq[c] < 0)
                return false;
        }

        return true;
    }
}
