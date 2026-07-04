using System;

class Program
{
    static void Main()
    {
        string s1 = "abc";
        string s2 = "eidbaooo";

        Console.WriteLine("s1 = " + s1);
        Console.WriteLine("s2 = " + s2);

        bool result = ContainsPermutation(s1, s2);

        Console.WriteLine("\nDoes s2 contain a substring that is a permutation of s1: " + result);
    }

    public static bool ContainsPermutation(string s1, string s2)
    {
        if (s1.Length > s2.Length)
            return false;

        int[] need = new int[128];
        int[] window = new int[128];

        foreach (char c in s1)
            need[c]++;

        int k = s1.Length;

        for (int i = 0; i < k; i++)
            window[s2[i]]++;

        if (Matches(need, window))
            return true;

        for (int i = k; i < s2.Length; i++)
        {
            window[s2[i]]++;
            window[s2[i - k]]--;

            if (Matches(need, window))
                return true;
        }

        return false;
    }

    private static bool Matches(int[] a, int[] b)
    {
        for (int i = 0; i < 128; i++)
            if (a[i] != b[i])
                return false;
        return true;
    }
}
