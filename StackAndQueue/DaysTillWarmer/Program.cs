using System;

// the trick is to push to a stack when still low, then  ans[prev] = i - prev;
// and prev = stack.Pop(). In other words, stack saves index, not array values,


class Program
{
    static void Main(string[] args)
    {
        int[] T = { 73, 74, 75, 71, 69, 72, 76, 73 };

        int[] ans = DailyTemperatures(T);

        Console.WriteLine("=== Daily Temperatures Test ===");
        Console.WriteLine("Temperatures: " + string.Join(", ", T));
        Console.WriteLine("Result:       " + string.Join(", ", ans));
    }

    public static int[] DailyTemperatures(int[] T)
    {
        int n = T.Length;
        int[] ans = new int[n];
        Stack<int> stack = new Stack<int>();   // stores indices

        for (int i = 0; i < n; i++)
        {
            while (stack.Count > 0 && T[i] > T[stack.Peek()])
            {
                int prev = stack.Pop();
                ans[prev] = i - prev;
            }
            stack.Push(i);
        }

        return ans;
    }
}
