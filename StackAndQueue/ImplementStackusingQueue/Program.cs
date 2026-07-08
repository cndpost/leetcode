using System;
using System.Collections.Generic;

// the trick is to do a rotate after each push call

class Program
{
    static void Main(string[] args)
    {
        StackUsingQueue s = new StackUsingQueue();

        Console.WriteLine("=== Stack Using One Queue Test ===");

        s.Push(10);
        Print("Push(10)", s);

        s.Push(20);
        Print("Push(20)", s);

        s.Push(30);
        Print("Push(30)", s);

        Console.WriteLine("Pop(): " + s.Pop());
        Print("After Pop()", s);

        Console.WriteLine("Top(): " + s.Top());
        Print("After Top()", s);

        s.Push(40);
        Print("Push(40)", s);

        Console.WriteLine("Pop(): " + s.Pop());
        Print("After Pop()", s);

        Console.WriteLine("Pop(): " + s.Pop());
        Print("After Pop()", s);

        Console.WriteLine("Pop(): " + s.Pop());
        Print("After Pop()", s);
    }

    static void Print(string operation, StackUsingQueue s)
    {
        Console.WriteLine(operation);

        if (!s.IsEmpty())
            Console.WriteLine($"   Top = {s.Top()}");
        else
            Console.WriteLine("   Stack is empty");

        Console.WriteLine();
    }
}


public class StackUsingQueue
{
    private Queue<int> q = new Queue<int>();

    public void Push(int x)
    {
        q.Enqueue(x);

        // Rotate the queue so the new element becomes the front
        int count = q.Count;
        while (count > 1)
        {
            q.Enqueue(q.Dequeue());
            count--;
        }
    }

    public int Pop()
    {
        return q.Dequeue();
    }

    public int Top()
    {
        return q.Peek();
    }

    public bool IsEmpty()
    {
        return q.Count == 0;
    }
}
