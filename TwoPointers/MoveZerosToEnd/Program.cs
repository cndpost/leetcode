using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> nums = new List<int> { 0, 1, 0, 3, 12, 0, 5 };

        Console.WriteLine("Input list:");
        Console.WriteLine("[" + string.Join(", ", nums) + "]");

        List<int> result = MoveZerosToEnd(nums);

        Console.WriteLine("\nOutput list (zeros moved to end):");
        Console.WriteLine("[" + string.Join(", ", result) + "]");
    }

    public static List<int> MoveZerosToEnd(List<int> nums)
    {
        List<int> result = new List<int>(nums.Count);

        foreach (int x in nums)
        {
            if (x != 0)
                result.Add(x);
        }

        int zeroCount = nums.Count - result.Count;
        for (int i = 0; i < zeroCount; i++)
            result.Add(0);

        return result;
    }
}
