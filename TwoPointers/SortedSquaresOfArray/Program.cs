using System;

class Program
{
    static void Main()
    {
        int[] nums = { -7, -3, 0, 2, 5 };

        Console.WriteLine("Input array:");
        Console.WriteLine("[" + string.Join(", ", nums) + "]");

        int[] squared = SortedSquares(nums);

        Console.WriteLine("\nSorted squares:");
        Console.WriteLine("[" + string.Join(", ", squared) + "]");
    }

    public static int[] SortedSquares(int[] nums)
    {
        int n = nums.Length;
        int left = 0;
        int right = n - 1;
        int[] result = new int[n];
        int k = n - 1;

        while (left <= right)
        {
            int leftSq = nums[left] * nums[left];
            int rightSq = nums[right] * nums[right];

            if (leftSq > rightSq)
            {
                result[k] = leftSq;
                left++;
            }
            else
            {
                result[k] = rightSq;
                right--;
            }

            k--;
        }

        return result;
    }
}
