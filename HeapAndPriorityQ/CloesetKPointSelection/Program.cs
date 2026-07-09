using System;
using System.Collections.Generic;

// the trick is just need to calculate the distance square. No need to calculate sqrt.
// also just maintain K elements in the queue. So then output the whole queue.

class Program
{
    static void Main(string[] args)
    {
        var points = new List<(int x, int y)>
        {
            (1, 3),
            (3, 4),
            (2, -1),
            (5, 8),
            (-2, 2),
            (0, 1)
        };

        int k = 3;

        Console.WriteLine("Original Points:");
        PrintPoints(points);

        var closest = KClosestPoints(points, k);

        Console.WriteLine($"\n{k} Closest Points to Origin:");
        PrintPoints(closest);
    }

    public static List<(int x, int y)> KClosestPoints(List<(int x, int y)> points, int k)
    {
        PriorityQueue<(int x, int y), int> maxHeap =
            new PriorityQueue<(int x, int y), int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));

        foreach (var p in points)
        {
            int distSq = p.x * p.x + p.y * p.y;
            maxHeap.Enqueue(p, distSq);

            if (maxHeap.Count > k)
                maxHeap.Dequeue();
        }

        List<(int x, int y)> result = new List<(int x, int y)>();
        while (maxHeap.Count > 0)
            result.Add(maxHeap.Dequeue());

        return result;
    }

    public static void PrintPoints(List<(int x, int y)> pts)
    {
        foreach (var p in pts)
            Console.WriteLine($"({p.x}, {p.y})");
    }
}
