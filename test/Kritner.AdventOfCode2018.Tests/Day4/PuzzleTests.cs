using Kritner.AdventOfCode2018.Common;
using Kritner.AdventOfCode2018.Day4;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Kritner.AdventOfCode2018.Tests.Day4
{
    public class PuzzleTests
    {
        public static IEnumerable<object[]> SampleData => SampleDataHelper.Puzzle1;
        private readonly Puzzle _subject = new Puzzle();

        [Theory]
        [MemberData(nameof(SampleData))]
        public void ShouldSamplePuzzle1(string[] input)
        {
            var result = _subject.GetPuzzle1(input);

            Assert.Equal(240, result);
        }

        [Theory]
        [MemberData(nameof(SampleData))]
        public void ShouldSamplePuzzle2(string[] input)
        {
            var result = _subject.GetPuzzle2(input);

            Assert.Equal(4455, result);
        }

        [Fact]
        public void DoTheThingPuzzle1()
        {
            var file = Utilities.GetFileContents("./Day4/sampleData.txt");
            var result = _subject.GetPuzzle1(file);

            Assert.Equal(35623, result);
        }

        [Fact]
        public void DoTheThingPuzzle2()
        {
            var file = Utilities.GetFileContents("./Day4/sampleData.txt");
            var result = _subject.GetPuzzle2(file);

            Assert.Equal(23037, result);
        }
    }
}
