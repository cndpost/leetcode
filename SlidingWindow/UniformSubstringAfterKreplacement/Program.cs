using System;

class Program
{
    static void Main()
    {
        string s = "AABABBA";
        int k = 1;

        Console.WriteLine("Input string: " + s);
        Console.WriteLine("K = " + k);

        int result = LongestRepeatingCharReplacement(s, k);

        Console.WriteLine("\nLongest substring of identical chars after at most K replacements:");
        Console.WriteLine(result);
    }

    public static int LongestRepeatingCharReplacement(string s, int k)
    {
        int[] freq = new int[26];
        int left = 0;
        int maxCount = 0;
        int maxLen = 0;

        for (int right = 0; right < s.Length; right++)
        {
            int idx = s[right] - 'A';
            freq[idx]++;

            maxCount = Math.Max(maxCount, freq[idx]);

            while ((right - left + 1) - maxCount > k)
            {
                freq[s[left] - 'A']--;
                left++;
            }

            maxLen = Math.Max(maxLen, right - left + 1);
        }

        return maxLen;
    }
}
