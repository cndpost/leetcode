using System;

// trick: check root and then recursively left and right. they must all equal to be equal.
//
class Program
{
    static void Main(string[] args)
    {
        /*
                 1
               /   \
              2     3
        */

        TreeNode t1 = new TreeNode(1);
        t1.left = new TreeNode(2);
        t1.right = new TreeNode(3);

        TreeNode t2 = new TreeNode(1);
        t2.left = new TreeNode(2);
        t2.right = new TreeNode(3);

        bool equal = AreEqual(t1, t2);

        Console.WriteLine("Are the two trees equal? " + equal);
    }

    public static bool AreEqual(TreeNode a, TreeNode b)
    {
        if (a == null && b == null)
            return true;

        if (a == null || b == null)
            return false;

        if (a.val != b.val)
            return false;

        return AreEqual(a.left, b.left) && AreEqual(a.right, b.right);
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
