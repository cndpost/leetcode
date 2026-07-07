using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Test 1: pair exists
        int[] nums1 = { 4, 7, 1, 9, 3 };
        int target1 = 10;

        Console.WriteLine("=== Test 1 ===");
        PrintArray(nums1);
        Console.WriteLine("Target = " + target1);

        var pair1 = TwoSumPair(nums1, target1);
        PrintPair(pair1);

        // Test 2: no pair exists
        int[] nums2 = { 5, 11, 20, 8 };
        int target2 = 100;

        Console.WriteLine("\n=== Test 2 ===");
        PrintArray(nums2);
        Console.WriteLine("Target = " + target2);

        var pair2 = TwoSumPair(nums2, target2);
        PrintPair(pair2);
    }

    public static (int, int)? TwoSumPair(int[] nums, int target)
    {
        HashSet<int> seen = new HashSet<int>();

        foreach (int x in nums)
        {
            int needed = target - x;

            if (seen.Contains(needed))
                return (needed, x);

            seen.Add(x);
        }

        return null;
    }

    public static void PrintArray(int[] nums)
    {
        foreach (int x in nums)
            Console.Write(x + " ");
        Console.WriteLine();
    }

    public static void PrintPair((int, int)? pair)
    {
        if (pair == null)
        {
            Console.WriteLine("No pair found.");
        }
        else
        {
            Console.WriteLine($"Pair found: {pair.Value.Item1} + {pair.Value.Item2}");
        }
    }
}
