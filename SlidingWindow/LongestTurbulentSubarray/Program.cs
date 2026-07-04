using System;

class Program
{
    static void Main()
    {
        int[] nums = { 9, 4, 2, 10, 7, 8, 8, 1, 9 };

        Console.WriteLine("Input array:");
        Console.WriteLine("[" + string.Join(", ", nums) + "]");

        int result = LongestTurbulent(nums);

        Console.WriteLine("\nLongest turbulent subarray length:");
        Console.WriteLine(result);
    }

    public static int LongestTurbulent(int[] nums)
    {
        if (nums.Length < 2)
            return nums.Length;

        int maxLen = 1;
        int left = 0;

        for (int right = 1; right < nums.Length; right++)
        {
            int cmp = Compare(nums[right - 1], nums[right]);

            if (cmp == 0)
            {
                left = right;
            }
            else if (right == nums.Length - 1 || cmp * Compare(nums[right], nums[right + 1]) != -1)
            {
                maxLen = Math.Max(maxLen, right - left + 1);
                left = right;
            }
        }

        return maxLen;
    }

    private static int Compare(int a, int b)
    {
        if (a < b) return -1;
        if (a > b) return 1;
        return 0;
    }
}
