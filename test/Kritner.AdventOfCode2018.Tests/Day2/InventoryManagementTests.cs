using Kritner.AdventOfCode2018.Common;
using Kritner.AdventOfCode2018.Day2;
using System.Collections.Generic;
using Xunit;

namespace Kritner.AdventOfCode2018.Tests.Day2
{
    public class InventoryManagementTests
    {
        private readonly InventoryManagement _subject = 
            new InventoryManagement();

        public static IEnumerable<object[]> SampleData =>
            new List<object[]>()
            {
                new object[]
                {
                    new[]
                    {
                        "abcdef", // contains no letters that appear exactly two or three times.
                        "bababc", // contains two a and three b, so it counts for both.
                        "abbcde", // contains two b, but no letter appears exactly three times.
                        "abcccd", // contains three c, but no letter appears exactly two times.
                        "aabcdd", // contains two a and two d, but it only counts once.
                        "abcdee", // contains two e.
                        "ababab"  // contains three a and three b, but it only counts once.
                    },
                    // Of these box IDs, four of them contain a letter which appears exactly twice, 
                    // and three of them contain a letter which appears exactly three times. 
                    // Multiplying these together produces a checksum of 4 * 3 = 12.
                    12
                }
            };

        [Theory]
        [MemberData(nameof(SampleData))]
        public void ShouldPassSampleTest(string[] id, int expected)
        {
            var checksum = _subject.GetCheckSum(id);

            Assert.Equal(expected, checksum);
        }

        [Fact]
        public void DoTheThing()
        {
            var file = Utilities.GetFileContents("./Day2/inventoryManagementData.txt");
            var result = _subject.GetCheckSum(file);

            Assert.Equal(6175, result);
        }
    }
}
