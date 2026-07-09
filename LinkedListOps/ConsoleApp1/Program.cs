using System;

//the trick, use two pointers (fast and slow), the fast run K walk first. When fast reached end.
// the slow points to the node to delete.

class Program
{
    static void Main(string[] args)
    {
        // Build linked list: 1 -> 2 -> 3 -> 4 -> 5
        ListNode head = new ListNode(1);
        head.next = new ListNode(2);
        head.next.next = new ListNode(3);
        head.next.next.next = new ListNode(4);
        head.next.next.next.next = new ListNode(5);

        Console.WriteLine("Original List:");
        PrintList(head);

        int k = 2; // delete 2nd node from end (node 4)

        head = DeleteKthFromEnd(head, k);

        Console.WriteLine($"List After Deleting {k}-th Node From End:");
        PrintList(head);
    }

    public static ListNode DeleteKthFromEnd(ListNode head, int k)
    {
        ListNode dummy = new ListNode(0);
        dummy.next = head;

        ListNode fast = dummy;
        ListNode slow = dummy;

        for (int i = 0; i < k + 1; i++)
            fast = fast.next;

        while (fast != null)
        {
            fast = fast.next;
            slow = slow.next;
        }

        slow.next = slow.next.next;

        return dummy.next;
    }

    public static void PrintList(ListNode head)
    {
        ListNode curr = head;
        while (curr != null)
        {
            Console.Write(curr.val + " ");
            curr = curr.next;
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
