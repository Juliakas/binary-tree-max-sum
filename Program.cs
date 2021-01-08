using System;
using System.IO;
using BTreeMaxSum.Entities;
using BTreeMaxSum.Util;

namespace BTreeMaxSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Case1: ");
            var (tree, lines) = new InputParser(
                new StreamReader("./input/case1.txt")
            ).ReadBinaryTree();
            var (path, sum) = tree.FindMaximumSum(lines);

            Console.WriteLine($"Maximum sum: {sum}");
            Console.WriteLine($"Path: {BTree.PathToString(path)}");

            // ==============================================================

            Console.WriteLine();
            Console.WriteLine("Case2: ");
            (tree, lines) = new InputParser(
                new StreamReader("./input/case2.txt")
            ).ReadBinaryTree();
            (path, sum) = tree.FindMaximumSum(lines);

            Console.WriteLine($"Maximum sum: {sum}");
            Console.WriteLine($"Path: {BTree.PathToString(path)}");
        }
    }
}
