using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kritner.AdventOfCode2018.Day10
{
    public class StarCharter
    {
        public string PlotStarsUntilClosestManhattanDistance(
            List<Star> stars
        )
        {
            while (true)
            {
                var beforeTickDistance = GetStarsManhattanDistance(stars);
                // the stars will shift closer to one another until a point at which they don't
                stars.ForEach(fe => fe.TickForward());
                var afterTickDistance = GetStarsManhattanDistance(stars);
                
                // at this point, the stars are moving further apart as per the summed manhattan distance
                // break out of loop
                if (beforeTickDistance < afterTickDistance)
                {
                    break;
                }
            }

            // Get back to the time at which they were closest to one another
            stars.ForEach(fe => fe.TickBackward());

            return WriteStars(stars);
        }

        private string WriteStars(List<Star> stars)
        {
            var minX = stars.Min(m => m.CurrentPositionX);
            var maxX = stars.Max(m => m.CurrentPositionX);
            var minY = stars.Min(m => m.CurrentPositionY);
            var maxY = stars.Max(m => m.CurrentPositionY);

            StringBuilder sb = new StringBuilder();
            for (var row = minX; row <= maxX; row++)
            {
                for (var column = minY; column <= maxY; column++)
                {
                    if (stars.Any(a => a.CurrentPositionX == row && a.CurrentPositionY == column))
                    {
                        sb.Append("#");
                    }
                    else
                    {
                        sb.Append(".");
                    }
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        private long GetStarsManhattanDistance(List<Star> stars)
        {
            return stars.Sum(s => s.GetManhattanDistance(stars));
        }
    }
}
