using System;

// the trick is to maintain a decreasing stack made of num2 and a dictionary


class Program
{
    static void Main(string[] args)
    {
        int[] num1 = { 4, 1, 2 };
        int[] num2 = { 1, 3, 4, 2 };

        int[] result = NextGreaterElement(num1, num2);

        Console.WriteLine("=== Next Greater Element Test ===");
        Console.WriteLine("num1: " + string.Join(", ", num1));
        Console.WriteLine("num2: " + string.Join(", ", num2));
        Console.WriteLine("Result: " + string.Join(", ", result));
    }

    public static int[] NextGreaterElement(int[] num1, int[] num2)
    {
        Dictionary<int, int> next = new Dictionary<int, int>();
        Stack<int> stack = new Stack<int>();

        foreach (int x in num2)
        {
            while (stack.Count > 0 && x > stack.Peek())
            {
                next[stack.Pop()] = x;
            }
            stack.Push(x);
        }

        while (stack.Count > 0)
            next[stack.Pop()] = -1;

        int[] result = new int[num1.Length];
        for (int i = 0; i < num1.Length; i++)
            result[i] = next[num1[i]];

        return result;
    }
}
