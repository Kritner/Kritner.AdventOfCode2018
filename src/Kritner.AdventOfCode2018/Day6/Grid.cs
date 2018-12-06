using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kritner.AdventOfCode2018.Day6
{
    public class Grid
    {

        public Grid(IEnumerable<Point> points)
        {
            Points = points;
        }

        public int LargestX => Points.Max(m => m.X);
        public int LargestY => Points.Max(m => m.Y);

        public IEnumerable<Point> Points { get; }
    }
}
