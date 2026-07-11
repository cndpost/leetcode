using System;

// for BST, no collection of all and sort needed. Just do in order traversal: left, root, right
// and count each step to see if K step reached. Need to carry current count and target K when 
// do recursion call or in current node check.
//
//

class Program
{
    static void Main(string[] args)
    {
        /*
                 5
               /   \
              3     8
             / \   / \
            2   4 7   9
        */

        TreeNode root = new TreeNode(5);
        root.left = new TreeNode(3);
        root.right = new TreeNode(8);

        root.left.left = new TreeNode(2);
        root.left.right = new TreeNode(4);

        root.right.left = new TreeNode(7);
        root.right.right = new TreeNode(9);

        int k = 3;

        int result = KthSmallestBST(root, k);

        Console.WriteLine($"The {k}-th smallest value in the BST is: {result}");
    }

    public static int KthSmallestBST(TreeNode root, int k)
    {
        int count = 0;
        return Inorder(root, ref count, k);
    }

    private static int Inorder(TreeNode node, ref int count, int k)
    {
        if (node == null)
            return -1;

        int left = Inorder(node.left, ref count, k);
        if (count == k)
            return left;

        count++;
        if (count == k)
            return node.val;

        return Inorder(node.right, ref count, k);
    }
}

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int v)
    {
        val = v;
    }
}
