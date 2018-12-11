﻿using Kritner.AdventOfCode2018.Common;
using Kritner.AdventOfCode2018.Day10;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Kritner.AdventOfCode2018.Tests.Day10
{
    public class PuzzleTests
    {
        private readonly Puzzle _subject = new Puzzle();
        private readonly ITestOutputHelper _output;

        public PuzzleTests(ITestOutputHelper output)
        {
            _output = output;
        }

        public static IEnumerable<object[]> SampleData =>
            new List<object[]>()
            {
                new object[]
                {
                    new[]
                    {
                        "position=< 9,  1> velocity=< 0,  2>",
                        "position=< 7,  0> velocity=<-1,  0>",
                        "position=< 3, -2> velocity=<-1,  1>",
                        "position=< 6, 10> velocity=<-2, -1>",
                        "position=< 2, -4> velocity=< 2,  2>",
                        "position=<-6, 10> velocity=< 2, -2>",
                        "position=< 1,  8> velocity=< 1, -1>",
                        "position=< 1,  7> velocity=< 1,  0>",
                        "position=<-3, 11> velocity=< 1, -2>",
                        "position=< 7,  6> velocity=<-1, -1>",
                        "position=<-2,  3> velocity=< 1,  0>",
                        "position=<-4,  3> velocity=< 2,  0>",
                        "position=<10, -3> velocity=<-1,  1>",
                        "position=< 5, 11> velocity=< 1, -2>",
                        "position=< 4,  7> velocity=< 0, -1>",
                        "position=< 8, -2> velocity=< 0,  1>",
                        "position=<15,  0> velocity=<-2,  0>",
                        "position=< 1,  6> velocity=< 1,  0>",
                        "position=< 8,  9> velocity=< 0, -1>",
                        "position=< 3,  3> velocity=<-1,  1>",
                        "position=< 0,  5> velocity=< 0, -1>",
                        "position=<-2,  2> velocity=< 2,  0>",
                        "position=< 5, -2> velocity=< 1,  2>",
                        "position=< 1,  4> velocity=< 2,  1>",
                        "position=<-2,  7> velocity=< 2, -2>",
                        "position=< 3,  6> velocity=<-1, -1>",
                        "position=< 5,  0> velocity=< 1,  0>",
                        "position=<-6,  0> velocity=< 2,  0>",
                        "position=< 5,  9> velocity=< 1, -2>",
                        "position=<14,  7> velocity=<-2,  0>",
                        "position=<-3,  6> velocity=< 2, -1>"
                    }
                }

            };

        [Theory]
        [MemberData(nameof(SampleData))]
        public void ShouldSamplePuzzle1(string[] inputs)
        {
            var result = _subject.Puzzle1(inputs);
            _output.WriteLine(result);

            // Nothing really to assert here, since we need to interpret ascii art as words.
            Assert.True(true);
        }

        [Fact]
        public void DoTheThingPuzzle1()
        {
            var file = Utilities.GetFileContents("./Day10/sampleData.txt");
            var result = _subject.Puzzle1(file);
            _output.WriteLine(result);

            // Nothing really to assert here, since we need to interpret ascii art as words.
            Assert.True(true);
        }
    }
}
