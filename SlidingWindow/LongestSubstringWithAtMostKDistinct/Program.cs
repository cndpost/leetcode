using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string s = "AABACBEA";
        int k = 2;

        Console.WriteLine("Input string: " + s);
        Console.WriteLine("K = " + k);

        int result = LongestSubstringKDistinct(s, k);

        Console.WriteLine("\nLongest substring length with no more than K distinct characters:");
        Console.WriteLine(result);
    }

    public static int LongestSubstringKDistinct(string s, int k)
    {
        if (k == 0) return 0;

        Dictionary<char, int> freq = new Dictionary<char, int>();
        int left = 0;
        int maxLen = 0;

        for (int right = 0; right < s.Length; right++)
        {
            char c = s[right];

            if (!freq.ContainsKey(c))
                freq[c] = 0;
            freq[c]++;

            while (freq.Count > k)
            {
                char leftChar = s[left];
                freq[leftChar]--;
                if (freq[leftChar] == 0)
                    freq.Remove(leftChar);
                left++;
            }

            maxLen = Math.Max(maxLen, right - left + 1);
        }

        return maxLen;
    }
}
