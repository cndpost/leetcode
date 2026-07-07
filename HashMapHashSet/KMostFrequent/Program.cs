using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] nums = { 1, 1, 1, 2, 2, 3, 4, 4, 4, 4 };
        int k = 2;

        Console.WriteLine("Input array:");
        PrintArray(nums);
        Console.WriteLine("K = " + k);

        int[] result = TopKFrequent(nums, k);

        Console.WriteLine("\nTop K frequent numbers:");
        PrintArray(result);
    }

    public static int[] TopKFrequent(int[] nums, int k)
    {
        Dictionary<int, int> freq = new Dictionary<int, int>();

        foreach (int x in nums)
        {
            if (!freq.ContainsKey(x))
                freq[x] = 0;
            freq[x]++;
        }

        return freq
            .OrderByDescending(pair => pair.Value)
            .Take(k)
            .Select(pair => pair.Key)
            .ToArray();
    }

    public static void PrintArray(int[] arr)
    {
        foreach (int x in arr)
            Console.Write(x + " ");
        Console.WriteLine();
    }
}
