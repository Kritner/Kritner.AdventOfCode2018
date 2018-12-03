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

        private class PopulateFabricClaims_FabricSlicing : FabricSlicing
        {
            public IEnumerable<FabricSegments> GetFabricClaims(
                IEnumerable<string> fabricClaims)
            {
                return PopulateFabricClaims(fabricClaims);
            }
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
    }
}
