using Kritner.AdventOfCode2018.Day11;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Kritner.AdventOfCode2018.Tests.Day11
{
    public class PuzzleTests
    {
        private readonly Puzzle _subject = new Puzzle();

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
    }
}
