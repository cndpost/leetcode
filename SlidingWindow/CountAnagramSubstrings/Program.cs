using System;
//very similar to the project of SubstringPermuteCheck and somewhat similar to ShortestCoveringSubstring
class Program
{
    static void Main()
    {
        string s = "cbaebabacd";
        string p = "abc";

        Console.WriteLine("s = " + s);
        Console.WriteLine("p = " + p);

        int result = CountAnagramSubstrings(s, p);

        Console.WriteLine("\nTotal anagram substrings of p found in s:");
        Console.WriteLine(result);
    }

    public static int CountAnagramSubstrings(string s, string p)
    {
        if (p.Length > s.Length)
            return 0;

        int[] need = new int[128];
        int[] window = new int[128];

        foreach (char c in p)
            need[c]++;

        int k = p.Length;
        int count = 0;

        for (int i = 0; i < k; i++)
            window[s[i]]++;

        if (Matches(need, window))
            count++;

        for (int i = k; i < s.Length; i++)
        {
            window[s[i]]++;
            window[s[i - k]]--;

            if (Matches(need, window))
                count++;
        }

        return count;
    }

    private static bool Matches(int[] a, int[] b)
    {
        for (int i = 0; i < 128; i++)
            if (a[i] != b[i])
                return false;
        return true;
    }
}
