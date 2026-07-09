using System;

// the trick is to recursively call FlatternDFS, and put child result into tail.

class Program
{
    static void Main(string[] args)
    {
        // Build multilevel list:
        //
        // 1 - 2 - 3 - 4
        //         |
        //         7 - 8 - 9
        //             |
        //             11 - 12
        //
        Node head = new Node(1);
        head.next = new Node(2); head.next.prev = head;
        head.next.next = new Node(3); head.next.next.prev = head.next;
        head.next.next.next = new Node(4); head.next.next.next.prev = head.next.next;

        Node child1 = new Node(7);
        child1.next = new Node(8); child1.next.prev = child1;
        child1.next.next = new Node(9); child1.next.next.prev = child1.next;

        Node child2 = new Node(11);
        child2.next = new Node(12); child2.next.prev = child2;

        head.next.next.child = child1;      // 3 -> child = 7
        child1.next.child = child2;         // 8 -> child = 11

        Console.WriteLine("Original Multilevel List (DFS print):");
        PrintDFS(head);

        Node flat = Flatten(head);

        Console.WriteLine("\nFlattened List:");
        PrintFlat(flat);
    }

    public static Node Flatten(Node head)
    {
        if (head == null) return head;

        Node dummy = new Node(0);
        Node tail = dummy;

        FlattenDFS(head, ref tail);

        dummy.next.prev = null;
        return dummy.next;
    }

    private static void FlattenDFS(Node curr, ref Node tail)
    {
        while (curr != null)
        {
            tail.next = curr;
            curr.prev = tail;
            tail = curr;

            Node next = curr.next;

            if (curr.child != null)
            {
                FlattenDFS(curr.child, ref tail);
                curr.child = null;
            }

            curr = next;
        }
    }

    public static void PrintDFS(Node head)
    {
        if (head == null) return;
        Console.Write(head.val + " ");
        if (head.child != null)
        {
            Console.Write("[child: ");
            PrintDFS(head.child);
            Console.Write("] ");
        }
        PrintDFS(head.next);
    }

    public static void PrintFlat(Node head)
    {
        Node curr = head;
        while (curr != null)
        {
            Console.Write(curr.val + " ");
            curr = curr.next;
        }
        Console.WriteLine();
    }
}

public class Node
{
    public int val;
    public Node prev;
    public Node next;
    public Node child;

    public Node(int v)
    {
        val = v;
    }
}
