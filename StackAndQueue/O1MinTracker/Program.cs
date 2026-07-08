using System;
using System.Collections.Generic;

using System;

class Program
{
    static void Main(string[] args)
    {
        MinStack ms = new MinStack();

        Console.WriteLine("=== MinStack Test ===");

        ms.Push(5);
        Print("Push(5)", ms);

        ms.Push(3);
        Print("Push(3)", ms);

        ms.Push(7);
        Print("Push(7)", ms);

        ms.Push(2);
        Print("Push(2)", ms);

        ms.Pop();
        Print("Pop()", ms);

        ms.Pop();
        Print("Pop()", ms);

        ms.Pop();
        Print("Pop()", ms);
    }

    static void Print(string operation, MinStack ms)
    {
        Console.WriteLine(operation);

        Console.WriteLine($"   Top = {ms.Top()}");
        Console.WriteLine($"   Min = {ms.GetMin()}");
        Console.WriteLine();
    }
}


public class MinStack
{
    private Stack<int> mainStack = new Stack<int>();
    private Stack<int> minStack = new Stack<int>();

    public void Push(int x)
    {
        mainStack.Push(x);

        if (minStack.Count == 0)
            minStack.Push(x);
        else
            minStack.Push(Math.Min(x, minStack.Peek()));
    }

    public void Pop()
    {
        if (mainStack.Count > 0)
        {
            mainStack.Pop();
            minStack.Pop();
        }
    }

    public int Top()
    {
        return mainStack.Peek();
    }

    public int GetMin()
    {
        return minStack.Peek();
    }
}
