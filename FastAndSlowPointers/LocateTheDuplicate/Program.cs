using System;

class Program
{
    static void Main()
    {
        // Example: array of length n+1 with values 1..n
        // Duplicate is 3
        int[] nums = { 1, 3, 4, 2, 3 };

        Console.WriteLine("Input array:");
        PrintArray(nums);

        int duplicate = FindDuplicate(nums);

        Console.WriteLine("\nDuplicate value:");
        Console.WriteLine(duplicate);
    }

    public static int FindDuplicate(int[] nums)
    {
        int slow = nums[0];
        int fast = nums[nums[0]];

        while (slow != fast)
        {
            slow = nums[slow];
            fast = nums[nums[fast]];
        }

        fast = 0;
        while (slow != fast)
        {
            slow = nums[slow];
            fast = nums[fast];
        }

        return slow;
    }

    public static void PrintArray(int[] nums)
    {
        foreach (int n in nums)
            Console.Write(n + " ");
        Console.WriteLine();
    }
}
