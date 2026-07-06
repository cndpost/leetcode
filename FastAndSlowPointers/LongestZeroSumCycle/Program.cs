using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // ---------- Test 1 ----------
        int[] nums1 = { 2, -1, 1, -2, 3 };

        Console.WriteLine("=== Test 1 ===");
        Console.WriteLine("Input array:");
        PrintArray(nums1);

        List<int> cycle1 = LongestZeroSumCycle(nums1);

        Console.WriteLine("Longest zero-sum cycle:");
        PrintCycle(cycle1);


        // ---------- Test 2 ----------
        int[] nums2 = { 1, 1, -2, 4, -4, 2 };

        Console.WriteLine("\n=== Test 2 ===");
        Console.WriteLine("Input array:");
        PrintArray(nums2);

        List<int> cycle2 = LongestZeroSumCycle(nums2);

        Console.WriteLine("Longest zero-sum cycle:");
        PrintCycle(cycle2);
    }


    // ---------------- Core Logic ----------------

    public static List<int> LongestZeroSumCycle(int[] nums)
    {
        int n = nums.Length;
        bool[] visited = new bool[n];
        List<int> bestCycle = new List<int>();

        for (int start = 0; start < n; start++)
        {
            if (visited[start]) continue;

            Dictionary<int, int> indexToStep = new Dictionary<int, int>();
            int step = 0;
            int curr = start;

            while (true)
            {
                if (indexToStep.ContainsKey(curr))
                {
                    // Build the cycle
                    List<int> cycle = new List<int>();
                    int pos = curr;

                    do
                    {
                        cycle.Add(nums[pos]);
                        pos = (pos + nums[pos]) % n;
                    }
                    while (pos != curr);

                    // Check sum
                    int sum = 0;
                    foreach (int x in cycle) sum += x;

                    if (sum == 0 && cycle.Count > bestCycle.Count)
                        bestCycle = cycle;

                    break;
                }

                if (visited[curr])
                    break;

                visited[curr] = true;
                indexToStep[curr] = step++;

                curr = (curr + nums[curr]) % n;
            }
        }

        return bestCycle;
    }


    // ---------------- Helpers ----------------

    public static void PrintArray(int[] nums)
    {
        foreach (int x in nums)
            Console.Write(x + " ");
        Console.WriteLine();
    }

    public static void PrintCycle(List<int> cycle)
    {
        if (cycle.Count == 0)
        {
            Console.WriteLine("No zero-sum cycle found.");
            return;
        }

        foreach (int x in cycle)
            Console.Write(x + " ");
        Console.WriteLine();
    }
}
