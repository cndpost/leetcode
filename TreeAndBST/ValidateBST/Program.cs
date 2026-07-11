using System;

// trick: use long.MinValue, long.MaxValue as initial boundary, and pass root value to child levels
// as new boundaries. 
// both child need to be true to become true as a whole
// not just check one side, need check both side.
//
class Program
{
    static void Main(string[] args)
    {
        /*
                 5
               /   \
              3     7
             / \   / \
            2   4 6   8
        */

        TreeNode root = new TreeNode(5);
        root.left = new TreeNode(3);
        root.right = new TreeNode(7);

        root.left.left = new TreeNode(2);
        root.left.right = new TreeNode(4);

        root.right.left = new TreeNode(6);
        root.right.right = new TreeNode(8);

        bool valid = IsValidBST(root);

        Console.WriteLine("Is the tree a valid BST? " + valid);
    }

    public static bool IsValidBST(TreeNode root)
    {
        return Validate(root, long.MinValue, long.MaxValue);
    }

    private static bool Validate(TreeNode node, long min, long max)
    {
        if (node == null)
            return true;

        if (node.val <= min || node.val >= max)
            return false;

        return Validate(node.left, min, node.val) &&
               Validate(node.right, node.val, max);
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
