using System;
using System.Collections.Generic;


// the trick is to maintain two P Que, one for capital, one for profits.
// loop over all projects that is affordable and enque them into profit Q
// output the largest profit one out. loop K times.


class Program
{
    static void Main(string[] args)
    {
        int[] capital = { 0, 1, 2, 3 };
        int[] profits = { 1, 2, 3, 5 };
        int k = 3;
        int initialCapital = 0;

        Console.WriteLine("Capital Requirements:");
        PrintArray(capital);

        Console.WriteLine("Profits:");
        PrintArray(profits);

        var order = MaxProfitProjectOrder(capital, profits, k, initialCapital);

        Console.WriteLine($"\nProject Start Order (maximizing profit over {k} projects):");
        foreach (int idx in order)
            Console.WriteLine($"Project {idx}: Capital={capital[idx]}, Profit={profits[idx]}");
    }

    public static List<int> MaxProfitProjectOrder(int[] capital, int[] profits, int k, int initialCapital)
    {
        int n = capital.Length;

        var minCapitalHeap = new PriorityQueue<int, int>();
        var maxProfitHeap = new PriorityQueue<int, int>(
            Comparer<int>.Create((a, b) => b.CompareTo(a))
        );

        for (int i = 0; i < n; i++)
            minCapitalHeap.Enqueue(i, capital[i]);

        int W = initialCapital;
        var order = new List<int>();

        for (int i = 0; i < k; i++)
        {
            while (minCapitalHeap.Count > 0 && minCapitalHeap.Peek() <= W)
            {
                int idx = minCapitalHeap.Dequeue();
                maxProfitHeap.Enqueue(idx, profits[idx]);
            }

            if (maxProfitHeap.Count == 0)
                break;

            int best = maxProfitHeap.Dequeue();
            order.Add(best);
            W += profits[best];
        }

        return order;
    }

    public static void PrintArray(int[] arr)
    {
        foreach (var x in arr)
            Console.Write(x + " ");
        Console.WriteLine();
    }
}
