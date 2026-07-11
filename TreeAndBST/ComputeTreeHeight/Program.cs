Console.WriteLine("Hello, World!");
using System;


// trick: need to do a Math.Max of left height and right height. Also remember to add 1 for own height.
//
class Program
{
    static void Main(string[] args)
    {
        /*
                 1
               /   \
              2     3
             / \   / \
            4   5 6   7
        */

        TreeNode root = new TreeNode(1);
        root.left = new TreeNode(2);
        root.right = new TreeNode(3);

        root.left.left = new TreeNode(4);
        root.left.right = new TreeNode(5);

        root.right.left = new TreeNode(6);
        root.right.right = new TreeNode(7);

        Console.WriteLine("Original Tree (Preorder):");
        PrintPreorder(root);
        Console.WriteLine();

        FlipTree(root);

        Console.WriteLine("\nFlipped Tree (Preorder):");
        PrintPreorder(root);
        Console.WriteLine();
    }

    public static TreeNode FlipTree(TreeNode root)
    {
        if (root == null)
            return null;

        TreeNode temp = root.left;
        root.left = root.right;
        root.right = temp;

        FlipTree(root.left);
        FlipTree(root.right);

        return root;
    }

    public static void PrintPreorder(TreeNode node)
    {
        if (node == null)
        {
            Console.Write("null ");
            return;
        }

        Console.Write(node.val + " ");
        PrintPreorder(node.left);
        PrintPreorder(node.right);
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
