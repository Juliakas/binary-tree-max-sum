using System.Collections.Generic;
using System.IO;
using System.Linq;
using BTreeMaxSum.Entities;

namespace BTreeMaxSum.Util
{
    public class InputParser
    {
        public TextReader Reader { get; private set; }
        public InputParser(TextReader reader)
        {
            Reader = reader;
        }

        public (BTree, int) ReadBinaryTree()
        {
            BTree tree = null;
            var nodeMatrix = new List<List<Node>>();
            var lineNumber = -1; // 0 indexed

            string line;
            while ((line = Reader.ReadLine()) != null)
            {
                lineNumber++;
                var nodes = line.Trim()
                    .Split(separator: " ")
                    .Select(x => new Node(int.Parse(x)))
                    .ToList();
                nodeMatrix.Add(nodes);
                if (lineNumber == 0)
                {
                    tree = new BTree(nodes[0]);
                }
                if (lineNumber > 0)
                {
                    for (int i = 0; i < nodes.Count; i++)
                    {
                        var current = nodes[i];
                        Node potentialParent;
                        if (i > 0)
                        {
                            potentialParent = nodeMatrix[lineNumber - 1][i - 1];
                            if (potentialParent.Value % 2 != current.Value % 2)
                            {
                                potentialParent.AddChild(current);
                            }
                        }
                        if (i != nodes.Count - 1)
                        {
                            potentialParent = nodeMatrix[lineNumber - 1][i];
                            if (potentialParent.Value % 2 != current.Value % 2)
                            {
                                potentialParent.AddChild(current);
                            }
                        }
                    }
                }
            }

            return (tree, lineNumber);
        }

    }
}