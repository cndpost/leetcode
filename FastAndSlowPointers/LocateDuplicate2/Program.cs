using System;
using System.Collections.Generic;

//this one uses hashset but cost n extra memory
class Program
{
    static void Main()
    {
        int[] nums = { 1, 3, 4, 2, 3 };

        Console.WriteLine("Input array:");
        PrintArray(nums);

        int duplicate = FindDuplicateHash(nums);

        Console.WriteLine("\nDuplicate value:");
        Console.WriteLine(duplicate);
    }

    public static int FindDuplicateHash(int[] nums)
    {
        HashSet<int> seen = new HashSet<int>();

        foreach (int x in nums)
        {
            if (seen.Contains(x))
                return x;

            seen.Add(x);
        }

        return -1;
    }

    public static void PrintArray(int[] nums)
    {
        foreach (int n in nums)
            Console.Write(n + " ");
        Console.WriteLine();
    }
}
