using Kritner.AdventOfCode2018.Common;
using Kritner.AdventOfCode2018.Day7;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Kritner.AdventOfCode2018.Tests.Day7
{
    public class PuzzleTests
    {
        private readonly Puzzle _subject = new Puzzle();

        public static IEnumerable<object[]> SampleData1 =>
            new List<object[]>()
            {
                new object[]
                {
                    new[] {
                        "Step C must be finished before step A can begin.",
                        "Step C must be finished before step F can begin.",
                        "Step A must be finished before step B can begin.",
                        "Step A must be finished before step D can begin.",
                        "Step B must be finished before step E can begin.",
                        "Step D must be finished before step E can begin.",
                        "Step F must be finished before step E can begin."
                    },
                    "CABDFE"
                }
            };

        [Theory]
        [MemberData(nameof(SampleData1))]
        public void ShouldSampleData1(string[] inputs, string expectedOutput)
        {
            var result = _subject.Puzzle1(inputs);

            Assert.Equal(expectedOutput, result);
        }

        [Fact]
        public void DoTheThingPuzzle1()
        {
            var file = Utilities.GetFileContents("./Day7/sampleData.txt");
            var result = _subject.Puzzle1(file);

            Assert.Equal("JRHSBCKUTVWDQAIGYOPXMFNZEL", result);
        }
    }
}
