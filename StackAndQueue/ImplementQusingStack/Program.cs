using System;
using System.Collections.Generic;
// the trick is to use two stacks, one for input, one for output. Pour the input to output when output empty

class Program
{
    static void Main(string[] args)
    {
        QueueUsingStacks q = new QueueUsingStacks();

        Console.WriteLine("=== Queue Using Two Stacks Test ===");

        q.Push(10);
        Print("Push(10)", q);

        q.Push(20);
        Print("Push(20)", q);

        q.Push(30);
        Print("Push(30)", q);

        Console.WriteLine("Pop(): " + q.Pop());
        Print("After Pop()", q);

        Console.WriteLine("Top(): " + q.Top());
        Print("After Top()", q);

        q.Push(40);
        Print("Push(40)", q);

        Console.WriteLine("Pop(): " + q.Pop());
        Print("After Pop()", q);

        Console.WriteLine("Pop(): " + q.Pop());
        Print("After Pop()", q);

        Console.WriteLine("Pop(): " + q.Pop());
        Print("After Pop()", q);
    }

    static void Print(string operation, QueueUsingStacks q)
    {
        Console.WriteLine(operation);

        if (!q.IsEmpty())
            Console.WriteLine($"   Top = {q.Top()}");
        else
            Console.WriteLine("   Queue is empty");

        Console.WriteLine();
    }
}


public class QueueUsingStacks
{
    private Stack<int> inStack = new Stack<int>();
    private Stack<int> outStack = new Stack<int>();

    public void Push(int x)
    {
        inStack.Push(x);
    }

    public int Pop()
    {
        MoveIfNeeded();
        return outStack.Pop();
    }

    public int Top()
    {
        MoveIfNeeded();
        return outStack.Peek();
    }

    public bool IsEmpty()
    {
        return inStack.Count == 0 && outStack.Count == 0;
    }

    private void MoveIfNeeded()
    {
        if (outStack.Count == 0)
        {
            while (inStack.Count > 0)
                outStack.Push(inStack.Pop());
        }
    }
}
