using System;
using System.Collections.Generic;

//You want the multiset intersection — meaning if a number
//appears k times in nums1 and m times in nums2, it should
//appear min(k, m) times in the result. This is the classic
//“intersection II” problem.

class Program
{
    static void Main()
    {
        // Test 1: has multiset intersection
        int[] nums1 = { 1, 2, 2, 3, 4 };
        int[] nums2 = { 2, 2, 3, 5 };

        Console.WriteLine("=== Test 1 ===");
        PrintArray(nums1);
        PrintArray(nums2);
        var result1 = MultisetIntersection(nums1, nums2);
        PrintResult(result1);

        // Test 2: no intersection
        int[] nums3 = { 10, 20, 30 };
        int[] nums4 = { 1, 2, 3 };

        Console.WriteLine("\n=== Test 2 ===");
        PrintArray(nums3);
        PrintArray(nums4);
        var result2 = MultisetIntersection(nums3, nums4);
        PrintResult(result2);
    }

    public static List<int> MultisetIntersection(int[] nums1, int[] nums2)
    {
        Dictionary<int, int> freq = new Dictionary<int, int>();
        List<int> result = new List<int>();

        foreach (int x in nums1)
        {
            if (!freq.ContainsKey(x))
                freq[x] = 0;
            freq[x]++;
        }

        foreach (int x in nums2)
        {
            if (freq.ContainsKey(x) && freq[x] > 0)
            {
                result.Add(x);
                freq[x]--;
            }
        }

        return result;
    }

    public static void PrintArray(int[] arr)
    {
        Console.Write("Array: ");
        foreach (int x in arr)
            Console.Write(x + " ");
        Console.WriteLine();
    }

    public static void PrintResult(List<int> result)
    {
        Console.Write("Multiset Intersection: ");
        if (result.Count == 0)
        {
            Console.WriteLine("None");
            return;
        }

        foreach (int x in result)
            Console.Write(x + " ");
        Console.WriteLine();
    }
}
