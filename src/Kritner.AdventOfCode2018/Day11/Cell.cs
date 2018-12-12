using System.Collections.Generic;

namespace Kritner.AdventOfCode2018.Day11
{
    public class Cell
    {
        private static Dictionary<(int x, int y, int gridSerialNumber), int> PowerTrackerPerCoord =
            new Dictionary<(int x, int y, int gridSerialNumber), int>();

        public int X { get; }
        public int Y { get; }

        private int _gridSerialNumber;

        public Cell(int x, int y, int gridSerialNumber)
        {
            X = x;
            Y = y;
            _gridSerialNumber = gridSerialNumber;
        }

        public int GetPowerLevel()
        {
            if (PowerTrackerPerCoord.TryGetValue((X, Y, _gridSerialNumber), out var result))
            {
                return result;
            }
            
            var rackId = X + 10;
            var powerLevel = rackId * Y;
            powerLevel += _gridSerialNumber;
            powerLevel *= rackId;

            if (powerLevel > 99)
            {
                string powerString = powerLevel.ToString();
                // hundreds spot
                powerLevel = int.Parse(
                    new string(new[] { powerString[powerString.Length - 3] })
                );
            }
            else
            {
                powerLevel = 0;
            }

            powerLevel -= 5;

            PowerTrackerPerCoord.Add((X, Y, _gridSerialNumber), powerLevel);

            return powerLevel;
        }
    }
}