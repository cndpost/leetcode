using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[] nums = { 1, 5, 3, 4, 2, 5, 3 };
        int k = 2;

        Console.WriteLine("Input array:");
        Console.WriteLine("[" + string.Join(", ", nums) + "]");
        Console.WriteLine("K = " + k);

        int count = CountKDiffPairs(nums, k);

        Console.WriteLine("\nNumber of unique K-diff pairs: " + count);
    }

    public static int CountKDiffPairs(int[] nums, int k)
    {
        HashSet<int> seen = new HashSet<int>();
        HashSet<int> pairs = new HashSet<int>();

        foreach (int x in nums)
        {
            if (seen.Contains(x - k))
                pairs.Add(x - k);

            if (seen.Contains(x + k))
                pairs.Add(x);

            seen.Add(x);
        }

        return pairs.Count;
    }
}
