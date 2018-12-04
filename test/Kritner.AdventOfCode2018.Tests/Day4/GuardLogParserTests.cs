using Kritner.AdventOfCode2018.Day4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Kritner.AdventOfCode2018.Tests.Day4
{
    public class GuardLogParserTests
    {
        public static IEnumerable<object[]> SampleData => SampleDataHelper.Puzzle1;

        private class TestableGuardLogParser : GuardLogParser
        {
            public IDictionary<DateTime, string> Test_GetDateAndLogPortionsOrdered(
                IEnumerable<string> log
            )
            {
                return GetDateAndLogPortionsOrdered(log);
            }

            public IEnumerable<GuardMonitoring> Test_GetLogPerGuard(
                IDictionary<DateTime, string> orderedRawLog
            )
            {
                return GetLogPerGuard(orderedRawLog);
            }
        }

        [Fact]
        public void ShouldParseDataIntoCorrectParts()
        {
            DateTime dateTime = new DateTime();
            string log = "some dude did the thing with the thing innit?";

            var testLog = $"[{dateTime:yyyy-dd-MM mm:ss}] {log}";

            var subject = new TestableGuardLogParser();
            var result = subject.Test_GetDateAndLogPortionsOrdered(new[] {testLog});

            Assert.True(result.Count == 1);
            Assert.True(dateTime == result.First().Key);
            Assert.True(log == result.First().Value);
        }

        [Theory]
        [MemberData(nameof(SampleData))]
        public void ShouldSortSampleData(string[] log)
        {
            var subject = new TestableGuardLogParser();
            var result = subject.Test_GetDateAndLogPortionsOrdered(log);
            var min = result.Min(m => m.Key);
            var max = result.Max(m => m.Key);
            
            Assert.True(log.Length == result.Count, nameof(log.Length));
            Assert.True(min == result.First().Key, "first");
            Assert.True(max == result.Last().Key, "last");
        }

        [Theory]
        [MemberData(nameof(SampleData))]
        public void ShouldCreateGuardForEachUniqueGuardId(string[] log)
        {
            var subject = new TestableGuardLogParser();
            var orderedData = subject.Test_GetDateAndLogPortionsOrdered(log);
            var result = subject.Test_GetLogPerGuard(orderedData);

            // Two unique guards in the sample data
            Assert.Equal(2, result.Count());
        }
    }
}
