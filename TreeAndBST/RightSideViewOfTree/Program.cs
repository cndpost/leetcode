using System;
using System.Collections.Generic;

// trick: do enque first before add last node to list. Because you need to finish the 
// level loop before reaching the last node
//

class Program
{
    static void Main(string[] args)
    {
        /*
                 1
               /   \
              2     3
               \     \
                5     4
        */

        TreeNode root = new TreeNode(1);
        root.left = new TreeNode(2);
        root.right = new TreeNode(3);

        root.left.right = new TreeNode(5);
        root.right.right = new TreeNode(4);

        List<int> view = RightSideView(root);

        Console.WriteLine("Right-side view:");
        foreach (int v in view)
            Console.Write(v + " ");
        Console.WriteLine();
    }

    public static List<int> RightSideView(TreeNode root)
    {
        List<int> result = new List<int>();
        if (root == null)
            return result;

        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);

        while (q.Count > 0)
        {
            int size = q.Count;
            TreeNode last = null;

            for (int i = 0; i < size; i++)
            {
                TreeNode node = q.Dequeue();
                last = node;

                if (node.left != null)
                    q.Enqueue(node.left);

                if (node.right != null)
                    q.Enqueue(node.right);
            }

            result.Add(last.val);
        }

        return result;
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
