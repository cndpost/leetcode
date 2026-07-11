using System;

//
// trick is to do DFS and maintain a global pass-through max and return current node's
// one branch max (including the node value itself).
//

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

        Max path = 4 + 2 + 5 = 11
        */

        TreeNode root = new TreeNode(1);
        root.left = new TreeNode(2);
        root.right = new TreeNode(3);

        root.left.left = new TreeNode(4);
        root.left.right = new TreeNode(5);

        int result = MaxPathSum(root);

        Console.WriteLine("Maximum Path Sum:");
        Console.WriteLine(result);
    }

    public static int MaxPathSum(TreeNode root)
    {
        int maxSum = int.MinValue;
        DFS(root, ref maxSum);
        return maxSum;
    }

    private static int DFS(TreeNode node, ref int maxSum)
    {
        if (node == null)
            return 0;

        int left = Math.Max(0, DFS(node.left, ref maxSum));
        int right = Math.Max(0, DFS(node.right, ref maxSum));

        int throughNode = left + right + node.val;

        if (throughNode > maxSum)
            maxSum = throughNode;

        return Math.Max(left, right) + node.val;
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
