using System;

class Program
{
    static void Main()
    {
        int[] nums = { 1, 3, 4, 5, 7, 11, 15 };
        int target = 9;

        int[] result = TwoSumSorted(nums, target);

        Console.WriteLine("Testing TwoSumSorted:");
        Console.WriteLine("Array: [" + string.Join(", ", nums) + "]");
        Console.WriteLine("Target: " + target);
        Console.WriteLine("Result: [" + result[0] + ", " + result[1] + "]");
    }

    public static int[] TwoSumSorted(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;

        while (left < right)
        {
            int sum = nums[left] + nums[right];

            if (sum == target)
            {
                return new int[] { left + 1, right + 1 };
            }
            else if (sum < target)
            {
                left++;
            }
            else
            {
                right--;
            }
        }

        return new int[] { -1, -1 };
    }
}
