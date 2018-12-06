using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Kritner.AdventOfCode2018.Day6
{
    public class PointParser
    {
        IEnumerable<Point> GetPointsFromData(IEnumerable<string> inputs)
        {
            List<Point> list = new List<Point>();

            foreach(var input in inputs)
            {
                var coords = input.Split(new[] { "," }, StringSplitOptions.None);

                Debug.Assert(coords.Length == 2);

                list.Add(new Point()
                {
                    X = int.Parse(coords[0]),
                    Y = int.Parse(coords[1])
                });
            }

            return list;
        }
    }
}
