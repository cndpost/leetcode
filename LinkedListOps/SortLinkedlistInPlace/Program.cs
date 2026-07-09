using System;

// the trick is to use merge sort. Sort each half first, then merge sort them

class Program
{
    static void Main(string[] args)
    {
        // Build unsorted linked list: 4 -> 2 -> 1 -> 3 -> 5
        ListNode head = new ListNode(4);
        head.next = new ListNode(2);
        head.next.next = new ListNode(1);
        head.next.next.next = new ListNode(3);
        head.next.next.next.next = new ListNode(5);

        Console.WriteLine("Original List:");
        PrintList(head);

        ListNode sorted = SortList(head);

        Console.WriteLine("Sorted List:");
        PrintList(sorted);
    }

    public static ListNode SortList(ListNode head)
    {
        if (head == null || head.next == null)
            return head;

        ListNode mid = GetMiddle(head);
        ListNode right = mid.next;
        mid.next = null;

        ListNode leftSorted = SortList(head);
        ListNode rightSorted = SortList(right);

        return Merge(leftSorted, rightSorted);
    }

    private static ListNode GetMiddle(ListNode head)
    {
        ListNode slow = head;
        ListNode fast = head.next;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        return slow;
    }

    private static ListNode Merge(ListNode a, ListNode b)
    {
        ListNode dummy = new ListNode(0);
        ListNode tail = dummy;

        while (a != null && b != null)
        {
            if (a.val < b.val)
            {
                tail.next = a;
                a = a.next;
            }
            else
            {
                tail.next = b;
                b = b.next;
            }
            tail = tail.next;
        }

        tail.next = (a != null) ? a : b;

        return dummy.next;
    }

    public static void PrintList(ListNode head)
    {
        while (head != null)
        {
            Console.Write(head.val + " ");
            head = head.next;
        }
        Console.WriteLine();
    }
}

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int v)
    {
        val = v;
        next = null;
    }
}
