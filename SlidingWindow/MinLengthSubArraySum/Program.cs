using System;

class Program
{
    static void Main()
    {
        int[] nums = { 2, 3, 1, 2, 4, 3 };
        int target = 7;

        Console.WriteLine("Input array:");
        Console.WriteLine("[" + string.Join(", ", nums) + "]");
        Console.WriteLine("Target = " + target);

        int result = MinSubarrayLength(target, nums);

        Console.WriteLine("\nMinimum length of subarray with sum >= Target:");
        Console.WriteLine(result);
    }

    public static int MinSubarrayLength(int target, int[] nums)
    {
        int left = 0;
        int sum = 0;
        int minLen = int.MaxValue;

        for (int right = 0; right < nums.Length; right++)
        {
            sum += nums[right];

            while (sum >= target)
            {
                minLen = Math.Min(minLen, right - left + 1);
                sum -= nums[left];
                left++;
            }
        }

        return minLen == int.MaxValue ? 0 : minLen;
    }
}
