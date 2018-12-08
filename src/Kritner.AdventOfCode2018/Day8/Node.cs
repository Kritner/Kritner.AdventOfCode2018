using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kritner.AdventOfCode2018.Day8
{
    public class Node
    {
        public NodeHeader Header { get; private set; } = new NodeHeader();
        public List<Node> Children { get; private set; } = new List<Node>();
        public List<int> Metadata { get; private set; } = new List<int>();

        public Node(Stack<int> input)
        {
            SetupNode(input);
        }

        public int SumOfMetadata()
        {
            var sum = Metadata.Sum();
            foreach(var child in Children)
            {
                sum += child.SumOfMetadata();
            }

            return sum;
        }

        /// <summary>
        /// Parses the pieces of the tree
        /// </summary>
        /// <param name="input"></param>
        private void SetupNode(Stack<int> input)
        {
            // First two on the stack are the number of children, and number of meta datas
            Header.NumberOfChildren = input.Pop();
            Header.NumberOfMetaData = input.Pop();

            SetupChildren(input);
            SetupMetadata(input);
        }

        /// <summary>
        /// Sets up this node's children by creating new nodes with the current stack contents.
        /// </summary>
        /// <param name="input">The stack of inputs</param>
        private void SetupChildren(Stack<int> input)
        {
            for (int i = 0; i < Header.NumberOfChildren; i++)
            {
                Children.Add(new Node(input));
            }
        }

        /// <summary>
        /// Anything remaining on the stack, constrained to the number of metadata for the node,
        /// is metadata
        /// </summary>
        /// <param name="input">The stack of inputs</param>
        private void SetupMetadata(Stack<int> input)
        {
            for (int i = 0; i < Header.NumberOfMetaData; i++)
            {
                Metadata.Add(input.Pop());
            }
        }
    }
}
