using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kritner.AdventOfCode2018.Day6
{
    public class Puzzle
    {
        private readonly PointParser _parser = new PointParser();

        public async Task<int> Puzzle1(IEnumerable<string> inputs)
        {
            var grid = GetGridFromPointData(inputs);

            var areaPerPrimaryPoint = new Dictionary<Point, int>();
            
            List<Task<Point>> tasks = new List<Task<Point>>();
            grid.Points.ForEach(fe => tasks.Add(fe.GetPrimaryManhattanPoint(grid)));

            List<Point> primaryManhattanPoints = new List<Point>();
            primaryManhattanPoints.AddRange(await Task.WhenAll(tasks));

            foreach (var primaryManhattanPoint in primaryManhattanPoints)
            {
                // No primary point, doesn't count toward anything
                if (primaryManhattanPoint == null)
                {
                    continue;
                }
                
                if (areaPerPrimaryPoint.ContainsKey(primaryManhattanPoint))
                {
                    areaPerPrimaryPoint[primaryManhattanPoint]++;
                }
                else
                {
                    areaPerPrimaryPoint.Add(primaryManhattanPoint, 1);
                }
            }

            return areaPerPrimaryPoint
                .Where(w => !w.Key.IsInfinityPoint(grid))
                .Select(s => s.Value)
                .Max();
        }

        protected Grid GetGridFromPointData(IEnumerable<string> inputs)
        {
            return new Grid(_parser.GetPointsFromData(inputs));
        }
    }
}
