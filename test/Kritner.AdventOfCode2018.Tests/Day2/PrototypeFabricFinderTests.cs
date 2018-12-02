using Kritner.AdventOfCode2018.Common;
using Kritner.AdventOfCode2018.Day2;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Kritner.AdventOfCode2018.Tests.Day2
{
    public class PrototypeFabricFinderTests
    {
        private readonly PrototypeFabricFinder _subject =
            new PrototypeFabricFinder();

        public static IEnumerable<object[]> SampleData =>
            new List<object[]>()
            {
                new object[]
                {
                    new[] {
                        "abcde",
                        "fghij",
                        "klmno",
                        "pqrst",
                        "fguij",
                        "axcye",
                        "wvxyz"
                    },
                    // The IDs abcde and axcye are close, 
                    // but they differ by two characters 
                    // (the second and fourth). However, 
                    // the IDs fghij and fguij differ by exactly 
                    // one character, the third (h and u). 
                    // Those must be the correct boxes.
                    "fgij"
                }
            };

        [Theory]
        [MemberData(nameof(SampleData))]
        public void ShouldPassSampleTest(string[] inventory, string expected)
        {
            var result = _subject.GetProtoTypeFabric(inventory);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void DoTheThing()
        {
            var file = Utilities.GetFileContents("./Day2/inventoryManagementData.txt");
            var result = _subject.GetProtoTypeFabric(file);

            Assert.Equal("asgwjcmzredihqoutcylvzinx", result);
        }
    }
}
