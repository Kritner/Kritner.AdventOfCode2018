using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kritner.AdventOfCode2018.Day6
{
    public class Point
    {
        public Guid Id = Guid.NewGuid();
        public int X { get; }
        public int Y { get; }
        public bool IsPrimaryPoint { get; }

        public Point(int x, int y, bool isPrimaryPoint = false)
        {
            X = x;
            Y = y;
            IsPrimaryPoint = isPrimaryPoint;
        }

        public async Task<Point> GetFurthestManhattanPrimaryPoint(Grid grid)
        {
            if (IsPrimaryPoint)
            {
                return this;
            }

            var manhattanDistances = new Dictionary<Point, int>();
            foreach (var point in grid.PrimaryPoints)
            {
                manhattanDistances.Add(point, await GetManhattanDistance(point));
            }

            var minManhattanDistance = manhattanDistances.Values.Min(m => m);

            if (manhattanDistances.Values.Count(c => c == minManhattanDistance) == 1)
            {
                return manhattanDistances.First(w => w.Value == minManhattanDistance).Key;
            }

            // Minimum manhattan distance is not unique, don't count this point toward any totals.
            return null;
        }

        public async Task<int> GetManhattanDistanceToAllPrimaryPoints(Grid grid)
        {
            var tasks = new List<Task<int>>();
            foreach (var point in grid.PrimaryPoints)
            {
                tasks.Add(GetManhattanDistance(point));
            }

            var results = await Task.WhenAll(tasks);

            return results.Sum();
        }
        
        public bool IsInfinityPoint(Grid grid)
        {
            return !(X > grid.MinX && X < grid.MaxX && Y > grid.MinY && Y < grid.MaxY);
        }

        private Task<int> GetManhattanDistance(Point otherPoint)
        {
            return Task.FromResult(Math.Abs(X - otherPoint.X) + Math.Abs(Y - otherPoint.Y));
        }
    }
}
