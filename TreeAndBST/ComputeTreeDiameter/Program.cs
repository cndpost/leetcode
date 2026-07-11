using System;

// the trick is to pass out both child height and global diameter.
// left child height + right child height + 2 is my diameter. I then compare
// with global diameter.
// and my height is larger of (left child height , right child heigh) + 1


class Program
{
    static void Main(string[] args)
    {
        /*
                 1
               /   \
              2     3
             / \
            4   5
        */

        TreeNode root = new TreeNode(1);
        root.left = new TreeNode(2);
        root.right = new TreeNode(3);

        root.left.left = new TreeNode(4);
        root.left.right = new TreeNode(5);

        int diameter = TreeDiameter(root);

        Console.WriteLine("Tree Diameter:");
        Console.WriteLine(diameter);
    }

    public static int TreeDiameter(TreeNode root)
    {
        int diameter = 0;
        ComputeHeight(root, ref diameter);
        return diameter;
    }

    private static int ComputeHeight(TreeNode node, ref int diameter)
    {
        if (node == null)
            return -1;

        int left = ComputeHeight(node.left, ref diameter);
        int right = ComputeHeight(node.right, ref diameter);

        int path = left + right + 2;
        if (path > diameter)
            diameter = path;

        return Math.Max(left, right) + 1;
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
