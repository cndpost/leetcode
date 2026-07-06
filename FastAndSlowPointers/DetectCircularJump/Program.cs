using System;

class Program
{
    static void Main()
    {
        // Example array
        // Jumps: 0→2→3→1→4→0 (cycle)
        int[] nums = { 2, 3, 1, 1, 4 };

        Console.WriteLine("Input array:");
        PrintArray(nums);

        bool hasCycle = HasCircularJump(nums);

        Console.WriteLine("\nHas circular jump cycle:");
        Console.WriteLine(hasCycle);
    }

    public static bool HasCircularJump(int[] nums)
    {
        int slow = 0;
        int fast = 0;

        do
        {
            slow = NextIndex(nums, slow);
            fast = NextIndex(nums, NextIndex(nums, fast));

            if (slow == fast)
                return true;

        } while (true);
    }

    private static int NextIndex(int[] nums, int i)
    {
        int n = nums.Length;
        return (i + nums[i]) % n;
    }

    public static void PrintArray(int[] nums)
    {
        foreach (int x in nums)
            Console.Write(x + " ");
        Console.WriteLine();
    }
}
