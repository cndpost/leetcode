using System;
using System.Collections.Generic;

// trick: pre-order and in-order along cannot determine the full tree and it can be 
// ambiguous, so need both list to reconstruct a full tree
// but if one traversal included the full 'null' node info, then it is enough to use 
// one list alone to reconstruct the full tree.
//
// inorder list gives a map of value to order, which used to determine mid point
// where mid-1 is the end of left child, and mid+1 is start of right child

class Program
{
    static void Main(string[] args)
    {
        /*
            Tree:
                    3
                  /   \
                 9     20
                      /  \
                     15   7

            Preorder = [3, 9, 20, 15, 7]
            Inorder  = [9, 3, 15, 20, 7]
        */

        int[] preorder = { 3, 9, 20, 15, 7 };
        int[] inorder = { 9, 3, 15, 20, 7 };

        TreeNode root = BuildTree(preorder, inorder);

        Console.WriteLine("Reconstructed Tree (Preorder):");
        PrintPreorder(root);
        Console.WriteLine();
    }

    public static TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        Dictionary<int, int> indexMap = new Dictionary<int, int>();
        for (int i = 0; i < inorder.Length; i++)
            indexMap[inorder[i]] = i;

        int preIndex = 0;
        return Build(preorder, inorder, 0, inorder.Length - 1, indexMap, ref preIndex);
    }

    private static TreeNode Build(int[] preorder, int[] inorder, int inStart, int inEnd,
                                  Dictionary<int, int> indexMap, ref int preIndex)
    {
        if (inStart > inEnd)
            return null;

        int rootVal = preorder[preIndex++];
        TreeNode root = new TreeNode(rootVal);

        int mid = indexMap[rootVal];

        root.left = Build(preorder, inorder, inStart, mid - 1, indexMap, ref preIndex);
        root.right = Build(preorder, inorder, mid + 1, inEnd, indexMap, ref preIndex);

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
