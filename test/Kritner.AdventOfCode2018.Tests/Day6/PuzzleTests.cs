using Kritner.AdventOfCode2018.Day6;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kritner.AdventOfCode2018.Tests.Day6
{
    public class PuzzleTests
    {
        private readonly Puzzle _subject = new Puzzle();

        public IEnumerable<object[]> SampleData =>
            new List<object[]>()
            {
                new object[]
                {
                    new string[] 
                    {
                        "1, 1",
                        "1, 6",
                        "8, 3",
                        "3, 4",
                        "5, 5",
                        "8, 9"
                    },
                    17 // largest non infinite area calculated with Manhattan distance
                }
            };
    }
}
