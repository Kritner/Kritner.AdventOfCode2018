namespace Kritner.AdventOfCode2018.Day11
{
    public class Cell
    {
        public int X { get; }
        public int Y { get; }

        private int _gridSerialNumber;
        private int _calculatedPowerLevel;
        private bool _isPowerLevelCalculated;

        public Cell(int x, int y, int gridSerialNumber)
        {
            X = x;
            Y = y;
            _gridSerialNumber = gridSerialNumber;
        }

        public int GetPowerLevel()
        {
            if (_isPowerLevelCalculated)
            {
                return _calculatedPowerLevel;
            }

            _isPowerLevelCalculated = true;

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

            _calculatedPowerLevel = powerLevel;

            return _calculatedPowerLevel;
        }
    }
}