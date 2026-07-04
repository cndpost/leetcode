using System;
using System.Collections.Generic;

public class SlidingWindowMedian
{
    private PriorityQueue<int, int> minHeap = new(); // upper half
    private PriorityQueue<int, int> maxHeap = new(Comparer<int>.Create((a, b) => b.CompareTo(a))); // lower half

    private void Add(int num)
    {
        if (maxHeap.Count == 0 || num <= maxHeap.Peek())
            maxHeap.Enqueue(num, num);
        else
            minHeap.Enqueue(num, num);

        Balance();
    }

    private void Remove(int num)
    {
        // Lazy removal: rebuild heaps without the removed element
        List<int> temp = new();

        if (maxHeap.Count > 0 && num <= maxHeap.Peek())
        {
            while (maxHeap.Count > 0)
            {
                int x = maxHeap.Dequeue();
                if (x != num) temp.Add(x);
                else break;
            }
            foreach (var x in temp) maxHeap.Enqueue(x, x);
        }
        else
        {
            while (minHeap.Count > 0)
            {
                int x = minHeap.Dequeue();
                if (x != num) temp.Add(x);
                else break;
            }
            foreach (var x in temp) minHeap.Enqueue(x, x);
        }

        Balance();
    }

    private void Balance()
    {
        if (maxHeap.Count > minHeap.Count + 1)
            minHeap.Enqueue(maxHeap.Dequeue(), maxHeap.Peek());

        else if (minHeap.Count > maxHeap.Count)
            maxHeap.Enqueue(minHeap.Dequeue(), minHeap.Peek());
    }

    private double GetMedian()
    {
        if (maxHeap.Count == minHeap.Count)
            return ((double)maxHeap.Peek() + minHeap.Peek()) / 2.0;

        return maxHeap.Peek();
    }

    public double[] MedianSlidingWindow(int[] nums, int k)
    {
        double[] result = new double[nums.Length - k + 1];

        for (int i = 0; i < nums.Length; i++)
        {
            Add(nums[i]);

            if (i >= k - 1)
            {
                result[i - k + 1] = GetMedian();
                Remove(nums[i - k + 1]);
            }
        }

        return result;
    }
}

class Program
{
    static void Main()
    {
        int[] nums = { 1, 3, -1, -3, 5, 3, 6, 7 };
        int k = 3;

        Console.WriteLine("Input array:");
        Console.WriteLine("[" + string.Join(", ", nums) + "]");
        Console.WriteLine("K = " + k);

        SlidingWindowMedian swm = new SlidingWindowMedian();
        double[] medians = swm.MedianSlidingWindow(nums, k);

        Console.WriteLine("\nSliding window medians:");
        Console.WriteLine("[" + string.Join(", ", medians) + "]");
    }
}
