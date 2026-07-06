using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Example 1:
        // 0→1→2→3→1 (cycle length = 3)
        int[] next1 = { 1, 2, 3, 1 };

        Console.WriteLine("Test 1 next-array:");
        PrintArray(next1);
        Console.WriteLine("Shortest cycle length:");
        Console.WriteLine(ShortestCycle(next1));

        // Example 2:
        // 0→2→3→4→2 (cycle length = 3)
        // 1→5→1 (cycle length = 2)
        int[] next2 = { 2, 5, 3, 4, 2, 1 };

        Console.WriteLine("\nTest 2 next-array:");
        PrintArray(next2);
        Console.WriteLine("Shortest cycle length:");
        Console.WriteLine(ShortestCycle(next2));
    }

    public static int ShortestCycle(int[] next)
    {
        int n = next.Length;
        bool[] globalVisited = new bool[n];
        int shortest = int.MaxValue;

        for (int start = 0; start < n; start++)
        {
            if (globalVisited[start]) continue;

            Dictionary<int, int> stepIndex = new Dictionary<int, int>();
            int step = 0;
            int curr = start;

            while (true)
            {
                if (stepIndex.ContainsKey(curr))
                {
                    int cycleLength = step - stepIndex[curr];
                    shortest = Math.Min(shortest, cycleLength);
                    break;
                }

                if (globalVisited[curr])
                    break;

                globalVisited[curr] = true;
                stepIndex[curr] = step++;

                curr = next[curr];
            }
        }

        return shortest == int.MaxValue ? 0 : shortest;
    }

    public static void PrintArray(int[] arr)
    {
        foreach (int x in arr)
            Console.Write(x + " ");
        Console.WriteLine();
    }
}
