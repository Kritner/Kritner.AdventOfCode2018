using System.Collections.Generic;

namespace Kritner.AdventOfCode2018.Day3
{
    public class Point
    {
        public bool IsOccupied => Occupied.Count > 0;
        public bool HasOverlap => Occupied.Count > 1;
        public List<FabricSegments> Occupied { get; set; } = new List<FabricSegments>();
    }
}
