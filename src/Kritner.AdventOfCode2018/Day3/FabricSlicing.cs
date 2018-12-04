using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Kritner.AdventOfCode2018.Day3
{
    public class FabricSlicing
    {
        public int GetOverlap(int width, int height, IEnumerable<string> fabricClaims)
        {
            var fabric = GetFabricLayout(width, height, fabricClaims);
            return fabric.GetOverlapArea();
        }

        public IEnumerable<FabricSegments> GetNoOverlap(int width, int height, IEnumerable<string> fabricClaims)
        {
            var fabric = GetFabricLayout(width, height, fabricClaims);
            return fabric.GetNoOverlap();
        }

        protected Fabric GetFabricLayout(int width, int height, IEnumerable<string> fabricClaims)
        {
            var fabric = new Fabric(width, height, PopulateFabricClaims(fabricClaims));
            
            return fabric;
        }

        protected IEnumerable<FabricSegments> PopulateFabricClaims(IEnumerable<string> fabricClaims)
        {
            List<FabricSegments> fabricSegments = new List<FabricSegments>();

            // #1 @ 1,3: 4x4
            Regex regex = new Regex(@"^#(?<id>\d*)\s@\s(?<x>\d*),(?<y>\d*):\s(?<width>\d*)x(?<height>\d*)$");

            foreach (var claim in fabricClaims)
            {
                var matches = regex.Match(claim);

                fabricSegments.Add(new FabricSegments()
                {
                    ClaimId = int.Parse(matches.Groups["id"].Value),
                    Height = int.Parse(matches.Groups["height"].Value),
                    Width = int.Parse(matches.Groups["width"].Value),
                    StartCoordinateX = int.Parse(matches.Groups["x"].Value),
                    StartCoordinateY = int.Parse(matches.Groups["y"].Value)
                });
            }

            return fabricSegments;
        }
    }
}
