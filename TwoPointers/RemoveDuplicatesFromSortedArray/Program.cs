using System;

class Program
{
    static void Main()
    {
        int[] nums = { 1, 1, 2, 2, 2, 3, 4, 4, 5 };

        Console.WriteLine("Original array:");
        Console.WriteLine("[" + string.Join(", ", nums) + "]");

        int k = RemoveDuplicates(nums);

        Console.WriteLine("\nAfter RemoveDuplicates:");
        Console.WriteLine("Unique count = " + k);
        Console.WriteLine("Deduplicated array (first k elements):");
        Console.WriteLine("[" + string.Join(", ", nums[..k]) + "]");
    }

    public static int RemoveDuplicates(int[] nums)
    {
        if (nums.Length == 0) return 0;

        int k = 1;

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] != nums[k - 1])
            {
                nums[k] = nums[i];
                k++;
            }
        }

        return k;
    }
}
