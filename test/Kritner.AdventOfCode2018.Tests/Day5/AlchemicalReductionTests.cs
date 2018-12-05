using Kritner.AdventOfCode2018.Common;
using Kritner.AdventOfCode2018.Day5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Kritner.AdventOfCode2018.Tests.Day5
{
    public class AlchemicalReductionTests
    {
        private readonly AlchemicalReduction _subject = new AlchemicalReduction();

        public static IEnumerable<object[]> SampleData =>
            new List<object[]>()
            {
                new object[]
                {
                    "dabAcCaCBAcCcaDA",
                    10,
                }
            };

        public static IEnumerable<object[]> SampleData2 =>
            new List<object[]>()
            {
                new object[]
                {
                    "dabAcCaCBAcCcaDA",
                    4,
                }
            };

        [Theory]
        [MemberData(nameof(SampleData))]
        public void ShouldPassSamplePuzzle1(string polymer, int expectedLength)
        {
            var result = _subject.ReducePolymer(polymer);

            Assert.Equal(expectedLength, result.Length);
        }

        [Theory]
        [MemberData(nameof(SampleData2))]
        public void ShouldPassSamplePuzzle2(string polymer, int expectedLength)
        {
            var result = _subject.FullyReducePolymerByEliminatingSingleUnit(polymer);

            Assert.Equal(expectedLength, result.Length);
        }

        [Fact]
        public void DoTheThingPuzzle1()
        {
            var file = Utilities.GetFileContents("./Day5/sampleData.txt");
            var result = _subject.ReducePolymer(file.First());

            Assert.Equal(10638, result.Length);
        }

        [Fact]
        public void DoTheThingPuzzle2()
        {
            var file = Utilities.GetFileContents("./Day5/sampleData.txt");
            var result = _subject.FullyReducePolymerByEliminatingSingleUnit(file.First());

            Assert.Equal(4944, result.Length);
        }
    }
}
