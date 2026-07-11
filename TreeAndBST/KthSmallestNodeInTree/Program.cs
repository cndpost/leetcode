using System;
using System.Collections.Generic;

//this one not necessary a BST but a generic tree. So it needs to collect all nodes 
// and then do a sort and pick the K-th. which is value[k-1] after sort.
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

        int result = KthSmallest(root, k);

        Console.WriteLine($"The {k}-th smallest value is: {result}");
    }

    public static int KthSmallest(TreeNode root, int k)
    {
        List<int> values = new List<int>();
        Collect(root, values);

        values.Sort();

        if (k < 1 || k > values.Count)
            throw new ArgumentException("k is out of range");

        return values[k - 1];
    }

    private static void Collect(TreeNode node, List<int> list)
    {
        if (node == null)
            return;

        list.Add(node.val);
        Collect(node.left, list);
        Collect(node.right, list);
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
