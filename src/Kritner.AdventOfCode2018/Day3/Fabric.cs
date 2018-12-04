using System.Collections.Generic;
using System.Linq;

namespace Kritner.AdventOfCode2018.Day3
{
    public class Fabric
    {
        private readonly Point[,] _points;

        public Fabric(int width, int height, IEnumerable<FabricSegments> fabricClaims)
        {
            Width = width;
            Height = height;
            FabricClaims = fabricClaims;

            _points = new Point[Width,Height];

            // Instantiate all the points (is there a better way to do this?)
            for (var row = 0; row < Width; row++)
            {
                for (var column = 0; column < Height; column++)
                {
                    _points[row, column] = new Point();
                }
            }

            PopulatePoints();
        }

        public int Width { get; }
        public int Height { get; }

        public IEnumerable<FabricSegments> FabricClaims { get; }

        public int GetOverlapArea()
        {
            int count = 0;
            for (var row = 0; row < Width; row++)
            {
                for (var column = 0; column < Height; column++)
                {
                    if (_points[row, column].HasOverlap)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public IEnumerable<FabricSegments> GetNoOverlap()
        {
            var overlap = GetOverlap();
            return FabricClaims.ToList().Except(overlap);
        }

        private void PopulatePoints()
        {
            foreach (var fabricClaim in FabricClaims)
            {
                for (var width = 0; width < fabricClaim.Width; width++)
                {
                    for (var height = 0; height < fabricClaim.Height; height++)
                    {
                        var point = _points[
                            fabricClaim.StartCoordinateX + width,
                            fabricClaim.StartCoordinateY + height
                        ];

                        point.Occupied.Add(fabricClaim);
                    }
                }
            }
        }

        private IEnumerable<FabricSegments> GetOverlap()
        {
            List<FabricSegments> list = new List<FabricSegments>();

            for (var row = 0; row < Width; row++)
            {
                for (var column = 0; column < Height; column++)
                {
                    var point = _points[row, column];
                    if (point.HasOverlap)
                    {
                        list.AddRange(point.Occupied);
                    }
                }
            }

            return list;
        }
    }
}
