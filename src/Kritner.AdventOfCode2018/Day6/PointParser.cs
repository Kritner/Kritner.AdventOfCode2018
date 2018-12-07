using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Kritner.AdventOfCode2018.Day6
{
    public class PointParser
    {
        public HashSet<Point> GetPointsFromData(IEnumerable<string> inputs)
        {
            HashSet<Point> list = new HashSet<Point>();

            foreach(var input in inputs)
            {
                var coords = input.Split(new[] { "," }, StringSplitOptions.None);

                Debug.Assert(coords.Length == 2);

                list.Add(
                    new Point(
                        int.Parse(coords[0]), 
                        int.Parse(coords[1]), 
                        true
                    )
                );
            }

            return list;
        }
    }
}
