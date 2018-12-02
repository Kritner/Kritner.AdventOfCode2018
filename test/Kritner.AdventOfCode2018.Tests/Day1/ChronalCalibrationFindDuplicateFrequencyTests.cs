using Kritner.AdventOfCode2018.Common;
using Kritner.AdventOfCode2018.Day1;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Kritner.AdventOfCode2018.Tests.Day1
{
    public class ChronalCalibrationFindDuplicateFrequencyTests
    {
        private readonly ChronalCalibrationFindDuplicateFrequency _subject = 
            new ChronalCalibrationFindDuplicateFrequency();

        [Fact]
        public void ShouldReturnFirstDuplicateFrequencySinglePass()
        {
            List<int> numbers = new List<int>()
            {
                1,
                2, // 3
                3, // 6
                4, // 10
                5, // 15
                -5, // 10 - first duplicate
                10 // 20
            };

            var result = _subject.CalibrateChronalsOrSomething(numbers);

            Assert.Equal(10, result);
        }

        public static IEnumerable<object[]> TestData =>
            new List<object[]>()
            {
                new object[]
                {
                    new[] { +1, -1 },
                    0
                },
                new object[]
                {
                    new[] { +3, +3, +4, -2, -4 },
                    10
                },
                new object[]
                {
                    new[] { -6, +3, +8, +5, -6 },
                    5
                },
                new object[]
                {
                    new[] { +7, +7, -2, -7, -4 },
                    14
                }
            };

        [Theory]
        [MemberData(nameof(TestData))]
        public void ShouldReachProperDuplicateFrequencies(int[] values, int expectedDuplicateFrequency)
        {
            var result = _subject.CalibrateChronalsOrSomething(values);

            Assert.Equal(expectedDuplicateFrequency, result);
        }

        [Fact]
        public void DoTheThing()
        {
            var file = Utilities.GetFileContents("./Day1/calibrationData.txt");
            var ints = _subject.ParseInts(file);
            var result = _subject.CalibrateChronalsOrSomething(ints);

            Assert.Equal(73364, result);
        }
    }
}
