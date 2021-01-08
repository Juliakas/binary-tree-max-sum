using System;
using System.Collections.Generic;
using System.Linq;

namespace BTreeMaxSum.Entities
{
    public class Node
    {
        public int Value { get; private set; }
        public Node Left { get; private set; }
        public Node Right { get; private set; }

        public Node(int value)
        {
            Value = value;
            Left = Right = null;
        }

        public void AddChild(Node child)
        {
            if (Left == null)
            {
                Left = child;
            }
            else if (Right == null)
            {
                Right = child;
            }
        }

        public (IEnumerable<Node>, int?) FindMaximumSum(int depth)
        {
            if (Left == null && Right == null)
            {
                if (depth == 0)
                {
                    return (new LinkedList<Node>(new[] { this }), Value);
                }
                else
                {
                    return (null, null);
                }
            }

            (IEnumerable<Node>, int?) leftResult = (null, null);
            (IEnumerable<Node>, int?) rightResult = (null, null);
            if (Left != null)
            {
                leftResult = Left.FindMaximumSum(depth - 1);
            }
            if (Right != null)
            {
                rightResult = Right.FindMaximumSum(depth - 1);
            }
            if (rightResult.Item1 == null && leftResult.Item1 == null)
            {
                return (null, null);
            }
            var results = new[] { leftResult, rightResult };
            var maxSum = results.Max(res => res.Item2).Value;
            var (resPath, resSum) = results.Single(res => res.Item2 == maxSum);
            var path = new LinkedList<Node>(new[] { this }).Concat(resPath);
            var sum = Value + resSum.Value;

            return (path, sum);
        }
    }
}