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

        Console.WriteLine("\n--- Cycle detection trace ---");
        ListNode entry = TraceDetectCycle(head);

        Console.WriteLine("\nFinal cycle entry node:");
        Console.WriteLine(entry != null ? entry.val : 0);
    }

    // Tracing version: prints slow, fast, meeting point, and cycle entry step by step
    public static ListNode TraceDetectCycle(ListNode head)
    {
        ListNode slow = head;
        ListNode fast = head;
        int step = 0;

        Console.WriteLine("\nPhase 1: Detect cycle (slow, fast)");

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
            step++;

            Console.WriteLine($"Step {step}: slow = {slow.val}, fast = {fast.val}");

            if (slow == fast)
            {
                Console.WriteLine($"\nMeeting point detected at node with value {slow.val}");
                break;
            }
        }

        if (fast == null || fast.next == null)
        {
            Console.WriteLine("\nNo cycle detected.");
            return null;
        }

        Console.WriteLine("\nPhase 2: Find cycle entry (ptr from head, slow from meeting point)");

        ListNode ptr = head;
        step = 0;
        while (ptr != slow)
        {
            ptr = ptr.next;
            slow = slow.next;
            step++;
            Console.WriteLine($"Step {step}: ptr = {ptr.val}, slow = {slow.val}");
        }

        Console.WriteLine($"\nCycle entry found at node with value {ptr.val}");
        return ptr;
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
