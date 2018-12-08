using System;
using System.Collections.Generic;
using System.Text;

namespace Kritner.AdventOfCode2018.Day8
{
    public class NodeParser
    {
        public Stack<int> ParseInput(string input)
        {
            var inputStrings = input.Split(' ');
            Array.Reverse(inputStrings);

            var parsedInts = new Stack<int>();
            for (var i = 0; i < inputStrings.Length; i++)
            {
                parsedInts.Push(int.Parse(inputStrings[i]));
            }

            return parsedInts;
        }
    }
}
