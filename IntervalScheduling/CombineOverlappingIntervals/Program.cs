using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int[][] intervals =
        {
            new[] {1, 3},
            new[] {2, 6},
            new[] {8, 10},
            new[] {15, 18},
            new[] {17, 20}
        };

        Console.WriteLine("Original Intervals:");
        foreach (var iv in intervals)
            Console.WriteLine($"[{iv[0]}, {iv[1]}]");

        var merged = MergeIntervals(intervals);

        Console.WriteLine("\nMerged Intervals:");
        foreach (var iv in merged)
            Console.WriteLine($"[{iv.start}, {iv.end}]");
    }

    public static List<(int start, int end)> MergeIntervals(int[][] intervals)
    {
        if (intervals.Length == 0)
            return new List<(int, int)>();

        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        var result = new List<(int start, int end)>();
        int curStart = intervals[0][0];
        int curEnd = intervals[0][1];

        foreach (var iv in intervals)
        {
            int s = iv[0];
            int e = iv[1];

            if (s <= curEnd)
            {
                curEnd = Math.Max(curEnd, e);
            }
            else
            {
                result.Add((curStart, curEnd));
                curStart = s;
                curEnd = e;
            }
        }

        result.Add((curStart, curEnd));

        return result;
    }
}
