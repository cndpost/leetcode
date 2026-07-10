using System;

// trick: recursion on the left or right. Then root is the answer.

class Program
{
    static void Main(string[] args)
    {
        /*
                 6
               /   \
              2     8
             / \   / \
            0   4 7   9
               / \
              3   5
        */

        TreeNode root = new TreeNode(6);
        root.left = new TreeNode(2);
        root.right = new TreeNode(8);

        root.left.left = new TreeNode(0);
        root.left.right = new TreeNode(4);

        root.left.right.left = new TreeNode(3);
        root.left.right.right = new TreeNode(5);

        root.right.left = new TreeNode(7);
        root.right.right = new TreeNode(9);

        TreeNode p = root.left;        // 2
        TreeNode q = root.left.right;  // 4

        TreeNode lca = LowestCommonAncestor(root, p, q);

        Console.WriteLine($"LCA of {p.val} and {q.val} = {lca.val}");
    }

    public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        while (root != null)
        {
            if (p.val < root.val && q.val < root.val)
            {
                root = root.left;
            }
            else if (p.val > root.val && q.val > root.val)
            {
                root = root.right;
            }
            else
            {
                return root;
            }
        }

        return null;
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
