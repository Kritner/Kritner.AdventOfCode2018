using Kritner.AdventOfCode2018.Day11;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Kritner.AdventOfCode2018.Tests.Day11
{
    public class CellTests
    {
        private Cell _subject;

        [Theory]
        [InlineData(122, 79, 57, -5)]
        [InlineData(217, 196, 39, 0)]
        [InlineData(101, 153, 71, 4)]
        public void ShouldCalculateProperPowerLevel(int x, int y, int gridSerialNumber, int expected)
        {
            _subject = new Cell(x, y, gridSerialNumber);
            var result = _subject.GetPowerLevel();

            Assert.Equal(expected, result);
        }
    }
}
