using System;


// this one uses a lambda predicate function which can be more generic than the original question of less than K
// this one currently assumes odd/even partition as the lambda function.

class Program
{
    static void Main(string[] args)
    {
        // Build linked list: 1 -> 4 -> 3 -> 2 -> 5
        ListNode head = new ListNode(1);
        head.next = new ListNode(4);
        head.next.next = new ListNode(3);
        head.next.next.next = new ListNode(2);
        head.next.next.next.next = new ListNode(5);

        Console.WriteLine("Original List:");
        PrintList(head);

        // Partition: odd numbers first, even numbers later
        ListNode result = StablePartition(head, x => x % 2 == 1);

        Console.WriteLine("List After Stable Partition (odd first):");
        PrintList(result);
    }

    public static ListNode StablePartition(ListNode head, Func<int, bool> pred)
    {
        ListNode trueDummy = new ListNode(0);
        ListNode falseDummy = new ListNode(0);

        ListNode trueTail = trueDummy;
        ListNode falseTail = falseDummy;

        ListNode curr = head;

        while (curr != null)
        {
            if (pred(curr.val))
            {
                trueTail.next = curr;
                trueTail = trueTail.next;
            }
            else
            {
                falseTail.next = curr;
                falseTail = falseTail.next;
            }

            curr = curr.next;
        }

        trueTail.next = null;
        falseTail.next = null;

        trueTail.next = falseDummy.next;

        return trueDummy.next;
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
