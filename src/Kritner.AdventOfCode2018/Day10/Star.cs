using System;
using System.Collections.Generic;
using System.Linq;

namespace Kritner.AdventOfCode2018.Day10
{
    public class Star
    {
        public Guid Id { get; }
        public int StartPositionX { get; }
        public int StartPositionY { get; }
        public int VelocityX { get; }
        public int VelocityY { get; }

        public int CurrentPositionX { get; private set; }
        public int CurrentPositionY { get; private set; }

        public Star(int startPositionX, int startPositionY, int velocityX, int velocityY)
        {
            Id = Guid.NewGuid();

            StartPositionX = startPositionX;
            StartPositionY = startPositionY;
            VelocityX = velocityX;
            VelocityY = velocityY;

            CurrentPositionX = StartPositionX;
            CurrentPositionY = StartPositionY;
        }

        /// <summary>
        /// Progress the stars to their next point based on their velocity.
        /// </summary>
        public void TickForward()
        {
            CurrentPositionX += VelocityX;
            CurrentPositionY += VelocityY;
        }

        /// <summary>
        /// Rewind the stars to their previous point based on their velocity.
        /// </summary>
        public void TickBackward()
        {
            CurrentPositionX -= VelocityX;
            CurrentPositionY -= VelocityY;
        }
        
        /// <summary>
        /// Get the ManhattanDistance for provided stars.
        /// </summary>
        /// <param name="stars">The stars to get Manhattan distance from</param>
        /// <returns></returns>
        public long GetManhattanDistance(IEnumerable<Star> stars)
        {
            long sum = 0;
            foreach (var star in stars)
            {
                sum += GetManhattanDistance(star);
            }

            return sum;
        }

        /// <summary>
        /// Calculate Manhattan Distance for this star compared to the other star.
        /// </summary>
        /// <param name="otherStar">The other star to use in the calculation.</param>
        /// <returns>The Manhattan distance.</returns>
        public int GetManhattanDistance(Star otherStar)
        {
            return Math.Abs(CurrentPositionX - otherStar.CurrentPositionX)
                + Math.Abs(CurrentPositionY - otherStar.CurrentPositionY);
        }
    }
}