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
        // Build linked list: 1 -> 2 -> 3 -> 2 -> 1
        ListNode head = new ListNode(1,
                            new ListNode(2,
                                new ListNode(3,
                                    new ListNode(2,
                                        new ListNode(1)))));

        Console.WriteLine("Linked list:");
        PrintLinkedList(head);

        bool result = IsPalindrome(head);

        Console.WriteLine("\nIs palindrome:");
        Console.WriteLine(result);
    }

    public static bool IsPalindrome(ListNode head)
    {
        if (head == null || head.next == null)
            return true;

        ListNode slow = head;
        ListNode fast = head;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        ListNode secondHalf = ReverseList(slow);

        ListNode p1 = head;
        ListNode p2 = secondHalf;

        while (p2 != null)
        {
            if (p1.val != p2.val)
                return false;

            p1 = p1.next;
            p2 = p2.next;
        }

        return true;
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
