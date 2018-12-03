using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Kritner.AdventOfCode2018.Day3
{
    public class FabricSlicing
    {
        protected Fabric GetFabricLayout(int width, int height, IEnumerable<string> fabricClaims)
        {
            var fabric = new Fabric()
            {
                Width = width,
                Height = height,
            };

            fabric.FabricClaims = PopulateFabricClaims(fabricClaims);

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

    public class Fabric
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public IEnumerable<FabricSegments> FabricClaims { get; set; }
    }

    public class FabricSegments
    {
        public int ClaimId { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public int StartCoordinateX { get; set; }
        public int StartCoordinateY { get; set; }
    }
}
