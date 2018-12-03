using Kritner.AdventOfCode2018.Common;
using Kritner.AdventOfCode2018.Day3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Kritner.AdventOfCode2018.Tests.Day3
{
    public class FabricSlicingTests
    {
        private readonly FabricSlicing _subject = new FabricSlicing();

        private class PopulateFabricClaims_FabricSlicing : FabricSlicing
        {
            public IEnumerable<FabricSegments> GetFabricClaims(
                IEnumerable<string> fabricClaims)
            {
                return PopulateFabricClaims(fabricClaims);
            }
        }

        public static IEnumerable<object[]> SampleData =>
            new List<object[]>()
            {
                new object[]
                {
                    new[]
                    {
                        "#1 @ 1,3: 4x4",
                        "#2 @ 3,1: 4x4",
                        "#3 @ 5,5: 2x2"
                    },
                    8,
                    8,
                    4
                }
            };

        [Theory]
        [MemberData(nameof(SampleData))]
        public void ShouldValidateSample(string[] fabricClaims, int width, int height, int expectedOverlap)
        {
            var result = _subject.GetOverlap(width, height, fabricClaims);

            Assert.Equal(expectedOverlap, result);
        }

        [Theory]
        [MemberData(nameof(SampleData))]
        public void ShouldValidateSampleNoOverlap(string[] fabricClaims, int width, int height, int expectedOverlap)
        {
            var result = _subject.GetNoOverlap(width, height, fabricClaims).ToList();

            Assert.Equal(3, result[0].ClaimId);
        }

        [Fact]
        public void ShouldParseClaimsProperly()
        {
            var claim = "#1 @ 2,3: 4x5";

            var subject = new PopulateFabricClaims_FabricSlicing();
            var result = subject.GetFabricClaims(new[] { claim }).ToList();

            Assert.True(result.Count == 1, nameof(result.Count));
            Assert.True(result[0].ClaimId == 1, nameof(FabricSegments.ClaimId));
            Assert.True(result[0].StartCoordinateX == 2, nameof(FabricSegments.StartCoordinateX));
            Assert.True(result[0].StartCoordinateY == 3, nameof(FabricSegments.StartCoordinateY));
            Assert.True(result[0].Width == 4, nameof(FabricSegments.Width));
            Assert.True(result[0].Height == 5, nameof(FabricSegments.Height));
        }
        
        [Fact]
        public void DoTheThing()
        {
            var file = Utilities.GetFileContents("./Day3/fabricSlicingData.txt");
            var result = _subject.GetOverlap(1000, 1000, file);

            Assert.Equal(110383, result);
        }

        [Fact]
        public void DoTheThingVersion2()
        {
            var file = Utilities.GetFileContents("./Day3/fabricSlicingData.txt");
            var result = _subject.GetNoOverlap(1000, 1000, file).ToList();

            Assert.Equal(129, result[0].ClaimId);
        }
    }
}
