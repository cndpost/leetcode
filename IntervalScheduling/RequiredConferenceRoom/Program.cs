using System;
using System.Collections.Generic;

// trick: use P queue length as the count of required meeting rooms.

class Program
{
    static void Main(string[] args)
    {
        // Meetings defined as [start, end]
        int[][] meetings =
        {
            new[] { 0, 30 },
            new[] { 5, 10 },
            new[] { 15, 20 },
            new[] { 25, 35 }
        };

        Console.WriteLine("Meetings:");
        foreach (var m in meetings)
            Console.WriteLine($"[{m[0]}, {m[1]}]");

        int rooms = MinMeetingRooms(meetings);

        Console.WriteLine($"\nMinimum number of conference rooms needed: {rooms}");
    }

    public static int MinMeetingRooms(int[][] meetings)
    {
        Array.Sort(meetings, (a, b) => a[0].CompareTo(b[0]));

        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();

        foreach (var m in meetings)
        {
            int start = m[0];
            int end = m[1];

            if (minHeap.Count > 0 && minHeap.Peek() <= start)
                minHeap.Dequeue();

            minHeap.Enqueue(end, end);
        }

        return minHeap.Count;
    }
}
