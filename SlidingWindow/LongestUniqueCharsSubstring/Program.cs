using System;

class Program
{
    static void Main()
    {
        string input = "abcabcbb";

        Console.WriteLine("Input string: " + input);

        string longest = LongestUniqueSubstring(input);

        Console.WriteLine("Longest substring with all unique characters: " + longest);
    }

    public static string LongestUniqueSubstring(string s)
    {
        HashSet<char> window = new HashSet<char>();
        int left = 0;
        int bestStart = 0;
        int bestLength = 0;

        for (int right = 0; right < s.Length; right++)
        {
            while (window.Contains(s[right]))
            {
                window.Remove(s[left]);
                left++;
            }

            window.Add(s[right]);

            int currentLength = right - left + 1;
            if (currentLength > bestLength)
            {
                bestLength = currentLength;
                bestStart = left;
            }
        }

        return s.Substring(bestStart, bestLength);
    }
}
