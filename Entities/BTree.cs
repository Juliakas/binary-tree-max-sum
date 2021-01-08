using System.Collections.Generic;
using System.Text;

namespace BTreeMaxSum.Entities
{
    public class BTree
    {
        public Node Root {get; private set;}
        public BTree(Node root)
        {
            Root = root;
        }

        public (IEnumerable<Node>, int?) FindMaximumSum(int depth)
        {
            return Root.FindMaximumSum(depth);
        }

        public static string PathToString(IEnumerable<Node> path)
        {
            var sep = " -> ";
            var strBuilder = new StringBuilder();
            foreach(var node in path)
            {
                strBuilder.Append(node.Value);
                strBuilder.Append(sep);
            }
            strBuilder.Length -= sep.Length;
            return strBuilder.ToString();
        }
    }
}