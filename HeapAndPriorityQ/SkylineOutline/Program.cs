using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Buildings: [x, width, height]
        int[][] buildings =
        {
            new[] { 2, 4, 7 },   // spans 2 → 6
            new[] { 3, 5, 4 },   // spans 3 → 8
            new[] { 10, 3, 6 },  // spans 10 → 13
            new[] { 12, 4, 3 }   // spans 12 → 16
        };

        Console.WriteLine("Buildings:");
        foreach (var b in buildings)
            Console.WriteLine($"Start={b[0]}, Width={b[1]}, Height={b[2]}");

        var skyline = GetSkyline(buildings);

        Console.WriteLine("\nSkyline Outline:");
        foreach (var p in skyline)
            Console.WriteLine($"({p.x}, {p.height})");
    }

    public static List<(int x, int height)> GetSkyline(int[][] buildings)
    {
        var events = new List<(int x, int height, bool isStart)>();

        foreach (var b in buildings)
        {
            int x = b[0];
            int width = b[1];
            int height = b[2];

            events.Add((x, height, true));
            events.Add((x + width, height, false));
        }

        events.Sort((a, b) =>
        {
            if (a.x != b.x) return a.x.CompareTo(b.x);
            if (a.isStart != b.isStart) return a.isStart ? -1 : 1;
            return a.isStart
                ? b.height.CompareTo(a.height)
                : a.height.CompareTo(b.height);
        });

        var maxHeap = new PriorityQueue<int, int>(
            Comparer<int>.Create((a, b) => b.CompareTo(a))
        );

        var heightCount = new Dictionary<int, int>();
        var result = new List<(int x, int height)>();
        int prevMax = 0;

        foreach (var e in events)
        {
            if (e.isStart)
            {
                maxHeap.Enqueue(e.height, e.height);
                if (!heightCount.ContainsKey(e.height))
                    heightCount[e.height] = 0;
                heightCount[e.height]++;
            }
            else
            {
                heightCount[e.height]--;
                if (heightCount[e.height] == 0)
                    heightCount.Remove(e.height);
            }

            while (maxHeap.Count > 0 && !heightCount.ContainsKey(maxHeap.Peek()))
                maxHeap.Dequeue();

            int currMax = maxHeap.Count == 0 ? 0 : maxHeap.Peek();

            if (currMax != prevMax)
            {
                result.Add((e.x, currMax));
                prevMax = currMax;
            }
        }

        return result;
    }
}
