using System;

// the trick is just keep K elements in the Q. So the item wanted always at the top.
// so no need to to get it K-times.

class Program
{
    static void Main(string[] args)
    {
        int[] nums = { 7, 2, 9, 4, 1, 8, 3 };
        int k = 3;

        Console.WriteLine("Array:");
        PrintArray(nums);

        int result = KthLargest(nums, k);

        Console.WriteLine($"{k}-th largest value: {result}");
    }

    public static int KthLargest(int[] nums, int k)
    {
        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();

        foreach (int n in nums)
        {
            minHeap.Enqueue(n, n);

            if (minHeap.Count > k)
                minHeap.Dequeue();
        }

        return minHeap.Peek();
    }

    public static void PrintArray(int[] nums)
    {
        foreach (int n in nums)
            Console.Write(n + " ");
        Console.WriteLine();
    }
}
