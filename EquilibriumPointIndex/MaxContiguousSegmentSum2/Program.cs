using System;

// this one proves a case like [5,-1,6] still works when 3 segment combines better than restart from middle.
//

class Program
{
    static void Main(string[] args)
    {
        int[] nums = { 5, -1, 6 };

        Console.WriteLine("Array:");
        PrintArray(nums);

        int maxSum = MaxContiguousSumWithSteps(nums);

        Console.WriteLine($"\nFinal Largest Contiguous Segment Sum: {maxSum}");
    }

    public static int MaxContiguousSumWithSteps(int[] nums)
    {
        int maxSoFar = nums[0];
        int current = nums[0];

        Console.WriteLine("\nKadane's Algorithm Steps:");
        Console.WriteLine($"Start: current = {current}, maxSoFar = {maxSoFar}");

        for (int i = 1; i < nums.Length; i++)
        {
            int x = nums[i];

            int option1 = x;
            int option2 = current + x;

            Console.WriteLine($"\nIndex {i}, value = {x}");
            Console.WriteLine($"Option1 (start new): {option1}");
            Console.WriteLine($"Option2 (extend):    {option2}");

            current = Math.Max(option1, option2);
            maxSoFar = Math.Max(maxSoFar, current);

            Console.WriteLine($"Chosen current = {current}");
            Console.WriteLine($"Updated maxSoFar = {maxSoFar}");
        }

        return maxSoFar;
    }

    public static void PrintArray(int[] nums)
    {
        foreach (int n in nums)
            Console.Write(n + " ");
        Console.WriteLine();
    }
}
