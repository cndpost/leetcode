using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = 19;

        Console.WriteLine("Input number: " + n);
        Console.WriteLine("\nSequence of sum-of-squares steps until a loop is detected:");

        PrintHappySequenceUntilLoop(n);

        bool result = IsHappy(n);

        Console.WriteLine("\nIs this number a happy number:");
        Console.WriteLine(result);
    }

    public static void PrintHappySequenceUntilLoop(int n)
    {
        HashSet<int> seen = new HashSet<int>();
        int current = n;

        while (!seen.Contains(current))
        {
            Console.WriteLine(current);
            seen.Add(current);
            current = SumOfSquares(current);
        }

        Console.WriteLine($"Loop detected at: {current}");
    }

    public static bool IsHappy(int n)
    {
        int slow = n;
        int fast = n;

        do
        {
            slow = SumOfSquares(slow);
            fast = SumOfSquares(SumOfSquares(fast));

            if (fast == 1)
                return true;

        } while (slow != fast);

        return slow == 1;
    }

    private static int SumOfSquares(int n)
    {
        int sum = 0;
        while (n > 0)
        {
            int digit = n % 10;
            sum += digit * digit;
            n /= 10;
        }
        return sum;
    }
}
