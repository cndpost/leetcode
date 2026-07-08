using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Reverse Polish Notation Evaluator Test ===");

        Test(new string[] { "2", "1", "+", "3", "*" });        // (2+1)*3 = 9
        Test(new string[] { "4", "13", "5", "/", "+" });       // 4 + (13/5) = 6
        Test(new string[] { "10", "6", "9", "3", "+", "-11",
                            "*", "/", "*", "17", "+", "5", "+" });
        // Classic LeetCode example = 22

        Test(new string[] { "5", "1", "2", "+", "4", "*", "+", "3", "-" });
        // 5 + ((1+2)*4) - 3 = 14
    }

    static void Test(string[] expr)
    {
        int result = EvaluateRPN(expr);
        Console.WriteLine($"Expression: {string.Join(" ", expr)}");
        Console.WriteLine($"Result: {result}");
        Console.WriteLine();
    }

    public static int EvaluateRPN(string[] tokens)
    {
        Stack<int> stack = new Stack<int>();

        foreach (var t in tokens)
        {
            if (t == "+" || t == "-" || t == "*" || t == "/")
            {
                int b = stack.Pop();
                int a = stack.Pop();

                int result = t switch
                {
                    "+" => a + b,
                    "-" => a - b,
                    "*" => a * b,
                    "/" => a / b,
                    _ => throw new Exception("Invalid operator")
                };

                stack.Push(result);
            }
            else
            {
                stack.Push(int.Parse(t));
            }
        }

        return stack.Pop();
    }
}
