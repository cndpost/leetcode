using System;

class Program
{
    static void Main()
    {
        int[] nums = { 10, 5, 2, 6 };
        int k = 100;

        Console.WriteLine("Input array:");
        Console.WriteLine("[" + string.Join(", ", nums) + "]");
        Console.WriteLine("K = " + k);

        int result = CountSubarraysProductLessThanK(nums, k);

        Console.WriteLine("\nTotal number of subarrays with product < K:");
        Console.WriteLine(result);
    }

    public static int CountSubarraysProductLessThanK(int[] nums, int k)
    {
        if (k <= 1) return 0;

        int product = 1;
        int left = 0;
        int count = 0;

        for (int right = 0; right < nums.Length; right++)
        {
            product *= nums[right];

            while (product >= k)
            {
                product /= nums[left];
                left++;
            }

            count += right - left + 1;
        }

        return count;
    }
}
