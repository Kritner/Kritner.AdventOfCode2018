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

        public static IEnumerable<object[]> SampleData => SampleDataHelper.SampleData;

        [Theory]
        [MemberData(nameof(SampleData))]
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
    }
}
