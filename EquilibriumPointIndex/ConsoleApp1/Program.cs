using System;

class Program
{
    static void Main(string[] args)
    {
        int[] nums = { 1, 7, 3, 6, 5, 6 };

        Console.WriteLine("Array:");
        PrintArray(nums);

        int pivot = FindPivotIndex(nums);

        Console.WriteLine($"\nPivot Index (left sum == right sum): {pivot}");
    }

    public static int FindPivotIndex(int[] nums)
    {
        int total = 0;
        foreach (int n in nums)
            total += n;

        int leftSum = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            int rightSum = total - leftSum - nums[i];

            if (leftSum == rightSum)
                return i;

            leftSum += nums[i];
        }

        return -1;
    }

    public static void PrintArray(int[] nums)
    {
        foreach (int n in nums)
            Console.Write(n + " ");
        Console.WriteLine();
    }
}
