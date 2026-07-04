using System;

class Program
{
    static void Main()
    {
        string S = "ADOBECODEBANC";
        string T = "ABC";

        Console.WriteLine("S = " + S);
        Console.WriteLine("T = " + T);

        string result = MinWindow(S, T);

        Console.WriteLine("\nShortest substring of S containing all characters of T:");
        Console.WriteLine(result);
    }

    public static string MinWindow(string s, string t)
    {
        if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t))
            return "";

        int[] need = new int[128];
        int required = 0;

        foreach (char c in t)
        {
            need[c]++;
            required++;
        }

        int left = 0;
        int minLen = int.MaxValue;
        int minStart = 0;

        for (int right = 0; right < s.Length; right++)
        {
            char rc = s[right];

            if (need[rc] > 0)
                required--;

            need[rc]--;

            while (required == 0)
            {
                if (right - left + 1 < minLen)
                {
                    minLen = right - left + 1;
                    minStart = left;
                }

                char lc = s[left];
                need[lc]++;

                if (need[lc] > 0)
                    required++;

                left++;
            }
        }

        return minLen == int.MaxValue ? "" : s.Substring(minStart, minLen);
    }
}
