using System;

class Program
{
    static void Main()
    {
        int[] nums = { 1, 0, 1, 1, 0, 0, 1, 1 };
        int k = 2;

        Console.WriteLine("Input array:");
        Console.WriteLine("[" + string.Join(", ", nums) + "]");
        Console.WriteLine("K = " + k);

        int result = LongestOnesAfterKFlips(nums, k);

        Console.WriteLine("\nLongest contiguous subarray of 1s after at most K flips:");
        Console.WriteLine(result);
    }

    public static int LongestOnesAfterKFlips(int[] nums, int k)
    {
        int left = 0;
        int zeros = 0;
        int maxLen = 0;

        for (int right = 0; right < nums.Length; right++)
        {
            if (nums[right] == 0)
                zeros++;

            while (zeros > k)
            {
                if (nums[left] == 0)
                    zeros--;
                left++;
            }

            maxLen = Math.Max(maxLen, right - left + 1);
        }

        return maxLen;
    }
}
