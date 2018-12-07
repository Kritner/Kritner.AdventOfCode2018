using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Kritner.AdventOfCode2018.Day6
{
    public class Grid
    {
        public Grid(HashSet<Point> primaryPoints)
        {
            PrimaryPoints = primaryPoints;
            Points = new List<Point>();

            InitializeGrid();
        }

        public int MinX => PrimaryPoints.Where(w => w.IsPrimaryPoint).Min(m => m.X);
        public int MaxX => PrimaryPoints.Where(w => w.IsPrimaryPoint).Max(m => m.X);
        public int MinY => PrimaryPoints.Where(w => w.IsPrimaryPoint).Min(m => m.Y);
        public int MaxY => PrimaryPoints.Where(w => w.IsPrimaryPoint).Max(m => m.Y);
        
        public HashSet<Point> PrimaryPoints;
        public List<Point> Points { get; }

        private void InitializeGrid()
        {
            for (var row = MinX; row <= MaxX; row++)
            {
                for (var column = MinY; column <= MaxY; column++)
                {
                    if (PrimaryPoints.Any(a => a.X == row && a.Y == column))
                    {
                        Points.Add(PrimaryPoints.First(a => a.X == row && a.Y == column));
                    }
                    else
                    {
                        Points.Add(new Point(row, column));
                    }
                }
            }
        }
    }
}
