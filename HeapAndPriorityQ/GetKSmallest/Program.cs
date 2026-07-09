using System;
using System.Collections.Generic;

// the trick here is not making the compare value add a negative. but use a comparer lambda
// function as a input parameter in the P queue constructor.
// if want to use a negative sign instead of use a custom comparer, do it at enqueue time
// pq.Enqueue(n,-n);

class Program
{
    static void Main(string[] args)
    {
        int[] nums = { 9, 1, 5, 3, 7, 2, 8, 4, 6 };
        int k = 4;

        Console.WriteLine("Array:");
        PrintArray(nums);

        var smallest = KSmallest(nums, k);

        Console.WriteLine($"\n{k} Smallest Integers:");
        PrintArray(smallest.ToArray());
    }

    public static List<int> KSmallest(int[] nums, int k)
    {
        PriorityQueue<int, int> maxHeap =
            new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));

        foreach (int n in nums)
        {
            maxHeap.Enqueue(n, n);

            if (maxHeap.Count > k)
                maxHeap.Dequeue();
        }

        List<int> result = new List<int>();
        while (maxHeap.Count > 0)
            result.Add(maxHeap.Dequeue());

        result.Sort();
        return result;
    }

    public static void PrintArray(int[] nums)
    {
        foreach (int n in nums)
            Console.Write(n + " ");
        Console.WriteLine();
    }
}
