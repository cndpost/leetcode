using System;

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
        // Build linked list: 1 -> 2 -> 3 -> 4 -> 5 -> 6
        ListNode head =
            new ListNode(1,
                new ListNode(2,
                    new ListNode(3,
                        new ListNode(4,
                            new ListNode(5,
                                new ListNode(6))))));

        Console.WriteLine("Original list:");
        PrintLinkedList(head);

        ReorderZigZag(head);

        Console.WriteLine("\nZigZag reordered list:");
        PrintLinkedList(head);
    }

    public static void ReorderZigZag(ListNode head)
    {
        if (head == null || head.next == null)
            return;

        // Step 1: find middle
        ListNode slow = head;
        ListNode fast = head;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        // Step 2: reverse second half
        ListNode second = ReverseList(slow);
        ListNode first = head;

        // Step 3: merge in L0, Ln, L1, L(n-1), ...
        while (second.next != null)
        {
            ListNode temp1 = first.next;
            ListNode temp2 = second.next;

            first.next = second;
            second.next = temp1;

            first = temp1;
            second = temp2;
        }
    }

    private static ListNode ReverseList(ListNode head)
    {
        ListNode prev = null;
        ListNode curr = head;

        while (curr != null)
        {
            ListNode next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }

        return prev;
    }

    public static void PrintLinkedList(ListNode head)
    {
        ListNode curr = head;
        while (curr != null)
        {
            Console.Write(curr.val + " -> ");
            curr = curr.next;
        }
        Console.WriteLine("null");
    }
}
