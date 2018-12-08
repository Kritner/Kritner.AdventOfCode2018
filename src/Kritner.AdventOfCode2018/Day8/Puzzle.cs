using System;
using System.Collections.Generic;
using System.Text;

namespace Kritner.AdventOfCode2018.Day8
{
    public class Puzzle
    {
        private readonly NodeParser _parser = new NodeParser();

        public int Puzzle1(string input)
        {
            var nodeStack = _parser.ParseInput(input);

            var node = new Node(nodeStack);

            return node.SumOfMetadata();
        }
    }
}
