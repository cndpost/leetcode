using System;

//need use 3 position to swap: current, first next, second next 

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

        ListNode swapped = SwapPairs(head);

        Console.WriteLine("List After Swapping Adjacent Pairs:");
        PrintList(swapped);
    }

    public static ListNode SwapPairs(ListNode head)
    {
        ListNode dummy = new ListNode(0);
        dummy.next = head;

        ListNode curr = dummy;

        while (curr.next != null && curr.next.next != null)
        {
            ListNode first = curr.next;
            ListNode second = curr.next.next;

            first.next = second.next;
            second.next = first;
            curr.next = second;

            curr = first;
        }

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
