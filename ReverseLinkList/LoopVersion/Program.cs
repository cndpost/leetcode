using System;

public class ListNode
{
    public int Value;
    public ListNode Next;

    public ListNode(int value)
    {
        Value = value;
        Next = null;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        // Build test list: 1 → 2 → 3 → 4 → null
        ListNode head = new ListNode(1);
        head.Next = new ListNode(2);
        head.Next.Next = new ListNode(3);
        head.Next.Next.Next = new ListNode(4);

        Console.WriteLine("Original list:");
        PrintList(head);

        // Test iterative reverse
        ListNode reversedIterative = ReverseIterative(head);
        Console.WriteLine("\nReversed list (iterative):");
        PrintList(reversedIterative);

        Console.WriteLine("\nReverse again using recursive method:");
        // Reverse again using recursive method
        ListNode reversedRecursive = ReverseRecursive(reversedIterative);
        Console.WriteLine("\nReversed list (recursive):");
        PrintList(reversedRecursive);
    }

    // -----------------------------
    // Iterative reverse
    // -----------------------------
    public static ListNode ReverseIterative(ListNode head)
    {
        ListNode prev = null;
        ListNode current = head;

        while (current != null)
        {
            ListNode next = current.Next;
            current.Next = prev;
            prev = current;
            current = next;
        }

        return prev;
    }

    // -----------------------------
    // Recursive reverse
    // -----------------------------
    public static ListNode ReverseRecursive(ListNode head)
    {
        if (head == null || head.Next == null)
            return head;

        ListNode newHead = ReverseRecursive(head.Next);

        head.Next.Next = head;
        head.Next = null;

        return newHead;
    }

    // -----------------------------
    // Helper: print list
    // -----------------------------
    public static void PrintList(ListNode head)
    {
        ListNode current = head;
        while (current != null)
        {
            Console.Write(current.Value + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }
}
