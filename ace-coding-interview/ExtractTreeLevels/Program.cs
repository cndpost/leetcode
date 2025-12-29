namespace acecodeinterview
{
    public class Tree
    {
        public int NodeValue { get; set; }
        public Tree? Left{ get; set; }
        public Tree? Right { get; set; }
        public static List<int> ExtractTreeLevels(Tree root)
        {

            List<int> retList = new List<int>();
            if (root == null) return retList;

            if (root.Left != null)
            {
                retList = ExtractTreeLevels(root.Left);
            }

            retList.AddRange(new List<int> { root.NodeValue });


            if (root.Right != null)
            {
                retList.AddRange(ExtractTreeLevels(root.Right));
            }


            // now we have low = hi 
            return retList;
        }
    }

    public class Program
    {
        public static void Main()
        {
            Tree left = new Tree();
            left.NodeValue = 1;
            left.Left = null;
            left.Right = null;

            Tree right = new Tree();
            right.NodeValue = 2;
            right.Left = null;
            right.Right = null;

            Tree root = new Tree();
            root.NodeValue = 0;
            root.Left = left;
            root.Right = right;

            Console.WriteLine("Output suppose to be 1,0,2 ");
            Console.WriteLine("Actual Output is {0} ", string.Join(" ",Tree.ExtractTreeLevels(root)));
             Console.WriteLine("Done");
        }
    }
 }

