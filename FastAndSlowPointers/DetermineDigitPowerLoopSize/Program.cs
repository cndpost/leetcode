using System;

class Program
{
    static void Main()
    {
        int n = 57;
        int p = 2;

        Console.WriteLine($"Input n = {n}, p = {p}");
        int len = CycleLength(n, p);
        Console.WriteLine($"Cycle length = {len}");

        // Second example
        n = 89;
        p = 2;
        Console.WriteLine($"\nInput n = {n}, p = {p}");
        len = CycleLength(n, p);
        Console.WriteLine($"Cycle length = {len}");
    }

    public static int CycleLength(int n, int p)
    {
        int slow = Next(n, p);
        int fast = Next(Next(n, p), p);

        while (slow != fast)
        {
            slow = Next(slow, p);
            fast = Next(Next(fast, p), p);
        }

        int length = 1;
        fast = Next(slow, p);

        while (fast != slow)
        {
            fast = Next(fast, p);
            length++;
        }

        return length;
    }

    private static int Next(int x, int p)
    {
        int sum = 0;
        while (x > 0)
        {
            int d = x % 10;
            sum += (int)Math.Pow(d, p);
            x /= 10;
        }
        return sum;
    }
}
