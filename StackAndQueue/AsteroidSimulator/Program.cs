using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[][] tests =
        {
            new[] { 5, 10, -5 },
            new[] { 8, -8 },
            new[] { 10, 2, -5 },
            new[] { -2, -1, 1, 2 },
            new[] { 1, -2, -2, -2 }
        };

        Console.WriteLine("=== Asteroid Collision Simulator Test ===");

        foreach (var t in tests)
        {
            int[] result = AsteroidCollision(t);
            Console.WriteLine($"Input:  [{string.Join(", ", t)}]");
            Console.WriteLine($"Output: [{string.Join(", ", result)}]");
            Console.WriteLine();
        }
    }

    public static int[] AsteroidCollision(int[] asteroids)
    {
        Stack<int> stack = new Stack<int>();

        foreach (int a in asteroids)
        {
            bool destroyed = false;

            while (stack.Count > 0 && stack.Peek() > 0 && a < 0)
            {
                int top = stack.Peek();
                if (Math.Abs(top) < Math.Abs(a))
                {
                    stack.Pop();
                    continue;
                }
                else if (Math.Abs(top) == Math.Abs(a))
                {
                    stack.Pop();
                    destroyed = true;
                    break;
                }
                else
                {
                    destroyed = true;
                    break;
                }
            }

            if (!destroyed)
                stack.Push(a);
        }

        return stack.Reverse().ToArray();
    }
}
