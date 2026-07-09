using System;
// BST traversal: in order is: left, root, right. Use: BST sorted output
// preorder is: root, left, right. Use: Tree serialization
// post order is: left, right, root: Use: Expression evaluation

class Program
{
    static void Main(string[] args)
    {
        // Build sorted linked list: 1 -> 2 -> 3 -> 4 -> 5 -> 6 -> 7
        ListNode head = new ListNode(1);
        head.next = new ListNode(2);
        head.next.next = new ListNode(3);
        head.next.next.next = new ListNode(4);
        head.next.next.next.next = new ListNode(5);
        head.next.next.next.next.next = new ListNode(6);
        head.next.next.next.next.next.next = new ListNode(7);

        Console.WriteLine("Original Linked List:");
        PrintList(head);

        TreeNode bst = SortedListToBST(head);

        Console.WriteLine("BST In-Order Traversal:");
        PrintTreeInOrder(bst);
    }

    public static TreeNode SortedListToBST(ListNode head)
    {
        int length = GetLength(head);
        current = head;
        return BuildBST(0, length - 1);
    }

    private static ListNode current;

    private static int GetLength(ListNode head)
    {
        int count = 0;
        while (head != null)
        {
            count++;
            head = head.next;
        }
        return count;
    }

    private static TreeNode BuildBST(int left, int right)
    {
        if (left > right)
            return null;

        int mid = left + (right - left) / 2;

        TreeNode leftChild = BuildBST(left, mid - 1);

        TreeNode root = new TreeNode(current.val);
        current = current.next;

        TreeNode rightChild = BuildBST(mid + 1, right);

        root.left = leftChild;
        root.right = rightChild;

        return root;
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

    public static void PrintTreeInOrder(TreeNode root)
    {
        if (root == null) return;
        PrintTreeInOrder(root.left);
        Console.Write(root.val + " ");
        PrintTreeInOrder(root.right);
    }
}

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int v) { val = v; }
}

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int v) { val = v; }
}
