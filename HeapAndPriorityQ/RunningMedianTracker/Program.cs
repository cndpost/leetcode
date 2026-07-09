using System;
using System.Collections.Generic;

// the trick is to use two P queue. One for max (high value at top), One for min,
// then do an average or outpu the extra one at max if it is higher
// to remember: Dequeue always gets the smallest priority ones out.

class Program
{
    static void Main(string[] args)
    {
        MedianFinder mf = new MedianFinder();

        int[] nums = { 5, 2, 8, 3, 9, 1 };

        Console.WriteLine("Adding numbers and printing median:");

        foreach (int n in nums)
        {
            mf.AddNumber(n);
            Console.WriteLine($"Added {n}, Median = {mf.FindMedian()}");
        }
    }
}

public class MedianFinder
{
    private PriorityQueue<int, int> minHeap;
    private PriorityQueue<int, int> maxHeap;

    public MedianFinder()
    {
        minHeap = new PriorityQueue<int, int>();
        maxHeap = new PriorityQueue<int, int>(
            Comparer<int>.Create((a, b) => b.CompareTo(a))
        );
    }

    public void AddNumber(int num)
    {
        maxHeap.Enqueue(num, num);

        int moved = maxHeap.Dequeue();
        minHeap.Enqueue(moved, moved);

        if (minHeap.Count > maxHeap.Count)
        {
            int back = minHeap.Dequeue();
            maxHeap.Enqueue(back, back);
        }
    }

    public double FindMedian()
    {
        if (maxHeap.Count > minHeap.Count)
            return maxHeap.Peek();

        return (maxHeap.Peek() + minHeap.Peek()) / 2.0;
    }
}
