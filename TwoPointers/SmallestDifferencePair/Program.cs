using System;

class Program
{
    static void Main()
    {
        int[] a = { 1, 4, 10, 20 };
        int[] b = { 2, 15, 30 };

        Console.WriteLine("Array A: [" + string.Join(", ", a) + "]");
        Console.WriteLine("Array B: [" + string.Join(", ", b) + "]");

        int result = MinDifference(a, b);

        Console.WriteLine("\nMinimum difference between any pair: " + result);
    }

    public static int MinDifference(int[] a, int[] b)
    {
        int i = 0;
        int j = 0;
        int minDiff = int.MaxValue;

        while (i < a.Length && j < b.Length)
        {
            int diff = Math.Abs(a[i] - b[j]);
            if (diff < minDiff)
                minDiff = diff;

            if (a[i] < b[j])
                i++;
            else
                j++;
        }

        return minDiff;
    }
}
