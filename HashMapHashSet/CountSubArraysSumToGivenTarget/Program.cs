using System;
using System.Collections.Generic;

//the first trick is to use prefix[i], which is sum of elements from 0 to i
//the second trick is to use target = predix - needed

class Program
{
    static void Main()
    {
        // Test 1
        int[] nums1 = { 1, 2, 3, -2, 2, 1 };
        int target1 = 3;

        Console.WriteLine("=== Test 1 ===");
        PrintArray(nums1);
        Console.WriteLine("Target = " + target1);
        Console.WriteLine("Total subarrays with sum = target: " +
            CountSubarraysWithSum(nums1, target1));

        // Test 2
        int[] nums2 = { 5, -1, 2, -1, 3 };
        int target2 = 4;

        Console.WriteLine("\n=== Test 2 ===");
        PrintArray(nums2);
        Console.WriteLine("Target = " + target2);
        Console.WriteLine("Total subarrays with sum = target: " +
            CountSubarraysWithSum(nums2, target2));
    }

    public static int CountSubarraysWithSum(int[] nums, int target)
    {
        Dictionary<int, int> prefixFreq = new Dictionary<int, int>();
        prefixFreq[0] = 1;

        int prefix = 0;
        int count = 0;

        foreach (int x in nums)
        {
            prefix += x;

            int needed = prefix - target;

            if (prefixFreq.ContainsKey(needed))
                count += prefixFreq[needed];

            if (!prefixFreq.ContainsKey(prefix))
                prefixFreq[prefix] = 0;

            prefixFreq[prefix]++;
        }

        return count;
    }

    public static void PrintArray(int[] nums)
    {
        Console.Write("Array: ");
        foreach (int x in nums)
            Console.Write(x + " ");
        Console.WriteLine();
    }
}
