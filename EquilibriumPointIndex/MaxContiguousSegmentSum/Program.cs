using System;

class Program
{
    static void Main(string[] args)
    {
        int[] nums = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };

        Console.WriteLine("Array:");
        PrintArray(nums);

        int maxSum = MaxContiguousSum(nums);

        Console.WriteLine($"\nLargest Contiguous Segment Sum: {maxSum}");
    }

    public static int MaxContiguousSum(int[] nums)
    {
        int maxSoFar = nums[0];
        int current = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            current = Math.Max(nums[i], current + nums[i]);
            maxSoFar = Math.Max(maxSoFar, current);
        }

        return maxSoFar;
    }

    public static void PrintArray(int[] nums)
    {
        foreach (int n in nums)
            Console.Write(n + " ");
        Console.WriteLine();
    }
}
