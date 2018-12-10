using Kritner.AdventOfCode2018.Common;
using Kritner.AdventOfCode2018.Day9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Kritner.AdventOfCode2018.Tests.Day9
{
    public class PuzzleTests
    {
        private readonly Puzzle _subject = new Puzzle();

        public static IEnumerable<object[]> SampleData =>
            new List<object[]>()
            {
                new object[]
                {
                    "9 players; last marble is worth 25 points",
                    32
                },
                new object[]
                {
                    "10 players; last marble is worth 1618 points",
                    8317
                },
                new object[]
                {
                    "13 players; last marble is worth 7999 points",
                    146373
                },
                new object[]
                {
                    "17 players; last marble is worth 1104 points",
                    2764
                },
                new object[]
                {
                    "21 players; last marble is worth 6111 points",
                    54718
                },
                new object[]
                {
                    "30 players; last marble is worth 5807 points",
                    37305
                }
            };

        [Theory]
        [MemberData(nameof(SampleData))]
        public void ShouldSamplePuzzle1(string input, int expectedScore)
        {
            var result = _subject.Puzzle1(input);

            Assert.Equal(expectedScore, result);
        }

        [Fact]
        public void DoTheThingPuzzle1()
        {
            var file = Utilities.GetFileContents("./Day9/sampleData.txt");
            var result = _subject.Puzzle1(file.First());

            Assert.Equal(398242, result);
        }

        [Fact]
        public void DoTheThingPuzzle2()
        {
            var file = Utilities.GetFileContents("./Day9/sampleData.txt");
            var result = _subject.Puzzle2(file.First());

            Assert.Equal(398242, result);
        }
    }
}
