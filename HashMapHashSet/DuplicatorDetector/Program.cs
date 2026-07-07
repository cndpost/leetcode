using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Test 1: has duplicate
        int[] nums1 = { 1, 3, 5, 7, 3 };

        Console.WriteLine("=== Test 1 ===");
        PrintArray(nums1);
        Console.WriteLine("Has duplicate: " + HasDuplicate(nums1));

        // Test 2: no duplicate
        int[] nums2 = { 10, 20, 30, 40, 50 };

        Console.WriteLine("\n=== Test 2 ===");
        PrintArray(nums2);
        Console.WriteLine("Has duplicate: " + HasDuplicate(nums2));
    }

    public static bool HasDuplicate(int[] nums)
    {
        HashSet<int> seen = new HashSet<int>();

        foreach (int x in nums)
        {
            if (seen.Contains(x))
                return true;

            seen.Add(x);
        }

        return false;
    }

    public static void PrintArray(int[] nums)
    {
        foreach (int x in nums)
            Console.Write(x + " ");
        Console.WriteLine();
    }
}
