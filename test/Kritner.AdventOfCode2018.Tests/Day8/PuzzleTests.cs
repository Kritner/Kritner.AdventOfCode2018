using Kritner.AdventOfCode2018.Common;
using Kritner.AdventOfCode2018.Day8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Kritner.AdventOfCode2018.Tests.Day8
{
    public class PuzzleTests
    {
        private readonly Puzzle _subject = new Puzzle();

        public static IEnumerable<object[]> SampleData1 =>
            new List<object[]>()
            {
                new object[]
                {
                    "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2",
                    138
                }
            };

        public static IEnumerable<object[]> SampleData2 =>
            new List<object[]>()
            {
                new object[]
                {
                    "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2",
                    66
                }
            };

        [Theory]
        [MemberData(nameof(SampleData1))]
        public void ShouldSample1(string input, int sum)
        {
            var result = _subject.Puzzle1(input);

            Assert.Equal(sum, result);
        }

        [Fact]
        public void DoTheThingPuzzle1()
        {
            var file = Utilities.GetFileContents("./Day8/sampleData.txt");
            var result = _subject.Puzzle1(file.First());

            Assert.Equal(45865, result);
        }

        [Theory]
        [MemberData(nameof(SampleData2))]
        public void ShouldSample2(string input, int sum)
        {
            var result = _subject.Puzzle2(input);

            Assert.Equal(sum, result);
        }

        [Fact]
        public void DoTheThingPuzzle2()
        {
            var file = Utilities.GetFileContents("./Day8/sampleData.txt");
            var result = _subject.Puzzle2(file.First());

            Assert.Equal(22608, result);
        }
    }
}
