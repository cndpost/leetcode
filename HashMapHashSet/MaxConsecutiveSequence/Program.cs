using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Test 1
        int[] nums1 = { 100, 4, 200, 1, 3, 2 };
        Console.WriteLine("=== Test 1 ===");
        PrintArray(nums1);
        var seq1 = LongestContiguousSequence(nums1);
        PrintSequence(seq1);

        // Test 2
        int[] nums2 = { 10, 5, 6, 7, 20, 21, 22, 8 };
        Console.WriteLine("\n=== Test 2 ===");
        PrintArray(nums2);
        var seq2 = LongestContiguousSequence(nums2);
        PrintSequence(seq2);
    }

    public static List<int> LongestContiguousSequence(int[] nums)
    {
        HashSet<int> set = new HashSet<int>(nums);
        List<int> best = new List<int>();

        foreach (int x in set)
        {
            if (!set.Contains(x - 1))
            {
                int current = x;
                List<int> temp = new List<int>();

                while (set.Contains(current))
                {
                    temp.Add(current);
                    current++;
                }

                if (temp.Count > best.Count)
                    best = temp;
            }
        }

        best.Sort();
        return best;
    }

    public static void PrintArray(int[] nums)
    {
        Console.Write("Array: ");
        foreach (int x in nums)
            Console.Write(x + " ");
        Console.WriteLine();
    }

    public static void PrintSequence(List<int> seq)
    {
        Console.Write("Longest contiguous sequence: ");
        foreach (int x in seq)
            Console.Write(x + " ");
        Console.WriteLine();
    }
}
