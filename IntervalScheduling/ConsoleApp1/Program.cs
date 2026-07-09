using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Trips defined as [pickup, dropoff]
        int[][] trips =
        {
            new[] {2, 7},
            new[] {3, 6},
            new[] {5, 9},
            new[] {10, 12}
        };

        int capacity = 2;

        Console.WriteLine("Carpool Trips:");
        foreach (var t in trips)
            Console.WriteLine($"Pickup={t[0]}, Dropoff={t[1]}");

        bool ok = CanHandleCarpool(trips, capacity);

        Console.WriteLine($"\nCapacity = {capacity}");
        Console.WriteLine($"Carpool feasible without exceeding capacity: {ok}");
    }

    public static bool CanHandleCarpool(int[][] trips, int capacity)
    {
        Array.Sort(trips, (a, b) => a[0].CompareTo(b[0]));

        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
        int passengers = 0;

        foreach (var t in trips)
        {
            int pickup = t[0];
            int dropoff = t[1];

            while (minHeap.Count > 0 && minHeap.Peek() <= pickup)
            {
                minHeap.Dequeue();
                passengers--;
            }

            minHeap.Enqueue(dropoff, dropoff);
            passengers++;

            if (passengers > capacity)
                return false;
        }

        return true;
    }
}
