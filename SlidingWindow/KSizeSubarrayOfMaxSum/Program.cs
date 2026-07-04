using System;

class Program
{
    static void Main()
    {
        int[] nums = { 2, 1, 5, 1, 3, 2 };
        int k = 3;

        Console.WriteLine("Input array:");
        Console.WriteLine("[" + string.Join(", ", nums) + "]");
        Console.WriteLine("K = " + k);

        int result = MaxSumSubarrayK(nums, k);

        Console.WriteLine("\nMaximum sum of any contiguous subarray of size K:");
        Console.WriteLine(result);
    }

    public static int MaxSumSubarrayK(int[] nums, int k)
    {
        int windowSum = 0;

        for (int i = 0; i < k; i++)
            windowSum += nums[i];

        int maxSum = windowSum;

        for (int i = k; i < nums.Length; i++)
        {
            windowSum += nums[i] - nums[i - k];
            if (windowSum > maxSum)
                maxSum = windowSum;
        }

        return maxSum;
    }
}
