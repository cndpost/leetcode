using System;

//this one uses two pinters and more simplier.

class Program
{
    static void Main(string[] args)
    {
        int[] nums = { 1, 3, -1, -3, 5, 3, 6, 7 };
        int k = 3;

        int[] result = MaxSlidingWindowSimple(nums, k);

        Console.WriteLine("=== Sliding Window Maximum (Simple) ===");
        Console.WriteLine("nums: " + string.Join(", ", nums));
        Console.WriteLine("k = " + k);
        Console.WriteLine("Result: " + string.Join(", ", result));
    }

    public static int[] MaxSlidingWindowSimple(int[] nums, int k)
    {
        int n = nums.Length;
        int[] result = new int[n - k + 1];

        for (int left = 0; left <= n - k; left++)
        {
            int right = left + k - 1;
            int max = int.MinValue;

            for (int i = left; i <= right; i++)
                max = Math.Max(max, nums[i]);

            result[left] = max;
        }

        return result;
    }
}
