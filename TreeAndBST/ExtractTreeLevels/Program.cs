using System;
using System.Collections.Generic;


// trick: follow the BFS standards by using queue to enqueue all levels and doing the 
// node operation at dequeue time. and then enqueue the child level, left first, right next

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

        List<int> bfs = LevelOrder(root);

        Console.WriteLine("Level-order traversal:");
        foreach (int v in bfs)
            Console.Write(v + " ");
        Console.WriteLine();
    }

    public static List<int> LevelOrder(TreeNode root)
    {
        List<int> result = new List<int>();
        if (root == null)
            return result;

        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);

        while (q.Count > 0)
        {
            TreeNode node = q.Dequeue();
            result.Add(node.val);

            if (node.left != null)
                q.Enqueue(node.left);

            if (node.right != null)
                q.Enqueue(node.right);
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
