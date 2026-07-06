using System;
using System.Collections.Generic;

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

class Program
{
    static void Main()
    {
        // Build linked list: 1 -> 2 -> 3 -> 4 -> 5
        ListNode head = new ListNode(1,
                            new ListNode(2,
                                new ListNode(3,
                                    new ListNode(4,
                                        new ListNode(5)))));

        // Create a cycle: last node points back to node with value 3
        head.next.next.next.next.next = head.next.next;

        Console.WriteLine("Linked list (safe print):");
        PrintLinkedListSafe(head);

        bool hasCycle = HasCycle(head);

        Console.WriteLine("\nDoes the linked list have a cycle:");
        Console.WriteLine(hasCycle);
    }

    // Detect cycle using Floyd's algorithm
    public static bool HasCycle(ListNode head)
    {
        ListNode slow = head;
        ListNode fast = head;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;

            if (slow == fast)
                return true;
        }

        return false;
    }

    // Safe print: stops if a cycle is detected
    public static void PrintLinkedListSafe(ListNode head)
    {
        HashSet<ListNode> visited = new HashSet<ListNode>();
        ListNode current = head;

        while (current != null)
        {
            if (visited.Contains(current))
            {
                Console.WriteLine($"(cycle detected → back to node {current.val})");
                return;
            }

            Console.Write(current.val + " -> ");
            visited.Add(current);
            current = current.next;
        }

        Console.WriteLine("null");
    }
}
