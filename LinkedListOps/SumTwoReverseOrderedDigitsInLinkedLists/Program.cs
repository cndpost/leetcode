using System;

class Program
{
    static void Main(string[] args)
    {
        // Number A = 342 → 2 → 4 → 3
        ListNode a = new ListNode(2);
        a.next = new ListNode(4);
        a.next.next = new ListNode(3);

        // Number B = 465 → 5 → 6 → 4
        ListNode b = new ListNode(5);
        b.next = new ListNode(6);
        b.next.next = new ListNode(4);

        Console.WriteLine("Number A (reverse list):");
        PrintList(a);

        Console.WriteLine("Number B (reverse list):");
        PrintList(b);

        ListNode sum = AddTwoNumbers(a, b);

        Console.WriteLine("Sum (reverse list):");
        PrintList(sum);
    }

    public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode dummy = new ListNode(0);
        ListNode tail = dummy;

        int carry = 0;

        while (l1 != null || l2 != null || carry > 0)
        {
            int s = carry;

            if (l1 != null)
            {
                s += l1.val;
                l1 = l1.next;
            }

            if (l2 != null)
            {
                s += l2.val;
                l2 = l2.next;
            }

            carry = s / 10;

            tail.next = new ListNode(s % 10);
            tail = tail.next;
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
