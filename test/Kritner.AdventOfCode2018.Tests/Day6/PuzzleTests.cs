using Kritner.AdventOfCode2018.Day6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kritner.AdventOfCode2018.Common;
using Xunit;

namespace Kritner.AdventOfCode2018.Tests.Day6
{
    public class PuzzleTests
    {
        private readonly Puzzle _subject = new Puzzle();

        public static IEnumerable<object[]> SampleData1 => SampleDataHelper.SampleData1;
        public static IEnumerable<object[]> SampleData2 => SampleDataHelper.SampleData2;

        [Theory]
        [MemberData(nameof(SampleData1))]
        public async Task ShouldSampleDataPuzzle1(string[] inputs, int expectedArea)
        {
            var result = await _subject.Puzzle1(inputs);

            Assert.Equal(expectedArea, result);
        }

        [Fact]
        public async Task DoTheThingPuzzle1()
        {
            var file = Utilities.GetFileContents("./Day6/sampleData.txt");
            var result = await _subject.Puzzle1(file);

            Assert.Equal(6047, result);
        }

        [Theory]
        [MemberData(nameof(SampleData2))]
        public async Task ShouldSampleDataPuzzle2(string[] inputs, int maxDistance, int expectedArea)
        {
            var result = await _subject.Puzzle2(inputs, maxDistance);

            Assert.Equal(expectedArea, result);
        }

        [Fact]
        public async Task DoTheThingPuzzle2()
        {
            var file = Utilities.GetFileContents("./Day6/sampleData.txt");
            var result = await _subject.Puzzle2(file, 10000);

            Assert.Equal(46320, result);
        }
    }
}
