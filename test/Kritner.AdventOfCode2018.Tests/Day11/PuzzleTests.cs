using Kritner.AdventOfCode2018.Day11;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Kritner.AdventOfCode2018.Tests.Day11
{
    public class PuzzleTests
    {
        private readonly Puzzle _subject = new Puzzle();

        private readonly ITestOutputHelper _output;

        public PuzzleTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [InlineData(18, 33, 45)]
        [InlineData(42, 21, 61)]
        public void ShouldSample1(int gridSerialNumber, int expectedX, int expectedY)
        {
            var result = _subject.Puzzle1(gridSerialNumber);

            Assert.Equal(expectedX, result.X);
            Assert.Equal(expectedY, result.Y);
        }

        [Fact]
        public void DoTheThingPuzzle1()
        {
            var result = _subject.Puzzle1(7315);

            // Nothing really to assert here, since we need to interpret ascii art as words.
            Assert.Equal(21, result.X);
            Assert.Equal(72, result.Y);
        }

        //[Theory]
        //[InlineData(18, 16, 90, 269)]
        //[InlineData(42, 12, 232, 251)]
        //public void ShouldSample2(int gridSerialNumber, int expectedSquareLength, int expectedX, int expectedY)
        //{
        //    var result = _subject.Puzzle2(gridSerialNumber);

        //    Assert.Equal(expectedX, result.cell.X);
        //    Assert.Equal(expectedY, result.cell.Y);
        //    Assert.Equal(expectedSquareLength, result.squareLength);
        //}

        [Fact]
        public void DoTheThingPuzzle2()
        {
            var result = _subject.Puzzle2(7315);

            _output.WriteLine($"{result.cell.X},{result.cell.Y},{result.squareLength}");

            // Nothing really to assert here, since we need to interpret ascii art as words.
            Assert.Equal(242, result.cell.X);
            Assert.Equal(13, result.cell.Y);
            Assert.Equal(9, result.squareLength);
        }
    }
}
