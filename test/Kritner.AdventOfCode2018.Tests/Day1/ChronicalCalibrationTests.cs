using Kritner.AdventOfCode2018.Common;
using Kritner.AdventOfCode2018.Day1;
using System.Collections.Generic;
using Xunit;

namespace Kritner.AdventOfCode2018.Tests.Day1
{
    public class ChronicalCalibrationTests
    {
        private readonly ChronalCalibration _subject = 
            new ChronalCalibration();

        [Fact]
        public void ShouldCalibrateCorrectly()
        {
            List<int> numbers = new List<int>()
            {
                1,
                2, // 3
                3, // 6
                4, // 10
                5, // 15
                -50 // -35
            };

            var result = _subject.CalibrateChronalsOrSomething(numbers);

            Assert.Equal(-35, result);
        }

        [Fact]
        public void ShouldParseStringsIntoNumbersCorrectly()
        {
            List<string> stringsToParse = new List<string>();
            stringsToParse.Add("+500"); // 500
            stringsToParse.Add("-250"); // 250
            stringsToParse.Add("1000"); // 1250

            var resultingInts = _subject.ParseInts(stringsToParse);
            var result = _subject.CalibrateChronalsOrSomething(resultingInts);

            Assert.Equal(1250, result);
        }

        [Fact]
        public void DoTheThing()
        {
            var file = Utilities.GetFileContents("./Day1/calibrationData.txt");
            var ints = _subject.ParseInts(file);
            var result = _subject.CalibrateChronalsOrSomething(ints);

            Assert.Equal(522, result);
        }
    }
}
